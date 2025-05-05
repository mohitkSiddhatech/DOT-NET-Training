namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            people.Add(new Person { Id = 1, Name = "Mohit Kirange", Title = "Mr.", Age = 23 });
            people.Add(new Person { Id = 2, Name = "Avdhut Tarwal", Title = "Prof.", Age = 40 });
            people.Add(new Person { Id = 1, Name = "Karan Patil", Title = "Major", Age = 16 });
            people.Add(new Person { Id = 2, Name = "Shubham Saykar", Title = "Colonel", Age = 90 });

            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }

        public Person() { }
        public Person(int Id, string Name, string Title, int Age)
        {
            this.Id = Id;
            this.Name = Name;
            this.Title = Title;
            this.Age = Age;
        }
    }
}