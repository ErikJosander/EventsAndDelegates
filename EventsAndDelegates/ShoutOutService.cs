using System;

namespace EventsAndDelegates
{
    public class ShoutOutService
    {
        private string pronuciation = "a";

        public void ShoutOut(object sender, WarriorEventArgs e)
        {
            Console.WriteLine($"{e.Warrior.Name} has entered the arena!");
            Console.WriteLine("---------------------------------");
        }
        public void AttackShoutOut(object sender, AttackEventArgs e)
        {
            pronuciation = GetPronuciation(e);
            Console.WriteLine($"{e.Attacker.Name} is attacking {e.Defender.Name} with {pronuciation} {e.Attacker.Weapon.Name}");
            Console.WriteLine($"{e.Attacker.Name} attacked for {Math.Round(CalculateFight.HitPoint(e.Attacker), 2)} ");
            switch (e.Defender.CurrentHelth)
            {
                case var n when n <= 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{e.Defender.Name} has {Math.Round(e.Defender.CurrentHelth, 2)} left, {e.Defender.Name} has died!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case var n when n > 0:
                    Console.WriteLine($"{e.Defender.Name} has {Math.Round(e.Defender.CurrentHelth, 2)} left ");
                    break;
            }
            Console.WriteLine("---------------------------------");
        }
        public void WinnerShoutOut(object sender, WarriorEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Winner is: {e.Warrior.Name}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DefendShoutOut(object sender, AttackEventArgs e)
        {
            pronuciation = GetPronuciation(e);
            Console.WriteLine($"{e.Attacker.Name} attacks {e.Defender.Name}, with {pronuciation} {e.Attacker.Weapon.Name}");
            Console.WriteLine($"But {e.Defender.Name} defends");
            Console.WriteLine("---------------------------------");
        }

        public string GetPronuciation(AttackEventArgs e)
        {
            if (Helpers.IsFirstCaseWovel(e.Attacker.Weapon.Name)) return "an";
            else return "a";
        }
    }
}
