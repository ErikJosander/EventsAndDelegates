using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EventsAndDelegates
{
    public class Fight
    {
        private static Random random = new Random();
        private readonly Arena _arena;
        private static Warrior currentWarrior;
        private static Warrior defendingWarrior;
        private static List<Warrior> _attackList = new List<Warrior>();
        private static bool stillFighting = true;

        public event EventHandler<WarriorEventArgs> FightStartEvent;
        public event EventHandler<AttackEventArgs> AttackEvent;
        public event EventHandler<WarriorEventArgs> FightDoneEvent;
        public event EventHandler<AttackEventArgs> DefendEvent;

        public Fight(Arena arena)
        {
            _arena = arena;
            _attackList = _arena.Warriors;
            Helpers.Shuffle(_attackList);
            currentWarrior = _attackList[0];
        }

        public void StartFight()
        {
            _arena.Warriors.ForEach(war => OnFightStart(war));
            while (stillFighting)
            {
                defendingWarrior = AttackTarget(_attackList, currentWarrior);
                Attack(currentWarrior, defendingWarrior);
                Thread.Sleep(1000);
                currentWarrior = _attackList.TakeWhile(war => war != currentWarrior).DefaultIfEmpty(_attackList[_attackList.Count - 1]).LastOrDefault();
                if (_attackList.Count == 1) stillFighting = false;
            }
            OnFightFinnish(currentWarrior);
        }

        private void Attack(Warrior attacking, Warrior defending)
        {
            switch (CalculateFight.CheckIfHit(attacking, defending))
            {
                case (false):
                    OnDefend(attacking, defending);
                    break;
                case (true):
                    defending.CurrentHelth = defending.CurrentHelth - CalculateFight.HitPoint(attacking);
                    if (defending.CurrentHelth <= 0) _attackList.Remove(defending);
                    OnAttack(attacking, defending);
                    break;
            }
        }

        private Warrior AttackTarget(List<Warrior> warriors, Warrior attackingWarrior)
        {
            Warrior attackTarget = attackingWarrior;
            while (attackTarget == attackingWarrior)
            {
                attackTarget = warriors[random.Next(0, warriors.Count)];
            }
            return attackTarget;
        }

        protected virtual void OnFightStart(Warrior warrior)
        {
            if (FightStartEvent != null)
            {
                FightStartEvent(this, new WarriorEventArgs() { Warrior = warrior });
            }
        }

        protected virtual void OnAttack(Warrior attacker, Warrior defender)
        {
            if (AttackEvent != null)
                AttackEvent(this, new AttackEventArgs() { Attacker = attacker, Defender = defender });
        }

        protected virtual void OnFightFinnish(Warrior warrior)
        {
            if (FightDoneEvent != null)
            {
                FightDoneEvent(this, new WarriorEventArgs() { Warrior = warrior });
            }
        }


        private void OnDefend(Warrior attacker, Warrior defender)
        {
            if (DefendEvent != null)
            {
                DefendEvent(this, new AttackEventArgs() { Attacker = attacker, Defender = defender });
            }
        }
    }
}

