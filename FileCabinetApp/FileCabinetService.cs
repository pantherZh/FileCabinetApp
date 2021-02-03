using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinetApp
{
    public class FileCabinetService
    {
        private static readonly List<FileCabinetRecord> List = new List<FileCabinetRecord>();

        public static int GetStat
        {
            get
            {
                return List.Count;
            }
        }

        public static FileCabinetRecord[] GetRecords()
        {
            return List.ToArray();
        }

        public static void EditRecord(int id, FileCabinetRecord flc)
        {
            if (flc is null)
            {
                throw new ArgumentNullException($"{nameof(flc)} is null.");
            }

            FileCabinetRecord.FirstNameDictionary.Remove(flc.FirstName);
            FileCabinetRecord.LastNameDictionary.Remove(flc.LastName);

            Console.Write("First Name: ");
            flc.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            flc.LastName = Console.ReadLine();
            Console.Write("Date Time(MM/dd/yyyy): ");
            _ = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
            Console.Write("Salary: ");
            _ = decimal.TryParse(Console.ReadLine(), out decimal salary);
            Console.Write("Key(A-Z): ");
            _ = char.TryParse(Console.ReadLine(), out char key);
            Console.Write("Password for Cabinet: ");
            _ = short.TryParse(Console.ReadLine(), out short passForCabinet);
            flc.DateOfBirth = dateOfBirth;
            flc.Salary = salary;
            flc.Key = key;
            flc.PassForCabinet = passForCabinet;

            FileCabinetRecord.FirstNameDictionary[flc.FirstName] = new List<FileCabinetRecord> { flc };
            FileCabinetRecord.LastNameDictionary[flc.LastName] = new List<FileCabinetRecord> { flc };
            List[id - 1] = flc;
        }

        public static FileCabinetRecord[] FindByFirstName(string firstName)
        {
            if (firstName is null)
            {
                throw new ArgumentNullException($"{nameof(firstName)} is null.");
            }

            if (FileCabinetRecord.FirstNameDictionary.ContainsKey(firstName))
            {
                return FileCabinetRecord.FirstNameDictionary[firstName].ToArray();
            }
            else
            {
                Console.WriteLine($"{firstName} Key is not found.");
            }

            return Array.Empty<FileCabinetRecord>();
        }

        public static FileCabinetRecord[] FindByLastName(string lastName)
        {
            if (lastName is null)
            {
                throw new ArgumentNullException($"{nameof(lastName)} is null.");
            }

            if (FileCabinetRecord.LastNameDictionary.ContainsKey(lastName))
            {
                return FileCabinetRecord.LastNameDictionary[lastName].ToArray();
            }
            else
            {
                Console.WriteLine($"{lastName} Key is not found.");
            }

            return Array.Empty<FileCabinetRecord>();
        }

        public static FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfbirth)
        {
            if (FileCabinetRecord.DateOfBirthDictionary.ContainsKey(dateOfbirth))
            {
                return FileCabinetRecord.DateOfBirthDictionary[dateOfbirth].ToArray();
            }
            else
            {
                Console.WriteLine($"{dateOfbirth} Key is not found.");
            }

            return Array.Empty<FileCabinetRecord>();
        }

        public int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, decimal salary, char key, short passForCabinet)
        {
            var record = new FileCabinetRecord
            {
                Id = List.Count + 1,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Salary = salary,
                Key = key,
                PassForCabinet = passForCabinet,
            };

            if (FileCabinetRecord.Error)
            {
                return 0;
            }

            List.Add(record);

            if (!FileCabinetRecord.FirstNameDictionary.ContainsKey(firstName))
            {
                FileCabinetRecord.FirstNameDictionary.Add(firstName, new List<FileCabinetRecord>());
                FileCabinetRecord.FirstNameDictionary[firstName].Add(record);
            }
            else
            {
                FileCabinetRecord.FirstNameDictionary[firstName].Add(record);
            }

            if (!FileCabinetRecord.LastNameDictionary.ContainsKey(lastName))
            {
                FileCabinetRecord.LastNameDictionary.Add(lastName, new List<FileCabinetRecord>());
                FileCabinetRecord.LastNameDictionary[lastName].Add(record);
            }
            else
            {
                FileCabinetRecord.LastNameDictionary[lastName].Add(record);
            }

            if (!FileCabinetRecord.DateOfBirthDictionary.ContainsKey(dateOfBirth))
            {
                FileCabinetRecord.DateOfBirthDictionary.Add(dateOfBirth, new List<FileCabinetRecord>());
                FileCabinetRecord.DateOfBirthDictionary[dateOfBirth].Add(record);
            }
            else
            {
                FileCabinetRecord.DateOfBirthDictionary[dateOfBirth].Add(record);
            }

            return record.Id;
        }
    }
}
