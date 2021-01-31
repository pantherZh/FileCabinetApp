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
    }
}
