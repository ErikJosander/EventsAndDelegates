using System;

namespace EventsAndDelegates
{
    public class CalculateFight
    {
        private static Random random = new Random();
        public static double HitPoint(Warrior warrior)
        {
            return warrior.HitDamage + warrior.Weapon.Damage;
        }

        public static bool CheckIfHit(Warrior attacker, Warrior defender)
        {
            var p = random.Next(100);
            if (p > (defender.BlockChance + defender.Fitness) - (attacker.Weapon.HitRate + attacker.Fitness))
            {
                return true;
            }
            return false;
        }
    }
}
