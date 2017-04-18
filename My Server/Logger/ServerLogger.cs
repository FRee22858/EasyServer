using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    enum LogType
    {
        WRITE=0,
        INFO =1,
        WARN = 2,
        ERROR = 3,
    }
    public class ServerLogger : AbstractLogger
    {
        private string prefix = "";
        private string baseDir = "C:";
        private int cmdCurLevel = 0;
        private int fileCurLevel = 0;
        private string logFileName = "";
        private string Logo = "";

        StreamWriter tw;
        public ServerLogger(string logFilepPath)
        {
            this.baseDir = logFilepPath;
        }

        public void Init(string prefix, LogType cmdLevel, LogType fileLevel)
        {
            this.cmdCurLevel = (int)cmdLevel;
            this.fileCurLevel = (int)fileLevel;
            this.prefix = prefix;
            logFileName = GetLogFileName(prefix);

            tw = new StreamWriter(logFileName);
            tw.AutoFlush = false;
        }

        private string GetLogFileName(string prefix)
        {
            string path = baseDir + DateTime.Now.ToString("yyyy_MM_dd") + "/";
            try
            {
                if (Directory.Exists(path)==false)
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception e)
            {
                Log.Error("Could not create save directory for log. see Logger.cs");
            }


        }

        public void SetLogo(string logo)
        {
            if (logo!=null)
            {
                this.Logo = logo;
            }
        }
        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Write(object obj)
        {
            try
            {
                string info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + Logo + "[WARN]" + obj;
                if (cmdCurLevel < (int)LogType.WRITE)
                {

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(info);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (fileCurLevel < (int)LogType.WRITE)
                {

                }
                else
                {
                    tw.WriteLine(info);
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public override void WriteLine(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Warn(object obj)
        {
            throw new NotImplementedException();
        }

        public override void WarnLine(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Error(object obj)
        {
            throw new NotImplementedException();
        }

        public override void ErrorLine(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Info(object obj)
        {
            throw new NotImplementedException();
        }

        public override void InfoLine(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
