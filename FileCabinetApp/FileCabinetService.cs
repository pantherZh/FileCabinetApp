using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace FileCabinetApp
{
    /// <summary>
    /// The repository class.
    /// Contains all methods for manipulating records.
    /// </summary>
    public class FileCabinetService
    {
        private static readonly List<FileCabinetRecord> List = new List<FileCabinetRecord>();
        private static ReadOnlyCollection<FileCabinetRecord> readOnlyList = new ReadOnlyCollection<FileCabinetRecord>(List);
        private readonly IRecordValidator validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetService"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="validator">The record to edit.</param>
        public FileCabinetService(IRecordValidator validator)
        {
            this.validator = validator;
        }

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
        public static ReadOnlyCollection<FileCabinetRecord> GetRecords()
        {
            return readOnlyList;
        }

        /// <summary>
        /// Allows to correct records in the array.
        /// </summary>
        /// <param name="id">The id to edit.</param>
        /// <param name="record">The record to edit.</param>
        public static void EditRecord(int id, FileCabinetRecord record)
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

        /// <summary>
        /// Finds LastName in the array.
        /// </summary>
        /// <param name="lastName">The last name to find.</param>
        /// <returns>The array of records.</returns>
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

        /// <summary>
        /// Finds DateOfBirth in the array.
        /// </summary>
        /// <param name="dateOfbirth">The date of birth to find.</param>
        /// <returns>The array of records.</returns>
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

            this.validator.ValidateParameters(record);

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
