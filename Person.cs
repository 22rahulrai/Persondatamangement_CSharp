using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review1april
{
    public class Person
    {
        public  string Name { get; set; }
        public  int Age { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age + " Salary: " + Salary;
        }

    }

    

}
