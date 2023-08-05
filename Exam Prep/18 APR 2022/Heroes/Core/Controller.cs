using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;
        public Controller() 
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero; 
            
            if (this.heroes.Models.Any(x => x.Name == name)) 
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));
            }

            hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _=> throw new InvalidOperationException(OutputMessages.HeroTypeIsInvalid)
            };

            this.heroes.Add(hero);

            if (hero.GetType() == typeof(Knight))
            {
                return string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }

            else
            {
                return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }

        }
        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon;

            if (this.weapons.Models.Any(x => x.Name == name))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }

            weapon = type switch 
            {
                nameof(Claymore) => new Claymore(name, durability), 
                nameof(Mace) => new Mace(name,durability),
                _=> throw new InvalidOperationException(OutputMessages.WeaponTypeIsInvalid)
            };

            this.weapons.Add(weapon);
            return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);
            IWeapon weapon = this.weapons.FindByName(weaponName);

            if (hero == null) 
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist, heroName));
            }

            if (weapon == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));  
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);

            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
        }

        public string StartBattle()
        {
           IMap map = new Map();

           return map.Fight(this.heroes.Models.Where(x => x.Weapon != null && x.IsAlive).ToList());

        }


        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder(); 
            foreach (IHero hero in this.heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();   
        }

    }
}
