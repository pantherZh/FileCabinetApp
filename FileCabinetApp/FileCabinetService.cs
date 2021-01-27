using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinetApp
{
    public class FileCabinetService
    {
        private readonly List<FileCabinetRecord> list = new List<FileCabinetRecord>();

        public int CreateRecord(string FirstName, string Lastname, DateTime dateOfBirth)
        {
            return 0;
        }

        public FileCabinetRecord[] GetRecords()
        {
            return new FileCabinetRecord[] { };
        }

        public int GetStat()
        {
            return 0;
        }
    }
}
