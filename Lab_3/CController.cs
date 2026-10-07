using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab_3
{
    public class CController // класс, управляющий собираемыми объектами
    {
            List<CObject> objects; // список собираемых объектов
            double spawnRate;
            double time;
            Random rng;
            // время между созданием собираемых объектов
            // время с момента создания последнего объекта
            // минимальное и максимальное время жизни собираемых объектов
            double minLifetime;
            double maxLifetime;
            // минимальный и максимальный размер собираемых объектов
            double minSpriteSize;
            double maxSpriteSize;
            Size sceneSize; // размер сцены
            double points; // набранные очк
            public CController(double spawnRate, ulong startTime, Size sceneSize)
        {
            rng = new Random();
            objects = new List<CObject>();
            this.spawnRate = spawnRate;
            time = startTime;
            this.sceneSize = sceneSize;
            points = 0;
            minLifetime = 1;
            maxLifetime = 5;
            minSpriteSize = 10;
            maxSpriteSize = 20;
        }

        public void SpawnObject()
        {
            double lifetime = rng.NextDouble() * (maxLifetime - minLifetime) + minLifetime;
            double size = rng.NextDouble() * (maxSpriteSize - minSpriteSize) + minSpriteSize;

            // position это центр, поэтому отступаем от краёв на половину размера
            double x = size / 2 + rng.NextDouble() * (sceneSize.Width - size);
            double y = size / 2 + rng.NextDouble() * (sceneSize.Height - size);

            objects.Add(new CObject(new Point(x, y), size, lifetime));
        }

        public void destroyObject(CObject obj)
        {
            points += obj.getPointsValue();
            objects.Remove(obj);
        }

        public void Update(double delta)
        {
            time += delta;
            if (time >= spawnRate)
            {
                SpawnObject();
                time = 0;
            }

            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].updateLifetime(delta))
                    objects.RemoveAt(i);
            }
        }

        public void mouseClick(Point mousePosition)
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].isMouseOnObject(mousePosition))
                {
                    destroyObject(objects[i]);
                    break;
                }
            }
        }

        public List<CObject> getObjects() { return objects; }
        public double getPoints() { return points; }
    }
}