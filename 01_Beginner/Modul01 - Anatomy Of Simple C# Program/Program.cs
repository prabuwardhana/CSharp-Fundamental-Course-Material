using System;

namespace ProgramAnatomy
{
    class Program
    {
        // string[] args --> Command-Line Arguments
        // Example command: "dotnet run arg1 arg2 arg3",
        // Where arg1, arg2, and arg3 are the arguments
        static void Main(string[] args)
        {
            // Get each argument passed from the command-line,
            // then print it on the console
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Arg: {0}", args[i]);

            /*
                Run this application with "dotnet run arg1 arg2 arg3" to see the output
            */
            
            ConsoleColor prevColor = Console.ForegroundColor;

            // The code below will be executed when you run this application
            // by typing the run command on the CLI with --adm flag
            // Example: "dotnet run --adm"
            if ( args.Length > 0 && args[0] == "--adm")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You run this application as administrator ");
                Console.ForegroundColor = prevColor;

                // Get the input from user
                Console.Write("Insert your name: ");
                string namaPengguna = Console.ReadLine();
                Console.Write("Insert your department: ");
                string namaDepartemen = Console.ReadLine();

                // Display the input from user.
                // The first argument is the string you want to display on the console.
                // The second and third argument are the variable you want to display dynamically on the console.
                // {0} and {1} are the placeholder.
                // The first argument will eventually fill the placeholder {0}, the second will fill {1}.
                Console.WriteLine("Hello {0} from {1} department!", namaPengguna, namaDepartemen);
                // The placeholder can be placed in any order.
                Console.WriteLine("Departement: {1}, Name: {0}", namaPengguna, namaDepartemen);
                // Or you can use one placeholder more than once.
                Console.WriteLine("Hello {0}, Hello {0}, Hello {0}!", namaPengguna);

                /*
                    Run this application with "dotnet run --adm" to see the output
                */
            }
            else
            {
                Console.WriteLine("Welcome!");

                /*
                    Run this application with "dotnet run" to see this output
                */
            }            
        }
    }
}
