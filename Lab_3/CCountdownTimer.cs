using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class CCountdownTimer
    {
        private double targetTime;

        public  double getTime()
        {
            return targetTime;
        }

        public void update(double delta) { 
            targetTime = delta;
        }
    }
}
