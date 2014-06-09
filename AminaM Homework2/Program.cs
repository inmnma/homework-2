using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AminaM_Homework2
{

    class Person
    {

        protected string name, lastName; //name and last name
        private static int count = 0; //static field counter
        static string copyright = "Amina Mavric";
        //destructor, used to destruct instance of some class, it can only be used for class, and cannot be inherited
        ~Person() { count--; }
        //constructor, to create instance, this one has two arguments
        public Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            count++;
        }

        public string getPersonInfo() { return name + ", " + lastName; }
        //count property and it should get elements that are contained in it
        public int Count
        {
            get { return count; }
        }

    };

    class Student : Person, IComparable<Student>
    {

        //constructor
        public Student(string name, string lastName, string email)
            : base(name, lastName)
        {
            this.email = email;
        }

        //constructor
        public Student(string name, string lastName, string email_, string location_)
            : base(name, lastName)
        {
            email = email_;
            Location = location_;
        }

        //empty constructor
        public Student()
            : base("Amina", "Mavric") //call base constructor

        { }

        ~Student() { }

        public string email { get; set; }

        private string location;

        //property location, actually sows location or points it out
        public string Location
        {
            get
            {

                if (location == "SA") return "Sarajevo";
                else
                    if (location == "TZ") return "Tuzla";
                    else
                        return "Other";
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo") location = "SA";
                else
                    if (value == "TZ" || value.Equals("tuzla", StringComparison.OrdinalIgnoreCase)) location = "TZ";
                    else
                        location = "NA";

            }

        }

        public bool setName(string input)
        {

            //check length, it returns fale or shows error if the name contains less than two characters
            if (input.Length < 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;

            }



            //if not upper case, using if implementation and name must start with first capital
            //letter, otherwise it will not work, it will be 'false', error
            if (!char.IsUpper(input.First()))
            {
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }

            //check input string for non-letter, using if implemetation,
            //so if name have anything else but letters it will return false,
            //meaning that there will be an error or it will not work
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Name can only have letters");
                    return false;
                }
            }

            //asign input
            name = input;
            return true;

        }

        //overriden method ToString
        public override string ToString()
        {

            return getStudentInfo();
        }


        public string getStudentInfo()
        {
            string studentinfo = getPersonInfo();
            studentinfo = studentinfo + email + ", " + Location;
            return studentinfo;
        }


        // I used the IComparable implementation here
        public int CompareTo(Student obj)
        {

            return name.CompareTo(obj.name);

        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stList = new List<Student>(){
            
            new Student("Adnan", "Duric", "adnanduric@hotmail.com","Tuzla"),
            new Student("Amina", "Suljic",  "aminas@hotmail.com", "Zenica"),
            new Student("Lejla", "Dzeko",  "lejladz@hotmail.com", "Sarajevo"),
            new Student("Benjamin", "mujic", "benjamin@gmail.com", "Tuzla"),
            new Student("Samir", "Kamenjasevic", "kamensamir@yahoo.com", "Olovo"),
            new Student("Danijela", "Kraljevic", "danka@gmail.com",  "Sarajevo"),
            new Student("Edina", "Kocan", "edinako@hotmail.com", "Sarajevo")
            };

            stList.Sort();

            for (int i = 0; i < stList.Count; i++)
            {
                Console.WriteLine(stList[i].ToString());
            }


            Console.WriteLine("\nPress Enter to Exit...");
            Console.ReadKey();
        }
    }
}
