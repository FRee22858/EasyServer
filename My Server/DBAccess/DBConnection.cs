using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public interface DBConnection
    {
        object Conn{get;}
        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <returns></returns>
        bool InitConnect(DBConfig config);
        /// <summary>
        /// 断开数据库连接
        /// </summary>
        /// <returns></returns>
        bool DisConnect();
        /// <summary>
        /// 连接状态
        /// </summary>
        /// <returns></returns>
        bool IsDisconnected();
    }
}
