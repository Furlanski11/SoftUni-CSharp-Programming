using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;
        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        private int studentsCount = 0;
        private int subjectsCount = 0;
        private int universitiesCount = 0;

        public string AddStudent(string firstName, string lastName)
        {

            if (students.FindByName(firstName) != null)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName);
            }

            IStudent student = new Student(studentsCount + 1, firstName, lastName);
            studentsCount++;
            students.AddModel(student);
            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);

        }

        public string AddSubject(string subjectName, string subjectType)
        {
            string[] categories = { "TechnicalSubject", "HumanitySubject", "EconomicalSubject" };
            string categoryMatch = categories.FirstOrDefault(x => x == subjectType);
            if (categoryMatch == null)
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);

            }
            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject);

            }
            switch (categoryMatch)
            {
                case "TechnicalSubject":
                    ISubject technicalSubject = new TechnicalSubject(subjectsCount + 1, subjectName);
                    subjects.AddModel(technicalSubject);
                    subjectsCount++;
                    break;
                case "HumanitySubject":
                    ISubject humanitySubject = new HumanitySubject(subjectsCount + 1, subjectName);
                    subjects.AddModel(humanitySubject);
                    subjectsCount++;
                    break;
                case "EconomicalSubject":
                    ISubject economicalSubject = new EconomicalSubject(subjectsCount + 1, subjectName);
                    subjects.AddModel(economicalSubject);
                    subjectsCount++;
                    break;
            }
            return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            List<int> reqSubs = new();
            foreach (var subject in requiredSubjects)
            {
                ISubject foundSubject = subjects.FindByName(subject);
                if(foundSubject != null)
                {
                    reqSubs.Add(foundSubject.Id);
                }
            }
            IUniversity university = new University(universitiesCount + 1, universityName, category, capacity, reqSubs);
            if(universitiesCount == 0)
            {
                universities.AddModel(university);
                universitiesCount++;
                return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
            }
            if (universities.FindByName(universityName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            //IUniversity university = new University(universitiesCount + 1, universityName, category, capacity, reqSubs);
            universities.AddModel(university);
            universitiesCount++;
            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] studentNames = studentName.Split(" ");
            IUniversity university = universities.FindByName(universityName);
            IStudent student = students.FindByName(studentName);
            if (students.FindByName(studentName) == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, studentNames[0], studentNames[1]);

            }
            if(university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            if(student.CoveredExams != university.RequiredSubjects)
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            if(student.University == university)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, studentNames[0], studentNames[1], universityName);
            }
            student.JoinUniversity(university);
            return String.Format(OutputMessages.StudentSuccessfullyJoined, studentNames[0], studentNames[1], universityName);

        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            if (subjects.FindById(subjectId) == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);
            if (student.CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }
            student.CoverExam(subject);
            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);

        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            int admittedStudents = CountStudentsInUni(university);
            StringBuilder sb = new();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {admittedStudents}");
            sb.AppendLine($"University vacancy: {university.Capacity - admittedStudents}");
            return sb.ToString().Trim();
        }
        private int CountStudentsInUni(IUniversity university)
        {
            int count = 0;
            foreach (var student in students.Models)
            {
                if (student.University?.Id == university.Id)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
