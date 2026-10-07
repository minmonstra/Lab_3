using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;

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

        public override bool onClick(CPlayer player, CController controller, Point mousePosition)
        {
            player.increaseSpeed(speedModifier);
            if (isMouseOnObject(mousePosition) == false)
                return false;
            player.increaseSpeed(speedModifier);
                return true;
        }
    }
}
