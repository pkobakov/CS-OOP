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
            List<IHero> attackers = new List<IHero>();
            List<IHero> defenders = new List<IHero>();

            foreach (IHero hero in players) 
            {
                if (hero.GetType() == typeof(Knight)) 
                { 
                    attackers.Add(hero);
                }
                else
                {
                    defenders.Add(hero);
                }
            }

            bool itsKnightsTurn = true;

            while (attackers.Any( h => h.IsAlive) && defenders.Any( h => h.IsAlive)) 
            { 
                if (itsKnightsTurn) 
                {
                    TakeFight(attackers, defenders);
                }

                else 
                {
                    TakeFight(defenders, attackers);
                }

                itsKnightsTurn = !itsKnightsTurn;
            }

            if (attackers.Any(a => a.IsAlive))
            {
                return $"The knights took {attackers.Where( a => !a.IsAlive).Count()} casualties but won the battle.";
            }

            else 
            {
                return $"The barbarians took {defenders.Where( d => !d.IsAlive).Count()} casualties but won the battle.";
            }

        }

        private void TakeFight( List<IHero> attackers, List<IHero> defenders) 
        { 
             foreach (IHero attacker in attackers.Where( h => h.IsAlive)) 
             {
                foreach (IHero defender in defenders.Where(h => h.IsAlive)) 
                {

                    defender.TakeDamage(attacker.Weapon.DoDamage());
                } 
             }
        }
    }
}
