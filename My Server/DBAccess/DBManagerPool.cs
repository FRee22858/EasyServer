using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBAccess
{
    public class DBManagerPool
    {
        private int poolCount = 0;
        private int index = 0;

        private List<DBManager> dbManagerList = new List<DBManager>();
        public List<DBManager> DBManagerList 
        { get { return dbManagerList; } }

        private List<Thread> dbThreadList = new List<Thread>();

        public Dictionary<int, int> DBCallCountList = new Dictionary<int, int>();
        public Dictionary<string, int> DBCallNameList = new Dictionary<string, int>();

        public DBManagerPool(int count)
        {
            poolCount = count;
            for(int i=0;i<poolCount;i++)
            {

                DBManager db = new DBManager();
                dbManagerList.Add(db);
                DBCallCountList.Add(i, 0);
            }
        }

        public bool Init(DBConfig config)
        {
            foreach (var db in dbManagerList)
            {
                if (db.InitConnect(config) == false)
                {
                    return false;
                }
                Thread dbThread = new Thread(db.Run);
                dbThreadList.Add(dbThread);
                dbThread.Start();
            }
            return true;
        }

        public int GetDBIndex()
        {
            index++;
            if (index>=10000)
            {
                index = 0;
            }
            return index % dbManagerList.Count;
        }

        public int Call(AbstractDBQuery query,DBCallback callback = null)
        {
            int dbIndex = GetDBIndex();
            dbManagerList[dbIndex].Call(query,callback);
            return dbIndex;
        }

        public void Abort()
        {
            foreach (var thread in dbThreadList)
            {
                thread.Abort();
            }
            dbThreadList.Clear();
        }

        public bool Exit()
        {
            foreach (var db in dbManagerList)
            {
                try
                {
                    if (db.Conn!=null)
                    {
                        db.Conn.DisConnect();
                        db.Opened = false;
                        db.Conn = null;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e.ToString());
                    return  false;
                }
            }
            return true;
        }
    }
}
