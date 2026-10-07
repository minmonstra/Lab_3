using System.Windows;
using System.Windows.Media;

namespace Lab_3
{
    public class CLifetimeChanger : CCollectable
    {
        private double lifetimeModifier;   // множитель интервала появления сфер

        public CLifetimeChanger(Point position, double size, double lifetime, double lifetimeModifier)
            : base(position, size, lifetime)
        {
            this.lifetimeModifier = lifetimeModifier;
            sprite.Fill = Brushes.Black;   // свой цвет, чтобы отличать бонус
        }

        public override bool onClick(CPlayer player, CController controller, Point mousePosition)
        {
            if (isMouseOnObject(mousePosition) == false)
                return false;

            controller.changeLifetime(lifetimeModifier);
            return true;
        }
    }
}
{
    }
}
