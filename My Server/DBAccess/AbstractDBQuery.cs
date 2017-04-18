using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public delegate void DBCallback(object msg);

    public interface AbstractDBQuery
    {
        void OnCall(DBCallback callBack);
        void Init(DBConnection conn);
    }
}
