using System;
using System.Text.RegularExpressions;
using HandlingException.CustomException;

namespace HandlingException.HelperClass
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public bool ValidateName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty!");
            }

            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(name))
            {
                // Console.WriteLine("Nama tidak valid!"); 
                // throw new Exception($"{name} bukan nama yang valid!");
                // Exception e = new Exception($"{name} bukan nama yang valid!");
                InvalidNameException e = new InvalidNameException($"{name} is not a valid name!");
                
                e.Data.Add("Error time", DateTime.Now);
                e.Data.Add("Cause of error", "Name contains invalid character");
                e.HelpLink = "https://mahirkoding.id";
                throw e;
            }

            return true;
        }
    }
}