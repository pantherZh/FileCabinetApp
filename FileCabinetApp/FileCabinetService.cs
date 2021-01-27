using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinetApp
{
    public class FileCabinetService
    {
        private static readonly List<FileCabinetRecord> list = new List<FileCabinetRecord>();

        public int CreateRecord(string FirstName, string Lastname, DateTime dateOfBirth)
        {
            return 0;
        }

        public FileCabinetRecord[] GetRecords()
        {
            return Array.Empty<FileCabinetRecord>();
        }

        public static int GetStat()
        {
            return list.Count;
        }
    }
}
