using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace review1april
{   
    public class Personmethods : Methods
    {
        public List<Person> plist = new List<Person>();   
        public string Path= "C:\\Users\\raira\\Desktop\\Compunnel\\review1april\\person.csv";
        public void Add(string name, int age, int salary)
        {
            // Read existing data from the file to check for duplicates
            if (File.Exists(Path))
            {
                var existinglines = File.ReadAllLines(Path);
                foreach (var line in existinglines)
                {
                    var part = line.Split(',');
                    if (part.Length == 3 && part[0] == name)
                    {
                        Console.WriteLine("User already exists");
                        return;
                    }
                }
            }

            plist.Add(new Person() { Name = name, Age = age, Salary = salary });
            using (StreamWriter sw = new StreamWriter(Path,append:true))
            {
                sw.WriteLine(name + "," + age + "," + salary);
            }
            Console.WriteLine("Data added successfully.");
        }


        public void Search(string nametofind)
        {
            string[] lines = File.ReadAllLines(Path);
            bool found = false;
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0].Equals(nametofind,StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Name: " + parts[0] + " Age: " + parts[1] + " Salary: " + parts[2]);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("User not found. Enter the details to add");
                Console.WriteLine("Enter age for new user");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter salary for new user");
                int salary = int.Parse(Console.ReadLine());
                using (StreamWriter sw = new StreamWriter(Path, append: true))
                {
                    //sw.WriteLine($"{nametofind},{age},{salary}");
                    sw.WriteLine(nametofind + "," + age + "," + salary);
                }
                Console.WriteLine("data added successfully");
            }
        }
        public void Sort()
        {
            //string[] lines = File.ReadAllLines(Path);
            //var sortedLines = lines
            //    .Select(line => line.Split(','))
            //    .OrderBy(parts => int.Parse(parts[1])) 
            //    .Select(parts => string.Join(',', parts));

            //Console.WriteLine("Data sorted by age successfully");
            //foreach (var values in lines)
            //{
            //    Console.WriteLine($"Name: {values[0]}, Age: {values[1]}, Salary: {values[2]}");
            //}

            //string path = "C:\\Users\\raira\\Desktop\\Compunnel\\review1april\\Datasorted.txt";
            //using (FileStream fs = File.Create(path))
            //{
            //    fs.Close();
            //    File.AppendAllLines(path, sortedLines);
            //}
            plist.Sort((x, y) => x.Age.CompareTo(y.Age));
            using(StreamWriter sw=new StreamWriter(Path))
            {
                foreach(var person in plist)
                {
                    sw.WriteLine(person.Name + "," + person.Age + "," + person.Salary);
                }
                Console.WriteLine("data added to txtfile");
            }

            //txt file data
            using(StreamReader sr = new StreamReader(Path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    Console.WriteLine($"Name: {values[0]}, Age: {values[1]}, Salary: {values[2]}");
                }
            }
            Console.WriteLine("data sorted by age");
        }


        public void Sortbynameage()
        {
            string[] lines = File.ReadAllLines("person.csv");
            var sortedLines = lines
                .Select(line => line.Split(','))
                .OrderBy(parts => int.Parse(parts[0]))
                .Select(parts => string.Join(',', parts));
        }

        public void Printdata()
        {
            using(StreamReader sr = new StreamReader(Path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    Console.WriteLine($"Name:{values[0]}, Age:{values[1]}, Salary: {values[2]}");
                }
            }

        }
    }
}
