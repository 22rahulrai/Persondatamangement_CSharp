using System.Xml.Linq;

namespace review1april
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Switchmethods();
        }

        
        static void Switchmethods()
        {
            Person p1 = new Person() { Name = "jay", Age = 10, Salary = 1000 };
            Person p2 = new Person() { Name = "ram", Age = 20, Salary = 2000 };
            Person p3 = new Person() { Name = "shah", Age = 30, Salary = 3000 };
            
            
            Personmethods personmethods = new Personmethods();
            personmethods.plist.Add(p1);
            personmethods.plist.Add(p2);
            personmethods.plist.Add(p3);

            personmethods.Add(p1.Name, p1.Age, p1.Salary);
            personmethods.Add(p2.Name, p2.Age, p2.Salary);
            personmethods.Add(p3.Name, p3.Age, p3.Salary);

            while (true)
            {
                Console.WriteLine("\n1. Add data \n2. Search user by name\n3. Sort by age \n5. Print data \n6. Exit loop");
                Console.WriteLine("Enter the value");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name");
                        string name= Console.ReadLine();
                        Console.WriteLine("Enter age");
                        int age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter salary");
                        int salary = int.Parse(Console.ReadLine());
                        personmethods.Add(name, age, salary);
                        break;

                    case 2:
                        Console.WriteLine("Enter the name to search");
                        string findname = Console.ReadLine();
                        personmethods.Search(findname);
                        break;
                    
                    case 3:
                        personmethods.Sort();
                        break;
                    
                    case 5:
                        personmethods.Printdata();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 6.");
                        break;
                }
            }
            
        }
    }
}


//name id age salary
//.cs file


//user search by name
//if not found add 


//sort by age
//and append it it inot .txt

//sort by name and age both