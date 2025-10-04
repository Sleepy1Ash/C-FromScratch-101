using System.Xml.Linq;

namespace CursosYEstudiantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Curso curso = new Curso { NombreCurso = "Programación C#" };

            curso.AgregarEstudiante(new Estudiante { Nombre = "Ana", Age = 20, Promedio = 9.2m });
            curso.AgregarEstudiante(new Estudiante { Nombre = "Luis", Age = 22, Promedio = 7.5m });
            curso.AgregarEstudiante(new Estudiante { Nombre = "María", Age = 19, Promedio = 8.3m });
            curso.AgregarEstudiante(new Estudiante { Nombre = "Carlos", Age = 21, Promedio = 6.8m });
            curso.AgregarEstudiante(new Estudiante { Nombre = "Sofía", Age = 20, Promedio = 8.9m });

            curso.MostrarEstudiantes();

            Console.WriteLine("\n--- Mejores Estudiantes ---");
            foreach (var est in curso.ObtenerMejoresEstudiantes())
                est.MostrarInformacion();

            Console.WriteLine("\n--- Estudiantes Reprobados ---");
            foreach (var est in curso.ObtenerEstudiantesReprobados())
                est.MostrarInformacion();

            curso.PromedioGrupo();
        }
        public abstract class Persona
        {
            public Guid Id { get; private set; } = Guid.NewGuid();
            public string Nombre { get; set; } = string.Empty;
            private int _age;
            public int Age
            {
                get { return _age; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("La edad no puede ser negativa.");
                    }
                    _age = value;
                }
            }
            public abstract void MostrarInformacion();
        }
        public class Estudiante : Persona
        {
            public decimal Promedio { get; set; }
            public override void MostrarInformacion()
            {
                Console.WriteLine($"Id: {Id}, Nombre: {Nombre}, Edad: {Age}, Promedio: {Promedio}");
            }
        }
        public class Curso
        {
            public string NombreCurso { get; set; } = string.Empty;
            public List<Estudiante> ListaEstudiantes { get; set; } = new List<Estudiante>();
            public void AgregarEstudiante(Estudiante estudiante)
            {
                ListaEstudiantes.Add(estudiante);
            }
            public void MostrarEstudiantes()
            {
                Console.WriteLine($"\nCurso: {NombreCurso}");
                foreach (var estudiante in ListaEstudiantes)
                {
                    estudiante.MostrarInformacion();
                }
            }

            // Estudiantes con promedio mayor a 8
            public List<Estudiante> ObtenerMejoresEstudiantes()
            {
                return ListaEstudiantes.Where(e => e.Promedio >= 8).ToList();
            }

            // Estudiantes con promedio reprobatorio
            public List<Estudiante> ObtenerEstudiantesReprobados()
            {
                return ListaEstudiantes.Where(e => e.Promedio < 8).ToList();
            }

            // Promedio del grupo y estudiantes con promedio mayor o igual al promedio del grupo
            public void PromedioGrupo()
            {
                if (ListaEstudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes en el curso.");
                    return;
                }

                decimal promedio = ListaEstudiantes.Average(e => e.Promedio);
                Console.WriteLine($"\nPromedio del grupo: {promedio:F2}");

                var mayores = ListaEstudiantes.Where(e => e.Promedio >= promedio).ToList();
                Console.WriteLine("Estudiantes con promedio mayor o igual al promedio del grupo:");
                foreach (var estudiante in mayores)
                {
                    estudiante.MostrarInformacion();
                }
            }
        }

    }
}
