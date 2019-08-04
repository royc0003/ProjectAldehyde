using System;
using System.Collections.Generic;
using System.Linq;
using NetCoreRESTTemplate.Models;

namespace NetCoreRESTTemplate.Repository
{
    public class StudentRepository
    {
        private Dictionary<string, StudentDataModel>_dictionary;

        public StudentRepository()
        {
            _dictionary = new Dictionary<string, StudentDataModel>();
            
        }

        public Student GetStudent(Guid guid)
        { 
            return ToStudent(_dictionary[guid.ToString()]);
        }


        public IEnumerable<Student> GetAllStudent()
        {
            return _dictionary.Values
                .Select(ToStudent);
        }

        

        public Student AddStudent(StudentRequest studentRequest)
        {
            Guid guid = Guid.NewGuid();
            Student student = new Student(guid, studentRequest.Name, studentRequest.Age);

            _dictionary[guid.ToString()] = ToStudentDataModel(student);
            return student;
        }
        
        

        private Student ToStudent(StudentDataModel studentDataModel)
        {
            return new Student(
                Guid.Parse(studentDataModel.Guid), 
                studentDataModel.Name,
                int.Parse(studentDataModel.Age));
        }

        private StudentDataModel ToStudentDataModel(Student student)
        {
            return new StudentDataModel(
                student.Guid.ToString(),
                student.Name,
                student.Age.ToString());
                
        }

        public Student UpdateStudent(Student newStudent)
        {
            _dictionary[newStudent.Guid.ToString()] = ToStudentDataModel(newStudent);
            return newStudent;
        }

        public void DeleteStudent(Guid deleteStudent)
        {
            _dictionary.Remove(deleteStudent.ToString());

        }
        
    }
}
