using DBAccess;
using Logger;
using ServerBaseShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFrameLib
{
    public class Api : IServer
    {
        Mode startMode = Mode.Manual;
        public Mode StartMode
        {
            get { return startMode; }
        }

        string serverName = "ServerFrame";
        public string ServerName
        {
            get
            {
                return serverName;
            }
            set
            {
                serverName = value;
            }
        }

        internal DBManager db;
        public DBManager DB
        {
            get { return db; }
        }

        private Thread dbThread;
        public Thread DBThread
        {
            get { return dbThread; }
        }

        private DBConfig _config = new DBConfig();
        public DBConfig Config
        {
            get { return _config; }
        }

        public void Init(string[] args)
        {
            startMode = Mode.Auto;
            Console.WriteLine("全局服务器已经开启,正在初始化......");
            InitDB();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void ProcessInput()
        {
            throw new NotImplementedException();
        }

        void InitLog()
        {
            var logger = new ServerLogger("D:/Log/");

            Log.InitLogger(logger);
        }
        void InitDB()
        {
            //frTODO: 初始化DB
            _config.DbIp = "192.168.1.108";
            _config.DbPort = "3306";
            _config.DbAccount = "root";
            _config.DbPassword = "root";
            _config.DbName = "test";

            db = new DBManager();
            db.InitConnect(Config);

            dbThread = new Thread(db.Run);
        }

        void InitSocket()
        {
            //frTODO: 初始化socket
        }

    }
}
