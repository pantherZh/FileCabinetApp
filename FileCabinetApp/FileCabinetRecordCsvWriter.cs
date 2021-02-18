using System;
using System.Globalization;
using System.IO;

namespace FileCabinetApp
{
    /// <summary>
    /// Class-Writer in file.csv.
    /// </summary>
    public class FileCabinetRecordCsvWriter
    {
        private readonly TextWriter tw;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetRecordCsvWriter"/> class.
        /// </summary>
        /// <param name="tw">Object of TextWriter class.</param>
        public FileCabinetRecordCsvWriter(TextWriter tw)
        {
            this.tw = tw;
        }

        /// <summary>
        /// Save to SCV format.
        /// </summary>
        /// <param name="records">The list from records.</param>
        public void Write(FileCabinetRecord[] records)
        {
            if (records is null)
            {
                throw new ArgumentNullException($"{nameof(records)} is null.");
            }

            foreach (var record in records)
            {
                this.tw.WriteLine("#" + record.Id + ", " + record.FirstName + ", " + record.LastName + ", " + record.DateOfBirth.ToString("D", CultureInfo.InvariantCulture) + ", " + record.Salary + ", " + record.Key + ", " + record.PassForCabinet);
            }
        }
    }
}
