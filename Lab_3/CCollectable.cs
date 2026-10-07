using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Lab_3
{
    public abstract class CCollectable
    {
        private Point position; // позиция собираемого объекта в сцене
        private protected Size size; // размер собираемого объекта
        private double lifetime; // время жизни собираемого объекта
        private protected Ellipse sprite; // визуальное отображение собираемого объекта
        public CCollectable(Point position, double size, double lifetime) //
        {
            this.position = position;
            this.size = new Size(size, size);
            this.lifetime = lifetime;
            sprite = new Ellipse();
            sprite.Fill = Brushes.BlueViolet;
            sprite.StrokeThickness = 2;
            sprite.Stroke = Brushes.Black;
            sprite.HorizontalAlignment = HorizontalAlignment.Center;
            sprite.VerticalAlignment = VerticalAlignment.Center;
            sprite.Width = this.size.Width;
            sprite.Height = this.size.Height;
            sprite.RenderTransform = new TranslateTransform(position.X,position.Y);
        }

// абстрактная функция обработки нажатия на объект
public abstract bool onClick(CPlayer player, CController controller,
Point mousePosition);
    }
}
