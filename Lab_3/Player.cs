using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class Player
    {
        //хранят непостредсвенно значения, состояние
        private readonly double DamageModifier = 10;
        private readonly double UpgradeModifier = 1.7;

        public int Lvl { get; private set; } = 1;
        public BigNumber Gold { get; private set; } = new BigNumber("0");
        public BigNumber Damage { get; private set; } = new BigNumber("1");
        public BigNumber UpgradeCost { get; private set; } = new BigNumber("10");
        
    
        public void AddGold(BigNumber amount)
        {
            Gold = Gold + amount;
        }


        private void RecalculateStats()
        {
            CalculateTotalDamage();
            CalculateNextUpgradeCost();
            Lvl++;
        }
      

        public BigNumber DealDamage()
        {
            return Damage;  
        }


        private BigNumber CalculateNextUpgradeCost()
        {
            UpgradeCost = UpgradeCost.Multiply(UpgradeModifier*Lvl);
            return UpgradeCost;
        }


        private BigNumber CalculateTotalDamage()
        {
            Damage = Damage.Multiply(DamageModifier);
            return Damage;
        }


        public bool TryUpgrade()
        {
            if (!TrySpendGold(UpgradeCost))
                return false;

            RecalculateStats();
            return true;
        }


        private bool TrySpendGold(BigNumber amount) 
        {
            if (Gold.CompareTo(amount) >= 0)
            {
                Gold = Gold - amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
