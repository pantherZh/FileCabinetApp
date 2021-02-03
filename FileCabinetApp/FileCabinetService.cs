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

            FileCabinetRecord.FirstNameDictionary[flc.FirstName] = flc;
            List[id - 1] = flc;
        }

        public static FileCabinetRecord[] FindByFirstName(string firstName)
        {
            if (firstName is null)
            {
                throw new ArgumentNullException($"{nameof(firstName)} is null.");
            }

            List<FileCabinetRecord> namesArr = new List<FileCabinetRecord>();
            if (FileCabinetRecord.FirstNameDictionary.ContainsKey(firstName))
            {
                namesArr.Add(FileCabinetRecord.FirstNameDictionary[firstName]);
            }
            else
            {
                Console.WriteLine($"{firstName} Key is not found.");
            }

            return namesArr.ToArray();
        }

        public static FileCabinetRecord[] FindByLastName(string lastName)
        {
            if (lastName is null)
            {
                throw new ArgumentNullException($"{nameof(lastName)} is null.");
            }

            List<FileCabinetRecord> namesArr = new List<FileCabinetRecord>();
            foreach (var obj in List)
            {
                if (lastName.IndexOf(obj.LastName, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    namesArr.Add(obj);
                }
            }

            return namesArr.ToArray();
        }

        public static FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfbirth)
        {
            List<FileCabinetRecord> namesArr = new List<FileCabinetRecord>();
            foreach (var obj in List)
            {
                if (dateOfbirth.Equals(obj.DateOfBirth))
                {
                    namesArr.Add(obj);
                }
            }

            return namesArr.ToArray();
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
            FileCabinetRecord.FirstNameDictionary.Add(firstName, record);
            return record.Id;
        }
    }
}
