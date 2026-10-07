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

        public void Update(double delta)
        {
            targetTime = delta;
        }

        public void SetTime(double time)
        {
            targetTime = time;
        }

        public void Start()
        {

        }

        public void Reset()
        {
            targetTime = 0;

        }

        public void IsFinished()
        {
            if (targetTime <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
