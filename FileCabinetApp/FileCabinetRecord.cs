using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinetApp
{
    /// <summary>
    /// The repository class.
    /// Contains all properties and fields to build a record.
    /// </summary>
    public class FileCabinetRecord
    {
        private static Dictionary<string, List<FileCabinetRecord>> firstNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();
        private static Dictionary<string, List<FileCabinetRecord>> lastNameDictionary = new Dictionary<string, List<FileCabinetRecord>>();
        private static Dictionary<DateTime, List<FileCabinetRecord>> dateOfbirthDictionary = new Dictionary<DateTime, List<FileCabinetRecord>>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of DefaultValidator.</value>
        //public static bool DefaultValidator { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of CustomValidator.</value>
        public static bool CustomValidator { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of FirstNameDictionary.</value>
        public static Dictionary<string, List<FileCabinetRecord>> FirstNameDictionary
        {
            get
            {
                return firstNameDictionary;
            }

            set
            {
                firstNameDictionary = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of LastNameDictionary.</value>
        public static Dictionary<string, List<FileCabinetRecord>> LastNameDictionary
        {
            get
            {
                return lastNameDictionary;
            }

            set
            {
                lastNameDictionary = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of DateOfBirthDictionary.</value>
        public static Dictionary<DateTime, List<FileCabinetRecord>> DateOfBirthDictionary
        {
            get
            {
                return dateOfbirthDictionary;
            }

            set
            {
                dateOfbirthDictionary = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of Error.</value>
        public static bool Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of Id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of FirstName.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of LastName.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of DateOfBirth.</value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of Salary.</value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of Key.</value>
        public char Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of PassForCabinet.</value>
        public short PassForCabinet { get; set; }
    }
}
