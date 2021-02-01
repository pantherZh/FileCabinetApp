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

            List[id - 1] = flc;
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
            return record.Id;
        }

        public static FileCabinetRecord[] FindByFirstName(string firstName)
        {
            List<FileCabinetRecord> namesArr = new List<FileCabinetRecord>();
            foreach (var obj in List)
            {
                if (firstName.IndexOf(obj.FirstName, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    namesArr.Add(obj);
                }
            }

            return namesArr.ToArray();
        }
    }
}
