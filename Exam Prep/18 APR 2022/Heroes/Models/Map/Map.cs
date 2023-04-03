using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = new List<IHero>();
            List<IHero> barbarians = new List<IHero>();
            foreach (IHero hero in players)
            {
                if (hero.GetType() == typeof(Knight))
                    knights.Add(hero);
                else barbarians.Add(hero);
            }
            bool itIsKnightsTurn = true;
            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                if (itIsKnightsTurn)
                    TakeFight(knights, barbarians);
                else
                    TakeFight(barbarians, knights);

                itIsKnightsTurn = !itIsKnightsTurn;
            }

            if (knights.Any(a => a.IsAlive))
            {
                return $"The knights took {knights.Where( a => !a.IsAlive).Count()} casualties but won the battle.";
            }

            else 
            {
                return $"The barbarians took {barbarians.Where( d => !d.IsAlive).Count()} casualties but won the battle.";
            }

        }

        private void TakeFight( List<IHero> attackers, List<IHero> defenders) 
        {
            foreach (IHero attacker in attackers.Where(x => x.IsAlive))
                foreach (IHero defender in defenders.Where(x => x.IsAlive))
                    defender.TakeDamage(attacker.Weapon.DoDamage());
        }
    }
}
