using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Models;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Repositories.Models;
using UniversityCompetition.Utilities.Enums;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private int studentId = 1;
        private int subjectId = 1;
        private int universityId = 1;
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }
        //ready
        public string AddStudent(string firstName, string lastName)
        {

            if (students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(studentId, firstName, lastName);
            studentId++;

            students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }
        //ready
        public string AddSubject(string subjectName, string subjectType)
        {
            var suportedSubjects = new List<string>
            {
                nameof(SubjectType.EconomicalSubject),
                nameof(SubjectType.TechnicalSubject),
                nameof(SubjectType.HumanitySubject)
            };


            if (!suportedSubjects.Any(s => s == subjectType))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjects.Models.Any(s => s.Name == subjectName))
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            Enum.TryParse(subjectType, out SubjectType type);
            ISubject subject = type switch
            {
                SubjectType.TechnicalSubject => new TechnicalSubject(subjectId, subjectName),
                SubjectType.EconomicalSubject => new EconomicalSubject(subjectId, subjectName),
                SubjectType.HumanitySubject => new HumanitySubject(subjectId, subjectName),
                _ => null
            };

            subjects.AddModel(subject);
            subjectId++;
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);



        }
        //ready
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.Models.Any(u => u.Name == universityName))
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }


            List<int> requiredIds = new List<int>();
            foreach (var subject in subjects.Models)
            {
                if (requiredSubjects.Contains(subject.Name))
                {
                    requiredIds.Add(subject.Id);

                }
            }

            IUniversity university = new University(universityId, universityName, category, capacity, requiredIds);
            universities.AddModel(university);
            universityId++;

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);

        }
        //ready
        public string ApplyToUniversity(string studentName, string universityName)
        {
            IUniversity university;
            IStudent student;
            var fullName = studentName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var firstName = fullName[0];
            var lastName = fullName[1];

            if (!students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if (!universities.Models.Any(u => u.Name == universityName))
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }


            university = universities.Models.FirstOrDefault(u => u.Name == universityName);
            student = students.Models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            foreach (var examId in student.CoveredExams)
            {
                if (!university.RequiredSubjects.Any(x => x == examId) || university.RequiredSubjects.Count > student.CoveredExams.Count)
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (student.University != null)
            {
                if (student.University.Name == universityName)
                {
                    return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
                }
            }


            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!students.Models.Any(s => s.Id == studentId))
            {
                return OutputMessages.InvalidStudentId;
            }

            if (!subjects.Models.Any(s => s.Id == subjectId))
            {
                return OutputMessages.InvalidSubjectId;
            }

            var student = students.Models.FirstOrDefault(s => s.Id == studentId);
            var subject = subjects.Models.FirstOrDefault(s => s.Id == subjectId);
            if (student.CoveredExams.Any(e => e == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            var sb = new StringBuilder();
            IUniversity university = universities.FindById(universityId);
            List<IStudent> universityStudents = new List<IStudent>();

            foreach (var student in students.Models)
            {
                if (student.University != null)
                {
                    if (student.University.Id == universityId)
                    {
                        universityStudents.Add(student);
                    }

                }
            }


            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {universityStudents.Count}");
            sb.AppendLine($"University vacancy: {university.Capacity - universityStudents.Count}");

            return sb.ToString().Trim();
        }
    }
}
