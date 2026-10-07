using System.Windows;
using System.Windows.Media;

namespace Lab_3
{
    internal class CSpawnRateChanger : CCollectable
    {
        private double spawnModifier;   // множитель интервала появления сфер

        public CSpawnRateChanger(Point position, double size, double lifetime, double spawnRateModifier)
            : base(position, size, lifetime)
        {
            this.spawnModifier = spawnRateModifier;
            sprite.Fill = Brushes.Orange;   // свой цвет, чтобы отличать бонус
        }

        public override bool onClick(CPlayer player, CController controller, Point mousePosition)
        {
            if (isMouseOnObject(mousePosition) == false)
                return false;

            controller.changeSpawRate(spawnModifier);
            return true;
        }
    }
}