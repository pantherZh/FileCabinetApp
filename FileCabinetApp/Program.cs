using System;
using System.Globalization;

namespace FileCabinetApp
{
    /// <summary>
    /// Interface-validator.
    /// </summary>
    public interface IRecordValidator
    {
        /// <summary>
        /// Method-validator of data.
        /// </summary>
        /// <param name="record">The record to create.</param>
        void ValidateParameters(FileCabinetRecord record);
    }

    /// <summary>
    /// The program entry point.
    /// Contains the Main method and helper methods and fields for manipulating records.
    /// </summary>
    public static class Program
    {
        private const string DeveloperName = "Alesya Zhovnerik";
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;

        private static bool isRunning = true;

        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("stat", Stat),
            new Tuple<string, Action<string>>("create", Create),
            new Tuple<string, Action<string>>("list", List),
            new Tuple<string, Action<string>>("edit", Edit),
            new Tuple<string, Action<string>>("find", Find),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
            new string[] { "stat", "gets number of records", "The 'stat' command gets number of records." },
            new string[] { "create", "creates record in file", "The 'create' command cretaes record in file." },
            new string[] { "list", "displays all records in file", "The 'list' command displays all records in file." },
            new string[] { "edit", "edits created files", "The 'edit' command edits created files." },
            new string[] { "find", "finds first name", "The 'find' command finds first name." },
        };

        /// <summary>
        /// Returns the array of records.
        /// </summary>
        /// <param name="parameters">The first name to find.</param>
        public static void Stat(string parameters)
        {
            Console.WriteLine($"{FileCabinetService.GetStat} record(s).");
        }

        /// <summary>
        /// The program entry point.
        /// </summary>
        /// <param name="args">The first name to create.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine($"File Cabinet Application, developed by {Program.DeveloperName}");
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();
            Console.WriteLine(FileCabinetRecord.CustomValidator);

            if (args.Length == 1 && args[0].Contains("--validation-rules=custom", StringComparison.OrdinalIgnoreCase))
            {
                FileCabinetRecord.CustomValidator = true;
                //_ = new FileCabinetService(new CustomValidator());
            }

            if (args.Length > 1 && args[1].Contains("Custom", StringComparison.OrdinalIgnoreCase) && args[0].Contains("-v", StringComparison.OrdinalIgnoreCase))
            {
                FileCabinetRecord.CustomValidator = true;
                //_ = new FileCabinetService(new CustomValidator());
            }

            //_ = new FileCabinetService(new DefaultValidator());

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (isRunning);
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i => string.Equals(i[Program.CommandHelpIndex], parameters, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][Program.ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in helpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[Program.CommandHelpIndex], helpMessage[Program.DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }

        private static void Create(string parameters)
        {
            int id;
            do
            {
                FileCabinetRecord.Error = false;
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Date Time(MM/dd/yyyy): ");
                _ = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
                Console.Write("Salary: ");
                _ = decimal.TryParse(Console.ReadLine(), out decimal salary);
                Console.Write("Key(A-Z): ");
                _ = char.TryParse(Console.ReadLine(), out char key);
                Console.Write("Password for Cabinet: ");
                _ = short.TryParse(Console.ReadLine(), out short passForCabinet);

                FileCabinetService objCreate;
                if (FileCabinetRecord.CustomValidator)
                {
                    objCreate = new FileCabinetService(new CustomValidator());
                }
                else
                {
                    objCreate = new FileCabinetService(new DefaultValidator());
                }

                id = objCreate.CreateRecord(firstName, lastName, dateOfBirth, salary, key, passForCabinet);
            }
            while (FileCabinetRecord.Error);
            Console.WriteLine($"Record #{id} is created");
        }

        private static void List(string parameters)
        {
            if (FileCabinetService.GetRecords().Length == 0)
            {
                Console.WriteLine("The list is empty.");
            }

            foreach (var obj in FileCabinetService.GetRecords())
            {
                Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
            }
        }

        private static void Edit(string parameters)
        {
            _ = int.TryParse(Console.ReadLine(), out int id);
            foreach (var obj in FileCabinetService.GetRecords())
            {
                if (obj.Id == id)
                {
                    FileCabinetService.EditRecord(obj.Id, obj);
                    return;
                }
            }

            try
            {
                throw new ArgumentException($"#{id} record is not found.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Find(string parameters)
        {
            var inputs = parameters.Split(' ', 2);
            if (inputs[0].Equals("firstname", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var obj in FileCabinetService.FindByFirstName(inputs[1].ToString()))
                {
                    Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
                }
            }
            else if (inputs[0].Equals("lastname", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var obj in FileCabinetService.FindByLastName(inputs[1].ToString()))
                {
                    Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
                }
            }
            else if (inputs[0].Equals("dateofbirth", StringComparison.OrdinalIgnoreCase))
            {
                _ = DateTime.TryParse(inputs[1], out DateTime dateOfbirth);
                foreach (var obj in FileCabinetService.FindByDateOfBirth(dateOfbirth))
                {
                    Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
                }
            }
        }
    }
}