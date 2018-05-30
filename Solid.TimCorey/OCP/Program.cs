﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    class Program
    {

        static void Main(string[] args)
        {
            List<PersonModel> applicants = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Kenji", LastName = "Obara" },
                new PersonModel{ FirstName = "Sue", LastName = "Storm" },
                new PersonModel{ FirstName = "Nancy", LastName = "Roman" },
            };

            List<EmployeeModel> employees = new List<EmployeeModel>();
            Accounts accountProcessor = new Accounts();

            foreach (var person in applicants)
            {
                employees.Add(accountProcessor.Create(person));
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}: { emp.EmailAddress }");
            }

            Console.ReadLine();
        }
    }
}
