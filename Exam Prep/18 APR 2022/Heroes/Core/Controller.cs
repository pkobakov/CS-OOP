using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Enums;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;
        public Controller() 
        { 
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        //ready
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero;
            IWeapon weapon;

            if (!heroes.Models.Any(h => h.Name == heroName)) 
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist, heroName));
            }
            if (!weapons.Models.Any(w => w.Name == weaponName)) 
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }

            hero = heroes.Models.FirstOrDefault(h => h.Name == heroName);
            weapon = weapons.Models.FirstOrDefault(w => w.Name == weaponName);

            if (hero.Weapon != null) 
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);   

            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
        }
        //ready
        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero;
            if (heroes.Models.Any( h => h.Name == name))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));
            }

            Enum.TryParse(type, out HeroType heroType);
            hero = heroType switch 
            { 
                HeroType.Knight => new Knight(name, health, armour),
                HeroType.Barbarian => new Barbarian(name, health, armour),
                _=> throw new InvalidOperationException(OutputMessages.HeroTypeIsInvalid)
            };

            heroes.Add(hero);

            if (hero.GetType().Name == nameof(Knight))
            {
                return string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }
            else
            {
                return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }
        }
        //ready
        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon;
            if (weapons.Models.Any( w => w.Name == name))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }

            Enum.TryParse(type, out WeaponType weaponType);
            weapon = weaponType switch 
            { 
              WeaponType.Mace => new Mace(name, durability),
              WeaponType.Claymore => new Claymore(name, durability),
              _=> throw new InvalidOperationException(OutputMessages.WeaponTypeIsInvalid)
            };

            weapons.Add(weapon);

            return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);



        }

        public string HeroReport()
        {
            var sb = new StringBuilder();   

            foreach (var hero in heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name)) 
            {
                string weapon = hero.Weapon == null ? "Unarmed" : hero.Weapon.Name;

                sb.AppendLine($"{ hero.GetType().Name}: { hero.Name }");
                sb.AppendLine($"--Health: { hero.Health }");
                sb.AppendLine($"--Armour: { hero.Armour }");
                sb.AppendLine($"--Weapon: { weapon }");
            }


            return sb.ToString().Trim();
        }

        public string StartBattle()
        {

            IMap map = new Map();
            var players = heroes.Models.Where(p => p.IsAlive && p.Weapon != null).ToList();
            string result = map.Fight(players);

            return result;
        }
    }
}
