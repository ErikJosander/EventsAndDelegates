using System;
using System.Collections.Generic;

namespace EventsAndDelegates
{
    class Program
    {
        public static ShoutOutService shoutOutService = new ShoutOutService();
        static void Main(string[] args)
        {
            Weapon axe = new Weapon("Axe", 1.2, 10);
            Weapon sword = new Weapon("Sword", 1.0, 12);

            Warrior jamie = new Warrior("Jamie", 11, axe, 2.2, 18);
            Warrior alex = new Warrior("Alex", 12, sword, 2.1, 21);
            Warrior erik = new Warrior("Erik", 10, axe, 3.1, 22);
            Warrior samuel = new Warrior("Samuel", 9, sword, 3.5, 21);
            Warrior pontus = new Warrior("Pontus", 8, axe, 1.8, 30);
            Warrior daniel = new Warrior("Daniel", 9, sword, 3.3, 25);
            List<Warrior> warriors = new List<Warrior> { jamie, alex, erik, samuel, pontus, daniel };
            Arena arena = new Arena("Colloseum", warriors);
            Fight fight = new Fight(arena);
            FightStatistics fightStatistics = new FightStatistics(warriors);


            fight.AttackEvent += fightStatistics.AddAttack;
            fight.AttackEvent += fightStatistics.AddDamageFromFighter;
            fight.FightDoneEvent += fightStatistics.AddWinner;
            fight.FightStartEvent += shoutOutService.ShoutOut;
            fight.AttackEvent += shoutOutService.AttackShoutOut;
            fight.FightDoneEvent += shoutOutService.WinnerShoutOut;
            fight.DefendEvent += shoutOutService.DefendShoutOut;


            fight.StartFight();
            Console.WriteLine($"Damage delt: {Math.Round(fightStatistics.DamageDealt, 2)}");
            Dictionary<Warrior, double> dict = fightStatistics.DamageStatistics;
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key.Name} delt {Math.Round(pair.Value, 2)} damage");
            }

            Console.ReadLine();
        }
    }
}
