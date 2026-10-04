using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab_3
{
    internal class CObject
    {
        public CObject(Point position, double size, double lifetime) // конструктор
        {
            this.position = position;
            this.size = new Size(size, size);
            this.lifetime = lifetime;
            // создание фигуры
            sprite = new Ellipse();
            // цвет фигуры
            sprite.Fill = Brushes.BlueViolet;
            sprite.StrokeThickness = 2;
            sprite.Stroke = Brushes.Black;
            // центрирование фигуры
            sprite.HorizontalAlignment = HorizontalAlignment.Center;
            sprite.VerticalAlignment = VerticalAlignment.Center;
            // размеры фигуры
            sprite.Width = this.size.Width;
            sprite.Height = this.size.Height;
            sprite.RenderTransform = new TranslateTransform(position.X - size/2, position.Y - size/2);
            pointsValue = ((1 / this.size.Width) / lifetime) * 1000; // очковая стоимость объекта
        }
        private Point position; 
        private Size size;
        private double lifetime;
        private double pointsValue;
        private Ellipse sprite;
        public CObject(Point position, double size, double lifetime, double pointsValue) : this(position, size, lifetime)
        {
            this.pointsValue = pointsValue;
        }
        public bool isMouseOnObject(Point mousePosition)
        {
            double dx = mousePosition.X - position.X;
            double dy = mousePosition.Y - position.Y;
            double radius = size.Width / 2;

            return dx * dx + dy * dy <= radius * radius;
        }
        public Ellipse getSprite() { 
            return sprite;
        }
        public double getPointsValue() {
            return pointsValue;
        }

        public bool updateLifetime(double delta) {
            lifetime -= delta;
            return lifetime <= 0;
        }
    }
}
