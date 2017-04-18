using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Log
    {
        public Log(ILogger logger)
        {
            Log.logger = logger;
        }
        static private ILogger logger;
        static public void InitLogger(ILogger log)
        {
            logger = log;
        }
        static public void Write(object obj)
        {
            logger.Write(obj);
        }
        static public void Write(string format, params object[] args)
        {
            logger.Write(format, args);
        }
        static public void WriteLine(object obj)
        {
            logger.WriteLine(obj);
        }
        static public void WriteLine(string format, params object[] args)
        {
            logger.WriteLine(format, args);
        }

        static public void Info(object obj)
        {
            logger.Info(obj);
        }
        static public void Info(string format, params object[] args)
        {
            logger.Info(format, args);
        }
        static public void InfoLine(object obj)
        {
            logger.InfoLine(obj);
        }
        static public void InfoLine(string format, params object[] args)
        {
            logger.InfoLine(format, args);
        }

        static public void Warn(object obj)
        {
            logger.Warn(obj);
        }
        static public void Warn(string format, params object[] args)
        {
            logger.Warn(format, args);
        }
        static public void WarnLine(object obj)
        {
            logger.WarnLine(obj);
        }
        static public void WarnLine(string format, params object[] args) 
        {
            logger.WarnLine(format, args);
        }

        static public void Error(object obj)
        {
            logger.Error(obj);
        }
        static public void Error(string format, params object[] args)
        {
            logger.Error(format, args);
        }
        static public void ErrorLine(object obj)
        {
            logger.ErrorLine(obj);
        }
        static public void ErrorLine(string format, params object[] args)
        {
            logger.ErrorLine(format, args);
        }

        static public void Close()
        {
            logger.Close();
        }

    }
}
