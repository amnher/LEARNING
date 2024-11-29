using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamageGame
{
    internal class SwordDamage
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;
        public int Roll;
        private decimal MagicMultiplier = 1M;
        public int Damage;

        private void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE;
            Debug.WriteLine($"Calculatedamage set damage to {Damage} (roll:{Roll})");
        }
        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75M;
            }
            else
            {
                MagicMultiplier = 1M;
            }
            CalculateDamage();
            Debug.WriteLine($"SetMagic is finished: Damage = {Damage} (roll: {Roll})");
        }
        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"SetFlaming is finished: Damage = {Damage} (roll: {Roll})");
        }
    }
}
