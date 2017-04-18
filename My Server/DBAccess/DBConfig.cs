using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class DBConfig
    {
        string _dbIp;
        public string DbIp
        {
            get { return _dbIp; }
            set { _dbIp = value; }
        }

        string _dbName;
        public string DbName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }
        string _dbAccount;
        public string DbAccount
        {
            get { return _dbAccount; }
            set { _dbAccount = value; }
        }
        string _dbPassword;
        public string DbPassword
        {
            get { return _dbPassword; }
            set { _dbPassword = value; }
        }
        string _dbPort;
        public string DbPort
        {
            get { return _dbPort; }
            set { _dbPort = value; }
        }
    }
}
