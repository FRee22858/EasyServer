using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace DBAccess
{

    public class ReconnectRecord
    {
        public double TryConnectTime = 0.0;
        public double MaxConnectTime;
        public bool NeedReconnect = false;
        public void Init(double max_connect_time)
        {
            TryConnectTime = 0.0;
            MaxConnectTime = max_connect_time;
            NeedReconnect = false;
        }
        public void Reset()
        {
            TryConnectTime = 0.0;
            NeedReconnect = false;
        }
    }

    public class DBManager
    {
        DBConnection conn = null;
        public DBConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        private Queue<AbstractDBQuery> saveQueue =new Queue<AbstractDBQuery>();
        private Queue<AbstractDBQuery> executionQueue = new Queue<AbstractDBQuery>();
        private Queue<AbstractDBQuery> postUpdateQueue = new Queue<AbstractDBQuery>();
        private Queue<string> executionLogQueue = new Queue<string>();

        private DBConfig _config;
        public bool Opened = false;

        public ReconnectRecord ReconnectInfo;
        public bool InitConnect(DBConfig config)
        {
            ReconnectInfo = new ReconnectRecord();
            ReconnectInfo.Init(60*1000);

            saveQueue = new Queue<AbstractDBQuery>();
            postUpdateQueue = new Queue<AbstractDBQuery>();

            _config = config;
            conn = new MySqlDBConnection(); //用mysql连接
            if (conn.InitConnect(_config))
            {
                Opened = true;
                return true;
            }
            else 
            {
                return false;
            }
        }
        public bool IsDisconnected()
        {
            return conn.IsDisconnected();
        }
        public bool DisConnect()
        {
            if (conn.DisConnect())
            {
                Opened = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Add(AbstractDBQuery query)
        {
            query.Init(conn);
            lock (saveQueue)
            {
                saveQueue.Enqueue(query);
            }
        }
        public void Call(AbstractDBQuery query, DBCallback callBack = null)
        {
            query.OnCall(callBack);
            Add(query);
        }

        public double lasttime;
        double totaltime;
        public void Run()
        {
            var tempPostUpdateQueue = new Queue<AbstractDBQuery>();
            var time = new Time();
            time.Init();
            while (true)
            {
                var dt = time.Update();
                lasttime = dt.TotalMilliseconds;

                if (lasttime>1)
                {
                    Thread.Sleep(0);
                }
                else
                {
                    Thread.Sleep(1);
                }
                if (totaltime>10000)
                {
                    totaltime = 0;
                }
                else
                {
                    totaltime += lasttime;
                }
                lock(ReconnectInfo)
                {
                    if (IsDisconnected()||ReconnectInfo.NeedReconnect==true)
                    {
                        Opened = false;
                        string log = String.Format("Disconnect from db {0},esplased {1} ms", _config.DbName, ReconnectInfo.TryConnectTime);
                        
                    }

                }
            }
            //frTODO:  
        }
        public Queue<string> GetExceptionLogQueue()
        {
            Queue<string> ret;
            lock (executionLogQueue)
            {
                if (executionLogQueue.Count!=0)
                {
                    ret = executionLogQueue;
                    executionLogQueue = new Queue<string>();
                }
                else
                {
                    return null;
                }
            }
            return ret;
        }
        public void AddExcepionLog(string log)
        {
            lock (executionLogQueue)
            {
                executionLogQueue.Enqueue(log);
            }
        }

    }
}


