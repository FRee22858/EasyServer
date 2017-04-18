using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class MySqlDBConnection:DBConnection
    {
        string strConn = string.Empty;
        MySqlConnection _conn = new MySqlConnection();
        public object Conn
        {
            get { return _conn; }
        }

        public bool InitConnect(DBConfig config)
        {
            strConn = string.Format("data source={0};database={1};user id={2};password ={3};port={4}",config.DbIp,config.DbName,config.DbAccount,config.DbPassword,config.DbPort);
            try
            {
                _conn = new MySqlConnection(strConn);
                _conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                
              //frTODO: log
                return false;
            }
        }

        public bool DisConnect()
        {
            try
            {
                if (_conn != null)
                {
                    _conn.Close();
                    _conn = null;
                }
                return false;
            }
            catch (MySqlException e)
            {
                //frTODO: log
                throw;
            }
        }

        public bool IsDisconnected()
        {
            return (_conn.State == System.Data.ConnectionState.Closed || _conn.State == System.Data.ConnectionState.Broken);
        }
    }
}
