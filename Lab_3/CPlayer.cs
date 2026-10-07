using System.Windows;
using System.Windows.Media;

namespace Lab_3
{
    public class CPlayer
    {
        private bool canClick;
        private double timeBeforeClick;
        private CCountdownTimer countdownTimer;

        public CPlayer(double timeBeforeClick)
        {
            this.timeBeforeClick = timeBeforeClick;
            canClick = true;
            countdownTimer = new CCountdownTimer(timeBeforeClick);
        }

        public bool CanClick { get { return canClick; } }

        public double GetCooldownRemaining()
        {
            return countdownTimer.getRemaining();
        }
        public void countdownClick()
        {
            if (canClick)
            {
                canClick = false;
                countdownTimer.Start();
            }
        }
        public void update(double delta)
        {
            if (!canClick)
            {
                countdownTimer.Update(delta);
                if (countdownTimer.IsFinished())
                {
                    canClick = true;
                    countdownTimer.Reset();
                }
            }
        }

        public void ChangeTimeBeforeClick(double modifier)
        {
            timeBeforeClick *= modifier;               // меньше 1 = перезарядка короче
            if (timeBeforeClick < 0.1) timeBeforeClick = 0.1;
            countdownTimer.SetTime(timeBeforeClick);
        }
    }
}
