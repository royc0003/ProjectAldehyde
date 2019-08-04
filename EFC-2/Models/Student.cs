using System;

namespace NetCoreRESTTemplate.Models
{
    public class Student
    {
        public Guid Guid { get; }
        public string Name { get; }
        public int Age { get; }

        public Student(Guid guid, string name, int age)
        {
            this.Guid = guid;
            this.Name = name;
            this.Age = age;
        }
        
        
    }
}