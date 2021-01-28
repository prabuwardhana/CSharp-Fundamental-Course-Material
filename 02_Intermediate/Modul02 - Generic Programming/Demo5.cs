using System;
using System.Collections.Generic;

namespace GenericProgramming
{
    interface IEmployee
    {
        string GetExperienceLvl();
    }

    class Employee : IEmployee
    {
        public string Name;
        public int YearOfExp;

        public Employee(){}

        public Employee(string name, int yearOfExp)
        {
            Name = name;
            YearOfExp = yearOfExp;
        }
        
        public string GetExperienceLvl()
        {
            string experienceLvl;
            // C# 7
            switch (YearOfExp)
            {
                case int n when (n <= 1):
                    experienceLvl = "Fresher";
                    break;
                case int n when (n >= 2 && n <= 5):
                    experienceLvl = "Intermediate";
                    break;
                default:
                    experienceLvl = "Expert";
                    break;
            }

            return experienceLvl;
        }
    }

    class EmployeeStoreHouse<T> where T : IEmployee, new()
    {
        private List<Employee> employeeStore = new List<Employee>();

        public void AddToStore(Employee employee)
        {
            employeeStore.Add(employee);
        }

        public void DisplayStore()
        {
            Console.WriteLine("The store contains:");
            foreach (Employee e in employeeStore)
            {
                Console.Write($"{e.Name}: ");
                Console.WriteLine(e.GetExperienceLvl());
            }
        }
    }

    public class Demo5
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Generic Constrains ===");
            //Employees
            Employee e1 = new Employee("Nandi", 1);
            Employee e2 = new Employee("Bambang", 5);
            Employee e3 = new Employee("Jon", 7);
            Employee e4 = new Employee("Somad", 2);
            Employee e5 = new Employee("Butet", 3);

            //Employee StoreHouse
            EmployeeStoreHouse<Employee> myEmployeeStore = new EmployeeStoreHouse<Employee>();
            
            myEmployeeStore.AddToStore(e1);
            myEmployeeStore.AddToStore(e2);
            myEmployeeStore.AddToStore(e3);
            myEmployeeStore.AddToStore(e4);
            myEmployeeStore.AddToStore(e5);

            //Display the Employee Positions in Store
            myEmployeeStore.DisplayStore();
        }
    }
}