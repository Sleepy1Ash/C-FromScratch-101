namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Person person1 = new Person("Bob1", 30, "Ally", null, new DateTime(1933,1,1));
            Person person2 = new Person("Bob2", 31, "Ally", null, new DateTime(1933, 1, 1));
            Person person3 = new Person("Bob3", 32, "Ally", null, new DateTime(1933, 1, 1));
            person1.Introduce();
            person2.Introduce();
            person3.Introduce();
            */
            Employee employee = new Employee("Juan", 28, "Cholo", 1, new DateTime(1985,1,1),"Firefighter", 50000);
            employee.Introduce();

        }
        public class Person
        {
            //Auto-implemented properties
            public string Name { get; set; } = string.Empty;
            //Full property with backing field and validation
            private int _age;
            public int Age
            {
                get { return _age; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Age cannot be negative.");
                    }
                    _age = value;
                }
            }
            //Property with default value
            public string Nickname { get; set; } = "No nickname";
            //Nullable property
            public int? Couple { get; set; } = null;
            // Read-only property
            public readonly DateTime BirthDate = DateTime.Now;
            //Static property
            public static int Population { get; private set; } = 0;
            // Constructor
            public Person()
            {
                if(this.Name.Length == 0)
                {
                    this.Name = "Unknown";
                }
                Population++;
            }
            public virtual void Introduce()
            {
                Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
            }

            public Person(string name, int age, string nickname, int? couple, DateTime birthDate):this()
            {
                Name = name;
                Age = age;
                Nickname = nickname;
                Couple = couple;
                BirthDate = birthDate;
            }
        }
        public class Employee : Person
        {
            public string Position { get; set; } = "Unemployed";
            public decimal Salary { get; set; } = 0;
            public Employee(string name, int age, string nickname, int? couple, DateTime birthDate, string position, decimal salary)
                : base(name, age, nickname, couple, birthDate)
            {
                Position = position;
                if (salary < 420)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                }
                else
                {
                    Salary = salary;
                }
            }
            public override void Introduce()
            {
                base.Introduce();
                Console.WriteLine($"I work as a {Position} and my salary is {Salary}.");
            }
        }
    }
    
}
