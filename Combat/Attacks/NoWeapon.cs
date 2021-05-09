using System;
using System.Collections.Generic;
using System.Text;
using Combat.Interfaces;

namespace Combat.Attacks
{
    class NoWeapon
    {

        public Attack GetPreparation()
        {
            return new Attack()
            {
                Name = "preparation",
                Element = Element.Physical,
                Damage = 0,
            };
        }

        public IAttack GetPunch()
        {
            return new Attack
            {
                Name = "punch",
                Element = Element.Physical,
                Damage = 5,
            };
        }

        public Attack GetPowerFist()
        {
            return new Attack()
            {
                Name = "power fist",
                Element = Element.Physical,
                Damage = 40,
            };
        }

    }
}
