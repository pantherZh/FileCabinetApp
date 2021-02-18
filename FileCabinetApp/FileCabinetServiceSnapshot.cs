using System;
using System.IO;

namespace FileCabinetApp
{
    /// <summary>
    /// The memory class.
    /// Save all properties of class-originator(FileCabinetService).
    /// </summary>
    public class FileCabinetServiceSnapshot
    {
        private readonly FileCabinetRecord[] records;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetServiceSnapshot"/> class.
        /// </summary>
        /// <param name="records">The list from records.</param>
        public FileCabinetServiceSnapshot(FileCabinetRecord[] records)
        {
            this.records = records;
        }

        /// <summary>
        /// Save to SCV format.
        /// </summary>
        /// <param name="streamWriter">The list from records.</param>
        public void SaveToCsv(StreamWriter streamWriter)
        {
            FileCabinetRecordCsvWriter csvWriter = new FileCabinetRecordCsvWriter(streamWriter);
            csvWriter.Write(this.records);
        }
    }
}
