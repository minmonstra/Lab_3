using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Lab_2
{
    public class CEnemyTemplateList
    {
        private readonly Random random = new Random();
        private List<CEnemyTemplate> enemies = new List<CEnemyTemplate>();
        public int Count => enemies.Count;
        public void LoadFromJson(string path)
        {
            enemies = JsonSerializer.Deserialize<List<CEnemyTemplate>>(File.ReadAllText(path))
                      ?? new List<CEnemyTemplate>();
            normalizeChances();
        }
        void normalizeChances() // нормализация шансов появления объектов, сумма шансов должна быть равна 1
        {
            if (enemies.Count == 0)
                return;

            double sum = 0;
            for (int i = 0; i < enemies.Count; i++)
                sum += enemies[i].SpawnChance;

            if (sum <= 0)   // защита от деления на ноль: все шансы нулевые, делаем их равными
            {
                for (int i = 0; i < enemies.Count; i++)
                    enemies[i].SetSpawnChance(1.0 / enemies.Count);
                return;
            }

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].SetSpawnChance(enemies[i].SpawnChance / sum);
        }
        CEnemyTemplate findByChance(double chance)  // поиск объекта по выпавшей вероятности
        {
            double sum = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                sum += enemies[i].SpawnChance;
                if (sum >= chance) return enemies[i];
            }
            return enemies[enemies.Count - 1];   // запас на погрешность double
        }

        public CEnemyTemplate GetRandomTemplate()
        {
            if (enemies.Count == 0)
                return null;

            return findByChance(random.NextDouble());

        }
    }
}
    

