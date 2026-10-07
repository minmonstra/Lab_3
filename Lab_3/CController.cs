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
            Point position = new Point(x, y);
            double roll = rng.NextDouble();
            CCollectable obj;

            if (roll < 0.5)
                obj = new CPointGiver(position, size, lifetime);
            else if (roll < 0.65)
                obj = new CSpawnRateChanger(position, size, lifetime, 0.8);
            else if (roll < 0.8)
                obj = new CLifetimeChanger(position, size, lifetime, 1.2);
            else
                obj = new CClickSpeedUp(position, size, lifetime, 0.8);

            objects.Add(obj);
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
                    destroyObject(objects[i]);
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

        public void changeLifetime(double modifier)
        {
            minLifetime *= modifier;
            maxLifetime *= modifier;
            // границы, чтобы интервал не стал нулевым или слишком большим
            if (minLifetime < 0.5) minLifetime = 0.5;
            if (maxLifetime > 10) maxLifetime = 10;
        }
        public List<CCollectable> getObjects() { return objects; }
        public void destroyObject(CCollectable obj)
        {
            objects.Remove(obj);
        }

        public double getPoints() { return points; }
        public void update(double delta)
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
                {
                    destroyObject(objects[i]);
                }
            }
        }
        public void destroyObjects()
        {
            objects.Clear();
        }
    }
}