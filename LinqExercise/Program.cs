using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            //print sum and average
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average()}");

            Console.WriteLine("----------------");

            //ascending and descending order
            Console.WriteLine("Order by ascending and ordered by descending");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x)); //DESCENDING ORDER

            Console.WriteLine("---------------");

            // greater than 6
            Console.WriteLine("Numbers greater than 6");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("---------------");

            // first four ascending
            Console.WriteLine("Ordered by ascending, first four elements");
            numbers.OrderBy(x => x).Take(4).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine(); Console.WriteLine("---------------");

            //replace my age at index 4, print updated numbers ordering by descending
            Console.WriteLine("Order by descending, including age");
            //set value instead of using square brackets
            numbers.SetValue(21, 4); //value of 21 at index 4
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("---------------");

            // List of employees
            var employees = CreateEmployees();

            //Print FullName in ascending order if their FirstName starts with a C OR an S
            //use ToLower() and StartsWith(), or index 0 to check first char of string
            Console.WriteLine("Full name if first name starts with a C or an S");
            employees.Where(x => x.FirstName.ToLower().StartsWith('c') ||
                x.FirstName.ToLower()[0] == 's').OrderBy(x => x.FirstName).ToList()
                .ForEach(x => Console.WriteLine(x.FullName));

            Console.WriteLine("---------------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Full name and age above 26");
            employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine($"Name : {x.FullName}, Age: {x.Age}"));

            Console.WriteLine("---------------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine($"Sum YOE: {employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience)}");

            Console.WriteLine($"Average YOE: {employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience)}");

            Console.WriteLine("-----------------");

            //Add an employee to the end of the list without using employees.Add()
            // Append()
            employees = employees.Append(new Employee("Amanda", "Gawlowicz", 21, 5)).ToList();

            Console.WriteLine("Added employee");

            employees.ToList().ForEach(x => Console.WriteLine(x.FullName));

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
