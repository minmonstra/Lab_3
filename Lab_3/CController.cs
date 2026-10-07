using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab_3
{
    public class CController // класс, управляющий собираемыми объектами
    {
        private List<CCollectable> objects;  // список собираемых объектов
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
            objects = new List<CCollectable>();
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
            double x = size / 2 + rng.NextDouble() * (sceneSize.Width - size);
            double y = size / 2 + rng.NextDouble() * (sceneSize.Height - size);

            objects.Add(new CPointGiver(new Point(x, y), size, lifetime));
        }

        public void pointsIncrease(double value)
        {
            points += value;
        }

        public void mouseClick(Point mousePosition, CPlayer player)
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].onClick(player, this, mousePosition))
                {
                    objects.RemoveAt(i);
                    break;
                }
            }
        }
        public void changeSpawnRate(double modifier)
        {
            spawnRate *= modifier;

            // границы, чтобы интервал не стал нулевым или слишком большим
            if (spawnRate < 0.2) spawnRate = 0.2;
            if (spawnRate > 5) spawnRate = 5;
        }
        public List<CCollectable> getObjects() { return objects; }
    }
}