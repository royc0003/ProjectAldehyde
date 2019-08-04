namespace NetCoreRESTTemplate.Models
{
    public class StudentRequest
    {
        public string Name { get; }
        public int Age { get; }

        public StudentRequest(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}