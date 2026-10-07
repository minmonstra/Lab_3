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
            countdownTimer = new CCountdownTimer(0);
        }

        public bool CanClick  
                {
                    get { return countdownTimer.getTime() <= 0; }
                }
        public double GetCooldownRemaining()
        {
            return countdownTimer.getTime();
        }
        public void countdownClick(double delta)
        {
            countdownTimer.update(delta);
        }
        public void ChangeTimeBeforeClick(double modifier)
        {
            timeBeforeClick *= modifier;               // меньше 1 = перезарядка короче
            if (timeBeforeClick < 0.1) timeBeforeClick = 0.1;
        }
    }
}
