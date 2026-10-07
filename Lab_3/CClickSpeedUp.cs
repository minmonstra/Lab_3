using System.Windows;
using System.Windows.Media;

namespace Lab_3
{
    public class CClickSpeedUp : CCollectable
    {
        private double speedModifier;
        public CClickSpeedUp(Point position, double size, double lifetime, double speedModifier)
            : base(position, size, lifetime)
        {
            this.speedModifier = speedModifier;
            sprite.Fill = Brushes.Pink;   // свой цвет, чтобы отличать бонус
        }

        public override bool onClick(CPlayer player, CPlayer cplayer, Point mousePosition)
        {
            if (isMouseOnObject(mousePosition) == false)
                return false;
            cplayer.pointsIncrease(speedModifier);
                return true;
        }
    }
}
