﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FileCabinetApp
{
    /// <summary>
    /// The repository class.
    /// Contains all methods for manipulating records.
    /// </summary>
    public class FileCabinetMemoryService : IFileCabinetService
    {
        private static readonly List<FileCabinetRecord> List = new List<FileCabinetRecord>();
        private static ReadOnlyCollection<FileCabinetRecord> readOnlyList = new ReadOnlyCollection<FileCabinetRecord>(List);

        /// <summary>
        /// Gets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of FirstNameDictionary.</value>
        public static int GetStat
        {
            get
            {
                return readOnlyList.Count;
            }
        }

        /// <summary>
        /// Returns the array of records.
        /// </summary>
        /// <returns>The array of records.</returns>
        public ReadOnlyCollection<FileCabinetRecord> GetRecords()
        {
            return readOnlyList;
        }

        /// <summary>
        /// Allows to correct records in the array.
        /// </summary>
        /// <param name="id">The id to edit.</param>
        /// <param name="record">The record to edit.</param>
        public void EditRecord(int id, FileCabinetRecord record)
        {
            if (record is null)
            {
                throw new ArgumentNullException($"{nameof(record)} is null.");
            }

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
            List[id - 1] = record;
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
        /// <param name="dateOfbirth">The date of birth to find.</param>
        /// <returns>The array of records.</returns>
        public FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfbirth)
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

        /// <summary>
        /// Make snapshot with class memory.
        /// </summary>
        /// <returns>FileCabinetServiceSnapshot object.</returns>
        public static FileCabinetServiceSnapshot MakeSnapshot()
        {
            FileCabinetServiceSnapshot snapshot = new FileCabinetServiceSnapshot(List.ToArray());
            return snapshot;
        }
    }
}