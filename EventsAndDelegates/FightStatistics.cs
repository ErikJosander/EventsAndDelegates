using System;
using System.Collections.Generic;

namespace EventsAndDelegates
{
    public class FightStatistics
    {
        public FightStatistics(List<Warrior> warriors)
        {
            Warriors = warriors;
            Warriors.ForEach(war => DamageStatistics.Add(war, 0));
        }
        public DateTime FightDate { get; set; } = DateTime.UtcNow;
        public List<Warrior> Warriors { get; set; }
        public double DamageDealt { get; set; }
        public Warrior Winner { get; set; } = new Warrior();
        public Dictionary<Warrior, double> DamageStatistics { get; set; } = new Dictionary<Warrior, double>();
        public void AddAttack(object sender, AttackEventArgs e)
        {
            DamageDealt += CalculateFight.HitPoint(e.Attacker);
        }
        public void AddWinner(object sender, WarriorEventArgs e)
        {
            Winner = e.Warrior;
        }
        public void AddDamageFromFighter(object sender, AttackEventArgs e)
        {
            DamageStatistics[e.Attacker] += CalculateFight.HitPoint(e.Attacker);
        }
    }
}
