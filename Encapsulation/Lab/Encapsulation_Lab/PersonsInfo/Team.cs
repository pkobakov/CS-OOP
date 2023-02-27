using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private readonly string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }


        public IReadOnlyList<Person> FirstTeam { get => firstTeam.AsReadOnly();}
        public IReadOnlyList<Person> ReserveTeam { get => reserveTeam.AsReadOnly();}


        public void AddPlayer(Person person) 
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            } 

            else
            {
              this.reserveTeam.Add(person);

            }
        
        }

        public override string ToString()
        {
            return $"First team has {FirstTeam.Count} players.{Environment.NewLine}Reserve team has {ReserveTeam.Count} players. ";
        }

    }
}
