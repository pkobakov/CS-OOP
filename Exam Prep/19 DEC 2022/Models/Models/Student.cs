using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models.Models
{
    public class Student : IStudent
    {
        
        private string firstName;
        private string lastName;
        private ICollection<int> coveredExams;

        public Student(int studentId, string firstName, string lastName)
        {
            
            this.Id = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;

            this.coveredExams = new List<int>();
        }
        public int Id { get; private set; }

        public string FirstName 
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                } 
                firstName = value;
            }
        }

        public string LastName 
        {
            get => lastName;
            private set 
            { 
                if(string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        
        }

        public IReadOnlyCollection<int> CoveredExams => this.coveredExams.ToList().AsReadOnly();

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            this.coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university; 
        }
    }
}
