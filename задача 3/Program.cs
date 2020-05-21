using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{//ТАРАНУХА ЯНА
//У меня к Вам большая просьба, будьте любезны, 
//вышлите мне описание создания документа ***.csv в поле программы, 
//и как его можно туда перетащить/сохранить, если он уже существует.
    /*
Переделать программу Пример использования коллекций для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
в) отсортировать список по возрасту студента;
     */

    using System.IO;
    class Student
    {
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string University { get; private set; }
        public string Faculty { get; private set; }
        public int Course { get; private set; }
        public string Department { get; private set; }
        public int Group { get; private set; }
        public string City { get; private set; }
        int Age { get; private set; }

        // Создаем конструктор
        public Student(string firstName, string lastName, string university, 
            string faculty, string department, int course, int age, int group, string city)


    public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.University = university;
            this.Faculty = faculty;
            this.Department = department;
            this.Course = course;
            this.Age = age;
            this.Group = group;
            this.City = city;
        }
        public override string ToString()
        {
            return String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}{7,15}{8,15}",
                FirstName, LastName, University, Faculty, Department, Age, Course, Group, City);
        }
        delegate bool Is(Student s);
    class Program
    {
        static int MyDelegat(Student st1, Student st2) // Создаем метод для сравнения для экземпляров
        {
                if (st1.Course > st2.Course) return 1;
                if (st1.Course > st2.Course) return -1;
                return 0;
                //return String.Compare(st1.firstName, st2.firstName); // Сравниваем две строки
        }
            static bool IsAgeBigger18(Student student)
            {
                return student.Age == 18;
            }
            static int CountStudents(List<Stident> studens, Is IS)
            {
                int count = 0;
                foreach(Student student in studens)
                {
                    if (IS(student)) count++;
                }
                return count;
            }
        static void Main(string[] args)
        {
            int course4 = 0;
            int course5 = 0;
            List<Student> list = new List<Student>();     // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");//не получается создать ***.csv
            while (!sr.EndOfStream) /////////
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    Student t;
                    t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                        list.Add(t);
                    if (t.Course == 5) course5++; 
                    if (t.Course == 4) course4++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
/*!!!!*/            Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
                Console.WindowWidth = 160;
                Console.BufferWidth = 160;
            //list.Sort(new Comparison<Student>(MyDelegat));
                list.Sort(Comparer);
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Четвертый курс:{0}", course4);
            Console.WriteLine("Пятый курс:{0}", course5);
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}



