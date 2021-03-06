﻿using System;
using System.Globalization;
using System.IO;
using System.Xml;

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
        /// <param name="firstName">The record to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        Tuple<bool, string> FirstNameValidator(string firstName);

        /// <summary>
        /// Method-validator of data.
        /// </summary>
        /// <param name="lastName">The record to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        Tuple<bool, string> LastNameValidator(string lastName);

        /// <summary>
        /// Method-validator of data.
        /// </summary>
        /// <param name="birthDay">The record to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        Tuple<bool, string> BirhtdayValidator(DateTime birthDay);

        /// <summary>
        /// Method-validator of data.
        /// </summary>
        /// <param name="salary">The record to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        Tuple<bool, string> SalaryValidator(decimal salary);

        /// <summary>
        /// Method-validator of data.
        /// </summary>
        /// <param name="key">The record to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        Tuple<bool, string> KeyValidator(char key);

        /// <summary>
        /// Method-validator of data.
        /// </summary>
        /// <param name="passForCabinet">The record to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        Tuple<bool, string> PassForCabinetValidator(short passForCabinet);
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
        private static IFileCabinetService stream;
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
            new Tuple<string, Action<string>>("export", Export),
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
            new string[] { "export csv", "exports to csv", "The 'exports csv' command exports to csv." },
        };

        /// <summary>
        /// Returns the array of records.
        /// </summary>
        /// <param name="parameters">The first name to find.</param>
        public static void Stat(string parameters)
        {
            Console.WriteLine($"{stream.GetStat()} record(s).");
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

            if (args.Length != 0)
            {
                if (args[0].Contains("--validation-rules=custom", StringComparison.OrdinalIgnoreCase) || args[0].Contains("-v", StringComparison.OrdinalIgnoreCase))
                {
                    FileCabinetRecord.CustomValidator = true;
                    Console.WriteLine("Valid");
                }

                if (args.Length > 1 && args[1].Contains("custom", StringComparison.OrdinalIgnoreCase))
                {
                    FileCabinetRecord.CustomValidator = true;
                    Console.WriteLine("Valid");
                }

                if (args[0].Contains("--storage=file", StringComparison.OrdinalIgnoreCase) || args[0].Contains("-s", StringComparison.OrdinalIgnoreCase))
                {
                    if (File.Exists("cabinet-records.db"))
                    {
                        File.Delete("cabinet-records.db");
                    }

                    FileStream fs = File.Create("cabinet-records.db");
                    stream = new FileCabinetFilesystemService(fs);
                    FileCabinetRecord.FileStorage = true;
                }

                if (args.Length > 1 && args[1].Contains("file", StringComparison.OrdinalIgnoreCase))
                {
                    FileStream fs = File.Create("cabinet-records.db");
                    stream = new FileCabinetFilesystemService(fs);
                    FileCabinetRecord.FileStorage = true;
                }
            }

            if (!FileCabinetRecord.FileStorage)
            {
                stream = new FileCabinetMemoryService();
            }

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
            IRecordValidator validator;
            int id;
            if (FileCabinetRecord.CustomValidator)
            {
                validator = new CustomValidator();
            }
            else
            {
                validator = new DefaultValidator();
            }

            Console.Write("First name: ");
            var firstName = ReadInput(StringConverter, validator.FirstNameValidator);

            Console.Write("Last name: ");
            var lastName = ReadInput(StringConverter, validator.LastNameValidator);

            Console.Write("Date of birth: ");
            var dob = ReadInput(DateConverter, validator.BirhtdayValidator);

            Console.Write("Salary: ");
            var salary = ReadInput(DecimalConverter, validator.SalaryValidator);

            Console.Write("Key: ");
            var key = ReadInput(CharConverter, validator.KeyValidator);

            Console.Write("Password for cabinet: ");
            var passForCabinet = ReadInput(ShortConverter, validator.PassForCabinetValidator);

            id = stream.CreateRecord(firstName, lastName, dob, salary, key, passForCabinet);
            Console.WriteLine($"Record #{id} is created");
        }

        private static void List(string parameters)
        {
            if (stream.GetStat() == 0)
            {
                Console.WriteLine("The list is empty.");
            }

            stream.GetRecords();
        }

        private static void Edit(string parameters)
        {
            _ = int.TryParse(Console.ReadLine(), out int id);
            //if (FileCabinetRecord.FileStorage is false)
            //{
            //    foreach (var obj in stream.GetRecords())
            //    {
            //        if (obj.Id == id)
            //        {
            //            stream.EditRecord(obj.Id, obj);
            //            return;
            //        }
            //    }
            //}
            if (stream.EditRecord(id))
            {
                return;
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
                foreach (var obj in stream.FindByFirstName(inputs[1].ToString()))
                {
                    Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
                }
            }
            else if (inputs[0].Equals("lastname", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var obj in stream.FindByLastName(inputs[1].ToString()))
                {
                    Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
                }
            }
            else if (inputs[0].Equals("dateofbirth", StringComparison.OrdinalIgnoreCase))
            {
                _ = DateTime.TryParse(inputs[1], out DateTime dateOfbirth);
                foreach (var obj in stream.FindByDateOfBirth(dateOfbirth))
                {
                    Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
                }
            }
        }

        private static void Export(string parameters)
        {
            var inputs = parameters.Split(' ', 2);
            if (inputs.Length != 2)
            {
                Console.WriteLine("Input file name!");
                return;
            }

            if (File.Exists(inputs[1]))
            {
                Console.WriteLine($"File is exist - rewrite {inputs[1]}? [Y/n]");
                var reader = Console.ReadLine();
                if (reader.Contains('n', StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
                else if (!reader.Contains('y', StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Input correct answer!");
                    return;
                }
            }

            switch (inputs[0])
            {
                case "csv":
                    using (StreamWriter sw = new StreamWriter(inputs[1]))
                    {
                        var snap = FileCabinetMemoryService.MakeSnapshot();
                        snap.SaveToCsv(sw);
                        sw.Close();
                        Console.WriteLine($"All records are exported to file {inputs[1]}.csv.");
                    }

                    break;
                case "xml":
                    using (XmlWriter xw = XmlWriter.Create(inputs[1]))
                    {
                        var snap = FileCabinetMemoryService.MakeSnapshot();
                        snap.SaveToXml(xw);
                        xw.Close();
                        Console.WriteLine($"All records are exported to file {inputs[1]}.xml.");
                    }

                    break;
            }
        }

        private static Tuple<bool, string, string> StringConverter(string input)
        {
            return new Tuple<bool, string, string>(true, input, input);
        }

        private static Tuple<bool, string, DateTime> DateConverter(string input)
        {
            if (DateTime.TryParse(input, out DateTime date))
            {
                return new Tuple<bool, string, DateTime>(true, input, date);
            }

            return new Tuple<bool, string, DateTime>(false, input, default);
        }

        private static Tuple<bool, string, decimal> DecimalConverter(string input)
        {
            if (decimal.TryParse(input, out decimal value))
            {
                return new Tuple<bool, string, decimal>(true, input, value);
            }

            return new Tuple<bool, string, decimal>(false, input, default);
        }

        private static Tuple<bool, string, char> CharConverter(string input)
        {
            if (char.TryParse(input, out char value))
            {
                return new Tuple<bool, string, char>(true, input, value);
            }

            return new Tuple<bool, string, char>(false, input, default);
        }

        private static Tuple<bool, string, short> ShortConverter(string input)
        {
            if (short.TryParse(input, out short value))
            {
                return new Tuple<bool, string, short>(true, input, value);
            }

            return new Tuple<bool, string, short>(false, input, default);
        }

        // <summary>
        // Finds FirstName in the array.
        // </summary>
        // <param name = "converter" > To convert data.</param>
        // <param name = "validator" > To validate data.</param>
        // <returns>The value of id.</returns>
        public static T ReadInput<T>(Func<string, Tuple<bool, string, T>> converter, Func<T, Tuple<bool, string>> validator)
        {
            if (converter is null)
            {
                throw new ArgumentNullException($"{converter} is null.");
            }

            if (validator is null)
            {
                throw new ArgumentNullException($"{validator} is null.");
            }

            do
            {
                T value;

                var input = Console.ReadLine();
                var conversionResult = converter(input);

                if (!conversionResult.Item1)
                {
                    Console.WriteLine($"Conversion failed: {conversionResult.Item2}. Please, correct your input.");
                    continue;
                }

                value = conversionResult.Item3;

                var validationResult = validator(value);
                if (!validationResult.Item1)
                {
                    Console.WriteLine($"Validation failed: {validationResult.Item2}. Please, correct your input.");
                    continue;
                }

                return value;
            }
            while (true);
        }
    }
}
