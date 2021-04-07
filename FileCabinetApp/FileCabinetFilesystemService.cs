using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileCabinetApp
{
    /// <summary>
    /// The data manipulation class.
    /// Contains all methods for manipulating records.
    /// </summary>
    public class FileCabinetFilesystemService : IFileCabinetService
    {
        private readonly FileStream fileStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileCabinetFilesystemService"/> class.
        /// </summary>
        /// <param name="fileStream">The list from records.</param>
        public FileCabinetFilesystemService(FileStream fileStream)
        {
            this.fileStream = fileStream;
        }

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
        public int CreateRecord(string firstName, string lastName, DateTime dateOfBirth, decimal salary, char key, short passForCabinet)
        {
            int id = this.GetStat() + 1;
            byte[] info = new UTF8Encoding(true).GetBytes(id + " " + firstName + " " + lastName + " " + dateOfBirth.ToShortDateString() + " " + salary + " " + key + " " + passForCabinet + '\n');
            this.fileStream.Seek(0, SeekOrigin.End);
            this.fileStream.Write(info, 0, info.Length);

            return id;
        }

        /// <summary>
        /// Method of editing record.
        /// </summary>
        /// <param name="id">The first name to create.</param>
        /// <returns>The collection from searching objects.</returns>
        public bool EditRecord(int id)
        {
            var records = this.ParseFile();
            FileCabinetRecord record = new FileCabinetRecord();
            record.Id = id;
            Console.Write("First Name: ");
            record.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            record.LastName = Console.ReadLine();
            Console.Write("Date Time(MM/dd/yyyy): ");
            _ = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
            Console.Write("Salary: ");
            _ = decimal.TryParse(Console.ReadLine(), out decimal salary);
            Console.Write("Key(A-Z): ");
            _ = char.TryParse(Console.ReadLine(), out char key);
            Console.Write("Password for Cabinet: ");
            _ = short.TryParse(Console.ReadLine(), out short passForCabinet);
            record.DateOfBirth = dateOfBirth;
            record.Salary = salary;
            record.Key = key;
            record.PassForCabinet = passForCabinet;

            try
            {
                records.SetValue(record, id - 1);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

            this.fileStream.SetLength(0);
            StringBuilder text = new StringBuilder();
            foreach (var rec in records)
            {
                text.Append(rec.Id + " " + rec.FirstName + " " + rec.LastName + " " + rec.DateOfBirth.ToShortDateString() + " " + rec.Salary + " " + rec.Key + " " + rec.PassForCabinet + '\n');
            }

            byte[] info = new UTF8Encoding(true).GetBytes(text.ToString());
            this.fileStream.Seek(0, SeekOrigin.End);
            this.fileStream.Write(info, 0, info.Length);

            return true;
        }

        /// <summary>
        /// Method of returning collection.
        /// </summary>
        /// <returns>The collection from FileCabinetRecord objects.</returns>
        public int GetRecords()
        {
            this.fileStream.Seek(0, SeekOrigin.Begin);
            byte[] output = new byte[this.fileStream.Length];
            this.fileStream.Read(output, 0, output.Length);
            string textFromFile = Encoding.Default.GetString(output);

            Console.WriteLine(textFromFile);

            int count = 0;
            for (int i = 0; i < textFromFile.Length; i++)
            {
                if (textFromFile[i] == '\n')
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Method of returning status of list.
        /// </summary>
        /// <returns>The quantity of records.</returns>
        public int GetStat()
        {
            this.fileStream.Seek(0, SeekOrigin.Begin);
            byte[] output = new byte[this.fileStream.Length];
            this.fileStream.Read(output, 0, output.Length);
            string textFromFile = Encoding.Default.GetString(output);

            int count = 0;
            for (int i = 0; i < textFromFile.Length; i++)
            {
                if (textFromFile[i] == '\n')
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Method search record by first name.
        /// </summary>
        /// <param name="firstName">The last name to create.</param>
        /// <returns>The collection from searching objects.</returns>
        public FileCabinetRecord[] FindByFirstName(string firstName)
        {
            if (firstName is null)
            {
                throw new ArgumentNullException($"{nameof(firstName)} is null.");
            }

            List<FileCabinetRecord> records = new List<FileCabinetRecord>();
            foreach (var rec in this.ParseFile())
            {
                if (firstName == rec.FirstName)
                {
                    records.Add(rec);
                }
            }

            return records.ToArray();
        }

        /// <summary>
        /// Method search record by last name.
        /// </summary>
        /// <param name="lastName">The last name to create.</param>
        /// <returns>The collection from searching objects.</returns>
        public FileCabinetRecord[] FindByLastName(string lastName)
        {
            if (lastName is null)
            {
                throw new ArgumentNullException($"{nameof(lastName)} is null.");
            }

            List<FileCabinetRecord> records = new List<FileCabinetRecord>();
            foreach (var rec in this.ParseFile())
            {
                if (lastName == rec.LastName)
                {
                    records.Add(rec);
                }
            }

            return records.ToArray();
        }

        /// <summary>
        /// Method search record by date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The last name to create.</param>
        /// <returns>The collection from searching objects.</returns>
        public FileCabinetRecord[] FindByDateOfBirth(DateTime dateOfBirth)
        {
            List<FileCabinetRecord> records = new List<FileCabinetRecord>();
            foreach (var rec in this.ParseFile())
            {
                if (dateOfBirth == rec.DateOfBirth)
                {
                    records.Add(rec);
                }
            }

            return records.ToArray();
        }

        /// <summary>
        /// Parse Data.
        /// </summary>
        /// <returns>The array of records.</returns>
        public FileCabinetRecord[] ParseFile()
        {
            this.fileStream.Seek(0, SeekOrigin.Begin);
            byte[] output = new byte[this.fileStream.Length];
            this.fileStream.Read(output, 0, output.Length);
            string textFromFile = Encoding.Default.GetString(output);

            List<FileCabinetRecord> records = new List<FileCabinetRecord>();

            char[] separators = new char[] { ' ', '\n' };
            string[] subs = textFromFile.Split(separators);

            for (int i = 0; i < subs.Length; i++)
            {
                if (i != 0 && i % 7 == 0)
                {
                    var record = new FileCabinetRecord();
                    _ = int.TryParse(subs[i - 7], out int id);
                    record.Id = id;
                    record.FirstName = subs[i - 6];
                    record.LastName = subs[i - 5];
                    _ = DateTime.TryParse(subs[i - 4], out DateTime dateOfbirth);
                    record.DateOfBirth = dateOfbirth;
                    _ = decimal.TryParse(subs[i - 3], out decimal salary);
                    record.Salary = salary;
                    _ = char.TryParse(subs[i - 2], out char key);
                    record.Key = key;
                    _ = short.TryParse(subs[i - 1], out short passForCabinet);
                    record.PassForCabinet = passForCabinet;
                    records.Add(record);
                }
            }

            return records.ToArray();
        }
    }
}
