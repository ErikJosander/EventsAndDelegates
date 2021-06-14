using System;
using System.ComponentModel.DataAnnotations;

namespace EventsAndDelegates
{
    public class Warrior
    {
        private double _currentHealth;
        public Warrior()
        {

        }
        public Warrior(string name, double health, Weapon weapon, double hitDamage, int blockChance)
        {
            Name = name;
            Health = health;
            Weapon = weapon;
            HitDamage = hitDamage;
            BlockChance = blockChance;
            CurrentHelth = Health;
        }

        [Required]
        public string Name { get; set; } = "Init";
        [Required]
        public double Health { get; set; } = 5.0;

        public Weapon Weapon { get; set; }
        public double HitDamage { get; set; } = 1.0;
        [Range(0, 1)]

        public int Fitness { get; set; } = 1;
        public int BlockChance { get; set; } = 10;
        public double CurrentHelth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
                if (_currentHealth < 0) _currentHealth = 0;
            }
        }
    }
}
