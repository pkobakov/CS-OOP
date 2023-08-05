using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        
        public string Fight(ICollection<IHero> players)
        {
            ICollection<IHero> knights = new List<IHero>();

            ICollection<IHero> barbarians = new List<IHero>();

            foreach (var hero in players.ToList().AsReadOnly()) 
            {
                if (hero.GetType() == typeof(Knight))
                {
                    knights.Add(hero);
                }

                else if (hero.GetType() == typeof(Barbarian))
                {
                    barbarians.Add(hero);
                }
            }

            bool itsKnightTurn = true;

            while (knights.Any(h => h.IsAlive) && barbarians.Any(h => h.IsAlive))
            {
                if (itsKnightTurn) 
                {
                    TakeFight(knights, barbarians);
                }

                else 
                {
                    TakeFight(barbarians, knights);
                }

                itsKnightTurn = !itsKnightTurn;
            }

            if (knights.Any(h => h.IsAlive))
            {
                int knightCasualties = knights.Where(h => !h.IsAlive).Count();
                return string.Format(OutputMessages.MapFightKnightsWin, knightCasualties );
            }

            else
            {
                int barbarianCasualties = barbarians.Where(h => !h.IsAlive).Count();
                return string.Format(OutputMessages.MapFigthBarbariansWin, barbarianCasualties);
            }

          
        }

        private void TakeFight(ICollection<IHero> attackers, ICollection<IHero> defenders) 
        {
            foreach (var attacker in attackers.Where(h => h.IsAlive))
            {
                foreach (var defender in defenders.Where(h => h.IsAlive))
                {
                    defender.TakeDamage(attacker.Weapon.DoDamage());
                  
                }
            }
        }
    }
}
