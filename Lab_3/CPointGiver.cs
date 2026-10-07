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
    public class CPointGiver : CCollectable
    {
        double pointsValue;
        // конструктор вызывает конструктор родителя
        public CPointGiver(Point position, double size, double lifetime)
        : base(position, size, lifetime)
        {
            sprite.Fill = Brushes.BlueViolet;
            pointsValue = ((1 / this.size.Width) / lifetime) * 1000;
        }
        // переопределение функции нажатия
        public override bool onClick(CPlayer player, CController controller,
        Point mousePosition)
        {
            if (isMouseOnObject(mousePosition) == false)
                return false;
            controller.pointsIncrease(pointsValue);
            return true;
        }
    }
}
