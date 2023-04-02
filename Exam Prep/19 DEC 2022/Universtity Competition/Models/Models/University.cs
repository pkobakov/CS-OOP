using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.Models
{
    public class University : IUniversity
    {
        private string name;
        private string category;
        private int capacity;
        public University
        (
         int universityId, 
         string universityName,
         string category,
         int capacity,
         ICollection<int> requiredSubjects
        )
        { 
            this.Id = universityId;
            this.Name = universityName;
            this.Category = category;
            this.Capacity = capacity;
            this.RequiredSubjects = requiredSubjects.ToList();
        }
        public int Id { get; private set; }

        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.name = value;
            }
        }

        public string Category 
        { 
            get => category;
            private set 
            {
                if (value.ToLower() != "technical" && value.ToLower() != "economical" && value.ToLower() != "humanity")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }  
                this.category = value;
            }
        }

        public int Capacity 
        {
            get => capacity;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects { get; private set; }
    }
}
