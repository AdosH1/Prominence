using System;
using System.Collections.Generic;
using System.Text;
using Combat.Interfaces;

namespace Combat.StatusEffects
{
    public class Empower : IStatusEffect
    {
        public ICombatEntity Source { get; set; }
        public ICombatEntity Target { get; set; }
        public string Name
        {
            get { return "empower"; }
        }
        public double Duration { get; set; } = 3;

        public void Apply()
        {
            //Console.WriteLine(Target.Name + " becomes empowered.");
            Target.Strength += 0.5;
            Target.Magic += 0.5;
            Target.Speed += 0.5;
        }

        public void PrePlayerCombat() { }

        public void Cleanup()
        {
            Console.WriteLine(Target.Name + "'s empower wears off.");
            Target.Strength -= 0.5;
            Target.Magic -= 0.5;
            Target.Speed -= 0.5;
        }

        public void StartOfTurn() { }

        public void PreEnemyCombat() { }

        public void EndOfTurn() { }
    }

    public class Regenerate : IStatusEffect
    {
        public ICombatEntity Source { get; set; }
        public ICombatEntity Target { get; set; }
        public string Name
        {
            get { return "regeneration"; }
        }
        public double Duration { get; set; } = 3;

        public void Apply() { /*Console.WriteLine(Target.Name + " regenerates.");*/ }

        public void PrePlayerCombat()
        {
            var healAmount = 7 + Source.Magic;
            Console.WriteLine(Target.Name + " heals for " + healAmount.ToString() + ".");

            if (Target.Health > Target.MaxHealth)
                return;
            Target.Health += healAmount;
            if (Target.Health > Target.MaxHealth)
                Target.Health = Target.MaxHealth;
        }

        public void Cleanup() { Console.WriteLine(Target.Name + "'s regeneration wears off."); }

        public void StartOfTurn() { }

        public void PreEnemyCombat() { }

        public void EndOfTurn() { }
    }

    public class Barkskin : IStatusEffect
    {
        public ICombatEntity Source { get; set; }
        public ICombatEntity Target { get; set; }
        public string Name
        {
            get { return "barkskin"; }
        }
        public double Duration { get; set; } = 2;

        public void Apply()
        {
            Console.WriteLine(Target.Name + "'s skin becomes hard as bark.");
            Target.Resistances[Element.Physical] -= 0.5;
        }

        public void PrePlayerCombat() { }

        public void Cleanup()
        {
            Console.WriteLine(Target.Name + "'s barkskin wears off.");
            Target.Resistances[Element.Physical] += 0.5;
        }


        public void StartOfTurn() { }

        public void PreEnemyCombat() { }

        public void EndOfTurn() {  }

    }
}
