using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Time
    {
        private DateTime prev;
        public void Init() 
        {
            prev = DateTime.Now;
        }

        public TimeSpan Update(out bool isPassDay)
        {
            var now = DateTime.Now;
            if (now.Day != prev.Day)
            {
                isPassDay = true;
            }
            else
            {
                isPassDay = false;
            }
            var delta = now - prev;
            prev = now;
            return delta;
        }

        public TimeSpan Update()
        {
            var now = DateTime.Now;
            var delta = now - prev;
            prev = now;
            return delta;
        }
    }
}
