using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character 
    {
		// TODO: Implement the rest of the class.

		private string name;
		private double health;
		private double armor;
		double abilityPoints;
		

		protected Character(string name, double health, double armor, double abilityPoints, IBag bag) 
		{
		    this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.Armor = armor;
			this.BaseArmor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
		    
		}

        public string Name  
		{ 
			get => name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				
				}
				name = value;
			}
		}
		public double BaseHealth { get; private set; }
		public double Health 
		{ 
			get => health;
			set 
			{
				if (value > 0 && value <= this.BaseHealth)
				{
			          health = value;

				}
			} 
		}
		public double BaseArmor  { get; private set; }
        public double Armor 
		{ 
			get => armor;
			private set 
			{
				if (value > 0)
				{
			     	armor = value;	

				}
			}
		}
		public double AbilityPoints { get => abilityPoints; private set { abilityPoints = value; } }
		public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints) 
		{ 
		    this.EnsureAlive();

			if (hitPoints <= this.Armor)
			{
				this.Armor -= hitPoints;
			}

			else
			{
			    hitPoints-= this.Armor;
				this.Armor = 0;

				if (hitPoints < this.Health)
				{
					this.Health -= hitPoints;
				}

				else 
				{ 
				    this.Health = 0;
					this.IsAlive = false;
				}
			}

		}

		public void UseItem(Item item) 
		{
			EnsureAlive();
			item.AffectCharacter(this);
		}
	}
}