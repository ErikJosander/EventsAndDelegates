using System;

namespace EventsAndDelegates
{
    public class ShoutOutService
    {
        public void ShoutOut(object sender, WarriorEventArgs e)
        {
            Console.WriteLine($"{e.Warrior.Name} has entered the arena!");
            Console.WriteLine("---------------------------------");
        }
        public void AttackShoutOut(object sender, AttackEventArgs e)
        {
            Console.WriteLine($"{e.Attacker.Name} is attacking {e.Defender.Name} with {e.Attacker.Weapon.Name}");
            Console.WriteLine($"{e.Attacker.Name} attacked for {CalculateFight.HitPoint(e.Attacker)} ");
            Console.WriteLine($"{e.Defender.Name} has {Math.Round(e.Defender.CurrentHelth, 2)} left ");
            Console.WriteLine("---------------------------------");
        }
        public void WinnerShoutOut(object sender, WarriorEventArgs e)
        {
            Console.WriteLine($"Winner is: {e.Warrior.Name}");
        }

        public void DefendShoutOut(object sender, AttackEventArgs e)
        {
            Console.WriteLine($"{e.Attacker.Name} attacks, with {e.Attacker.Weapon.Name}");
            Console.WriteLine($"But {e.Defender.Name} defends");
            Console.WriteLine("---------------------------------");
        }
    }
}
