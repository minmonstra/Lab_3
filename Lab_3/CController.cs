using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class CController // класс, управляющий собираемыми объектами
    {
        private List<CObject> objects; // список собираемых объектов
        private double spawnRate;
        private double time;
        private Random rng;
        // время между созданием собираемых объектов
        // время с момента создания последнего объекта
        // минимальное и максимальное время жизни собираемых объектов
        private double minLifetime;
        private double maxLifetime;
        // минимальный и максимальный размер собираемых объектов
        private double minSpriteSize;
        private double maxSpriteSize;
        private Size sceneSize; // размер сцены
        private double points; // набранные очки
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
}
