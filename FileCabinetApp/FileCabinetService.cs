using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinetApp
{
    public class FileCabinetService
    {
        private static readonly List<FileCabinetRecord> list = new List<FileCabinetRecord>();

        public static int GetStat()
        {
            return list.Count;
        }

        public int CreateRecord(string firstName, string lastName, DateTime dateOfBirth)
        {
            var record = new FileCabinetRecord
            {
                Id = list.Count + 1,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
            };

            list.Add(record);

            return record.Id;
        }

        public FileCabinetRecord[] GetRecords()
        {
            return Array.Empty<FileCabinetRecord>();
        }
    }
}
