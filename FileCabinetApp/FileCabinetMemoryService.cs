using System;
using System.Collections.Generic;
using System.Globalization;

namespace FileCabinetApp
{
    /// <summary>
    /// The repository class.
    /// Contains all methods for manipulating records.
    /// </summary>
    public class FileCabinetMemoryService : IFileCabinetService
    {
        /// <summary>
        /// Make snapshot with class memory.
        /// </summary>
        /// <returns>FileCabinetServiceSnapshot object.</returns>
        public static FileCabinetServiceSnapshot MakeSnapshot()
        {
            FileCabinetServiceSnapshot snapshot = new FileCabinetServiceSnapshot(FileCabinetRecord.List.ToArray());
            return snapshot;
        }

        /// <summary>
        /// Gets status of records.
        /// </summary>
        /// <returns>The quantity of records.</returns>
        public int GetStat()
        {
            return FileCabinetRecord.readOnlyList.Count;
        }

        /// <summary>
        /// Returns the array of records.
        /// </summary>
        /// <returns>The array of records.</returns>
        public int GetRecords()
        {
            foreach (var obj in FileCabinetRecord.readOnlyList)
            {
                Console.WriteLine("#" + obj.Id + ", " + obj.FirstName + ", " + obj.LastName + ", " + obj.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + obj.Salary + ", " + obj.Key + ", " + obj.PassForCabinet);
            }

            return FileCabinetRecord.readOnlyList.Count;
        }

        /// <summary>
        /// Allows to correct records in the array.
        /// </summary>
        /// <param name="id">The id to edit.</param>
        public bool EditRecord(int id)
        {
            FileCabinetRecord record = new FileCabinetRecord();
            FileCabinetRecord.FirstNameDictionary.Remove(record.FirstName);
            FileCabinetRecord.LastNameDictionary.Remove(record.LastName);

            Console.Write("First Name: ");
            record.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            record.LastName = Console.ReadLine();
            Console.Write("Date Time(MM/dd/yyyy): ");
            _ = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
            Console.Write("Salary: ");
            _ = decimal.TryParse(Console.ReadLine(), out decimal salary);
            Console.Write("Key(A-Z): ");
            _ = char.TryParse(Console.ReadLine(), out char key);
            Console.Write("Password for Cabinet: ");
            _ = short.TryParse(Console.ReadLine(), out short passForCabinet);
            record.DateOfBirth = dateOfBirth;
            record.Salary = salary;
            record.Key = key;
            record.PassForCabinet = passForCabinet;

            FileCabinetRecord.FirstNameDictionary[record.FirstName] = new List<FileCabinetRecord> { record };
            FileCabinetRecord.LastNameDictionary[record.LastName] = new List<FileCabinetRecord> { record };
            FileCabinetRecord.List[id - 1] = record;

            return true;
        }

        /// <summary>
        /// Finds FirstName in the array.
        /// </summary>
        /// <param name="firstName">The first name to find.</param>
        /// <returns>The array of records.</returns>
        public FileCabinetRecord[] FindByFirstName(string firstName)
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

        /// <summary>
        /// Finds LastName in the array.
        /// </summary>
        /// <param name="lastName">The last name to find.</param>
        /// <returns>The array of records.</returns>
        public FileCabinetRecord[] FindByLastName(string lastName)
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

        /// <summary>
        /// Finds DateOfBirth in the array.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth to find.</param>
        /// <returns>The array of records.</returns>
        public FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfBirth)
        {
            if (FileCabinetRecord.DateOfBirthDictionary.ContainsKey(dateOfBirth))
            {
                return FileCabinetRecord.DateOfBirthDictionary[dateOfBirth].ToArray();
            }
            else
            {
                Console.WriteLine($"{dateOfBirth} Key is not found.");
            }

            return Array.Empty<FileCabinetRecord>();
        }

        /// <summary>
        /// Finds FirstName in the array.
        /// </summary>
        /// <param name="firstName">The first name to create.</param>
        /// <param name="lastName">The last name to create.</param>
        /// <param name="dateOfBirth">The date of birth to create.</param>
        /// <param name="salary">The salary to create.</param>
        /// <param name="key">The key to create.</param>
        /// <param name="passForCabinet">The password for cabinet to create.</param>
        /// <returns>The value of id.</returns>
        public int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, decimal salary, char key, short passForCabinet)
        {
            Console.WriteLine("Memoryyy");
            var record = new FileCabinetRecord
            {
                Id = FileCabinetRecord.List.Count + 1,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Salary = salary,
                Key = key,
                PassForCabinet = passForCabinet,
            };

            FileCabinetRecord.List.Add(record);

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
