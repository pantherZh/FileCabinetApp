using System;
using System.IO;
using System.Xml;

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

        /// <summary>
        /// Save to XML format.
        /// </summary>
        /// <param name="xmlWriter">The list from records.</param>
        public void SaveToXml(XmlWriter xmlWriter)
        {
            FileCabinetRecordXmlWriter writer = new FileCabinetRecordXmlWriter(xmlWriter);
            writer.Write(this.records);
        }
    }
}
