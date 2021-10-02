using System;
using System.Collections;
using HandlingException.CustomException;
using HandlingException.HelperClass;

namespace HandlingException
{
    public class Demo5
    {
        public static void Run(string[] args)
        {
            Student student = new Student(1, args[0]);

            try
            {
                if (student.ValidateName(student.Name))
                {
                    Console.WriteLine("Name: {0}", student.Name);
                }
            }
            catch (InvalidNameException e)
            {
                // Method from where the exception is thrown
                Console.WriteLine("-> Exception rised at method: {0}", e.TargetSite);
                Console.WriteLine("-> defined in class: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("-> Member type: {0}", e.TargetSite.MemberType);

                // Exception message
                Console.WriteLine("-> Message: {0}", e.Message);

                // Assembly from where the exception is thrown
                Console.WriteLine("-> Assembly: {0}", e.Source);

                // Additional custom data
                Console.WriteLine("-> Additional data:");
                foreach (DictionaryEntry de in e.Data)
                {
                    Console.WriteLine("\t{0}: {1}", de.Key, de.Value);
                }
                Console.WriteLine("\tGet help {0}", e.HelpLink);

                // Stack trace
                Console.WriteLine("-> Stack: \n{0}", e.StackTrace);

                throw;
            }
            // Processing multiple exception
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            // This will catch any other exception
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Code inside the finally block will always be executed wheter there is exceptions or not");
            }
        }
    }
}