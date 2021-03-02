using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FileCabinetApp
{
    public interface IFileCabinetService
    {
        int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, decimal salary, char key, short passForCabinet);
        void EditRecord(int id, FileCabinetRecord record);
        ReadOnlyCollection<FileCabinetRecord> GetRecords();
        static int GetStat;
        FileCabinetRecord[] FindByFirstName(string firstName);
        FileCabinetRecord[] FindByLastName(string lastName);
        FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfBirth);
    }
}
