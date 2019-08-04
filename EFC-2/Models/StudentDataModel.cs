namespace NetCoreRESTTemplate.Models
{
    public class StudentDataModel
    {
        public string Guid { get; }
        public string Name { get; }
        public string Age { get; }

        public StudentDataModel(string guid, string name, string age)
        {
            this.Guid = guid;
            this.Name = name;
            this.Age = age;
        }
    }
}