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

        public CCountdownTimer(double time)
        {
            targetTime = time;
        }

        public double getTime()
        {
            return targetTime;
        }

        public void update(double delta)
        {
            targetTime -= delta;
            if (targetTime < 0)
                targetTime = 0;
        }
    }
}
