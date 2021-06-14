using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAndDelegates
{
    public class Arena
    {
        public Arena(string name, List<Warrior> warriors)
        {
            Name = name;
            Warriors = warriors;
        }
        public string Name { get; set; }
        public List<Warrior> Warriors { get; set; }
    }
}
