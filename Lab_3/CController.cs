using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class CController
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
            double points; // набранные очки
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
        }
        private List<CObject> objects;
        private double spawnRate;
        private double time;
        private Random rng;
        private double minLifetime;
        private double maxLifetime;
        private double minSpriteSize;
        private double maxSpriteSize;
        private Size sceneSize;
        private double points;

        public CObject(double spawnRate, int startTime, Size SceneSize);
        public void SpawnObject()
        {

        }
        public void destroyObject(CObject obj)
        {
            objects.Remove(obj);
        }
        public void update(double delta)
        {

        }

        public void mouseClick(Point mousePosition)
        { 
        }
    }
}
