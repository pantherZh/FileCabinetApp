using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FileCabinetApp
{
    /// <summary>
    /// Interface storage.
    /// </summary>
    public interface IFileCabinetService
    {
        /// <summary>
        /// Method of creating record.
        /// </summary>
        /// <param name="firstName">The first name to create.</param>
        /// <param name="lastName">The last name to create.</param>
        /// <param name="dateOfBirth">The date of birth to create.</param>
        /// <param name="salary">The salary to create.</param>
        /// <param name="key">The key to create.</param>
        /// <param name="passForCabinet">The password for cabinet to create.</param>
        /// <returns>The id of record.</returns>
        int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, decimal salary, char key, short passForCabinet);

        /// <summary>
        /// Method of editing record.
        /// </summary>
        /// <param name="id">The first name to create.</param>
        bool EditRecord(int id);

        /// <summary>
        /// Method of returning collection.
        /// </summary>
        /// <returns>The collection from FileCabinetRecord objects.</returns>
        int/*ReadOnlyCollection<FileCabinetRecord>*/ GetRecords();

        /// <summary>
        /// Method of returning status of list.
        /// </summary>
        /// <returns>The quantity of records.</returns>
        int GetStat();

        /// <summary>
        /// Method search record by first name.
        /// </summary>
        /// <param name="firstName">The last name to create.</param>
        /// <returns>The collection from searching objects.</returns>
        FileCabinetRecord[] FindByFirstName(string firstName);

        /// <summary>
        /// Method search record by last name.
        /// </summary>
        /// <param name="lastName">The last name to create.</param>
        /// <returns>The collection from searching objects.</returns>
        FileCabinetRecord[] FindByLastName(string lastName);

        /// <summary>
        /// Method search record by date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The last name to create.</param>
        /// <returns>The collection from searching objects.</returns>
        FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfBirth);
    }
}
