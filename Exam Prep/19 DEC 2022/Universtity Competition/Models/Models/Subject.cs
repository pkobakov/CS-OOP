using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.Models
{
    public abstract class Subject : ISubject
    {
        private string subjectName;
        public Subject(int subjectId, string subjectName, double subjectRate )
        {
            this.Id = subjectId;
            this.Name = subjectName;
            this.Rate = subjectRate;
        }
        public int Id { get; private set; }

        public string Name 
        {  
            get => subjectName;
            private set
            { 
                if ( string.IsNullOrWhiteSpace(value) ) 
                { 
                    throw new ArgumentException (ExceptionMessages.NameNullOrWhitespace);
                }

                subjectName = value;
            }
        }

        public double Rate { get; private set; }
    }
}
