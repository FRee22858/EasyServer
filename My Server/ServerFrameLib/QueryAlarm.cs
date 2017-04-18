using DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ServerFrameLib
{
    internal class QueryAlarm : MySqlAbstractDBQuery
    {
        override public bool Execute()
        { 
            _cmd.CommandText = "SELECT COUNT(type) from alarm;";
            _cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                _reader = _cmd.ExecuteReader();
                _reader.Read();

                int count = _reader.GetInt32(0);
                _result = count;
            }
            catch (Exception e)
            {
                _result = 0;
                _errorText = ErrorLogText(e);
                throw;
            }
            finally
            {
                if (_reader!=null)
                {
                    _reader.Close();   
                }
            }
            return true;
        }
    }
}
