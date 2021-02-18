using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace FileCabinetApp
{
    /// <summary>
    /// Class-Writer in file.xml.
    /// </summary>
    public class FileCabinetRecordXmlWriter
    {
        private readonly XmlWriter xmlWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetRecordXmlWriter"/> class.
        /// </summary>
        /// <param name="xw">Object of XmlWriter class.</param>
        public FileCabinetRecordXmlWriter(XmlWriter xw)
        {
            this.xmlWriter = xw;
        }

        /// <summary>
        /// Save to XML format.
        /// </summary>
        /// <param name="records">The list from records.</param>
        public void Write(FileCabinetRecord[] records)
        {
            if (records is null)
            {
                throw new ArgumentNullException($"{nameof(records)} is null.");
            }

            this.xmlWriter.WriteStartDocument();
            this.xmlWriter.WriteStartElement("records");
            foreach (var record in records)
            {
                this.xmlWriter.WriteStartElement("record");
                this.xmlWriter.WriteAttributeString("id", record.Id.ToString(CultureInfo.InvariantCulture));
                this.xmlWriter.WriteElementString($"firstName", record.FirstName);
                this.xmlWriter.WriteElementString($"lastName", record.FirstName);
                this.xmlWriter.WriteElementString($"dateOfBirth", record.DateOfBirth.ToString(CultureInfo.InvariantCulture));
                this.xmlWriter.WriteElementString($"salary", record.Salary.ToString(CultureInfo.InvariantCulture));
                this.xmlWriter.WriteElementString($"key", record.Key.ToString(CultureInfo.InvariantCulture));
                this.xmlWriter.WriteElementString($"passForCabinet", record.PassForCabinet.ToString(CultureInfo.InvariantCulture));
            }

            this.xmlWriter.WriteEndDocument();
            this.xmlWriter.Close();
        }
    }
}
