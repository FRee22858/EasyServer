using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DBAccess
{
    public abstract class MySqlAbstractDBQuery : AbstractDBQuery
    {
        protected MySqlCommand _cmd;

        protected DBCallback _callback;
     
        protected object _result;
        
        public string _errorText;
      
        protected MySqlDataReader _reader;

        private MySqlConnection _conn;


        public void Init(DBConnection dbconn)
        {
            _conn = (MySqlConnection)dbconn.Conn;
            _cmd = _conn.CreateCommand();
            _cmd.CommandTimeout = 0;
        }

        public void OnCall(DBCallback callBack)
        {
            _callback = callBack;
        }

        public void PostUpdate()
        {
            if (_callback != null)
            {
                _callback(_result);
            }
        }

        abstract public bool Execute();

        public string ErrorLogText(Exception e)
        {
            string logText = string.Empty;
            if (_cmd != null)
            {
                logText = "CommandText:" + _cmd.CommandText + "\r\n";
                for (int i = 0; i < _cmd.Parameters.Count; i++)
                {
                    var item = _cmd.Parameters[i];
                    if (item.Value == null)
                    {
                        logText += string.Format("{0}:null", item.ParameterName);
                    }
                    else
                    {
                        logText += string.Format("{0}:{1}", item.ParameterName, item.Value);
                    }
                }
            }
            else
            {
                logText = "MySqlCommand is null \r\n";
            }
            logText += "\r\n";
            logText += e.ToString();
            return logText;
        }

    }
}
