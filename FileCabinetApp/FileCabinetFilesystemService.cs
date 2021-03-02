using System;
using System.IO;
using System.Collections.ObjectModel;

namespace FileCabinetApp
{
    public class FileCabinetFilesystemService : IFileCabinetService
    {
        private readonly FileStream fileStream;

        public FileCabinetFilesystemService(FileStream fileStream)
        {
            this.fileStream = fileStream;
        }

        public int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, decimal salary, char key, short passForCabinet)
        {
            throw new NotImplementedException();
        }

        public void EditRecord(int id, FileCabinetRecord record)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<FileCabinetRecord> GetRecords()
        {
            throw new NotImplementedException();
        }

        public static int GetStat { get; set; }

        public FileCabinetRecord[] FindByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public FileCabinetRecord[] FindByLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }
    }
}
