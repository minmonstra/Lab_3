using System.Windows;

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

        //  перезарядка
        public void mouseClick(Point mousePosition)
        {
            if (!canClick)
                return;

            canClick = false;
            countdownTimer = new CCountdownTimer(timeBeforeClick);
        }

        // перезарядка закончилась
        public void countdownEnded()
        {
            canClick = true;
        }

        public void update(double delta)
        {
            if (canClick)
                return;

            countdownTimer.update(delta);
            if (countdownTimer.getTime() <= 0)
                countdownEnded();
        }

        // ускорение кликов 
        public void increaseSpeed(double speedModifier)
        {
            timeBeforeClick /= speedModifier;
            if (timeBeforeClick < 0.1)
                timeBeforeClick = 0.1;
        }
         
        public bool CanClick { get { return canClick; } }
        public double GetCooldownRemaining() { return countdownTimer.getTime(); }
    }
}