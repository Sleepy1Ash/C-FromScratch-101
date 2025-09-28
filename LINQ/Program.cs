namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // LINQ Query Syntax
            var evenNumbersQuery = from num in numbers
                                   where num % 2 == 0
                                   select num;
            foreach(int num in evenNumbersQuery)
            {
                Console.WriteLine(num);
            }
            // LINQ Method Syntax
            var evenNumbersMethod = numbers.Where(num => num % 2 == 0);
            Console.WriteLine("Even Numbers using Method Syntax:");
            foreach (int num in evenNumbersMethod)
            {
                Console.WriteLine(num);
            }

            List<Student> students = new List<Student>
            {
                new Student ("Alice", 90 ),
                new Student ("Bob", 85),
                new Student ("Charlie", 95),
                new Student ("David", 88)
            };
            var orderedStudents = students.OrderBy(s => s.Name).ThenBy(s=>s.Age).ToList();
            var oderedStudentsDesc = students.OrderByDescending(s => s.Name).ThenByDescending(s => s.Age).ToList();
            var groupedStudents = students.GroupBy(s => s.Age).ToList();
            Console.WriteLine("\n\n\n\nStudents grouped by age:\n");
            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"Age Group: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($" - {student.Name}, Age: {student.Age}");
                }
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
