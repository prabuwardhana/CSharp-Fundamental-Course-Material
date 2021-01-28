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
                throw new ArgumentException("Nama tidak boleh kosong!");
            }

            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(name))
            {
                // Console.WriteLine("Nama tidak valid!"); 
                // throw new Exception($"{name} bukan nama yang valid!");
                // Exception e = new Exception($"{name} bukan nama yang valid!");
                InvalidNameException e = new InvalidNameException($"{name} bukan nama yang valid!");
                
                e.Data.Add("Waktu eror", DateTime.Now);
                e.Data.Add("Penyebab", "Nama mengandung karakter selain huruf");
                e.HelpLink = "https://mahirkoding.id";
                throw e;
            }

            return true;
        }
    }
}