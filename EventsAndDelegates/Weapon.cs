namespace EventsAndDelegates
{
    public class Weapon
    {
        public Weapon(string name, double damage, int hitRate)
        {
            Name = name;
            Damage = damage;
            HitRate = hitRate;
        }
        public string Name { get; set; }
        public double Damage { get; set; }
        public int HitRate { get; set; }
    }
}
