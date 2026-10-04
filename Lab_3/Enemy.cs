using Lab_2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class Enemy
    {
        private string name;
        private BigNumber maxHitPoints;
        private BigNumber currentHitPoints;
        private BigNumber goldReward;
        private bool isDead;

        public string IconName { get; }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public BigNumber MaxHitPoints
        {
            get { return maxHitPoints; }
            private set { maxHitPoints = value; }
        }
        public BigNumber CurrentHitPoints
        {
            get { return currentHitPoints; }
            private set { currentHitPoints = value; }
        }

        public BigNumber GoldReward
        {
            get { return goldReward; }
            private set { goldReward = value; }
        }
        public bool IsDead
        {
            get { return isDead; }
            private set { isDead = value; }
        }
 

        public Enemy(CEnemyTemplate template, int level)
        {
            Name = template.Name;
            IconName = template.IconName;

            MaxHitPoints = ApplyModifier(new BigNumber(template.BaseLife.ToString()), template.LifeModifier, level);
            CurrentHitPoints = MaxHitPoints;
            GoldReward = ApplyModifier(new BigNumber(template.BaseGold.ToString()), template.GoldModifier, level);

            IsDead = false;
        }
        private static BigNumber ApplyModifier(BigNumber value, double modifier, int times)
        {
            BigNumber result = value;

            for (int i = 0; i < times; i++)
                result = result.Multiply(modifier);

            return result;
        }

        //помер
        private void Die()
        {
            IsDead = true;
            CurrentHitPoints = new BigNumber("0");
        }


        public bool TakeDamage(BigNumber dmg, out BigNumber goldReward)
        {
            goldReward = new BigNumber("0");

            if (IsDead)
                return false;

            // урон >= оставшегося здоровья -> противник погибает
            if (CurrentHitPoints.CompareTo(dmg) <= 0)
            {
                Die();
                goldReward = GoldReward;
                return true;
            }

            CurrentHitPoints = CurrentHitPoints - dmg;
            return false;
        }


    }
}