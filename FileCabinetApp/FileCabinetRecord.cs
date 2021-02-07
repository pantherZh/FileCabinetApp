﻿using System;
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
        private string firstname;
        private string lastName;
        private DateTime dateOfbirth;
        private decimal salary;
        private char key;
        private short passForCabinet;

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
        public string FirstName
        {
            get
            {
                return this.firstname;
            }

            set
            {
                try
                {
                    if (value is null)
                    {
                        throw new ArgumentNullException(nameof(value), $"{nameof(value)} is null.");
                    }

                    if (!((value.Length >= 2 && value.Length <= 60) || string.IsNullOrWhiteSpace(value)))
                    {
                        throw new ArgumentException($"{nameof(this.firstname)} isn't correct.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Error = true;
                }

                this.firstname = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of LastName.</value>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                try
                {
                    if (value is null)
                    {
                        throw new ArgumentNullException(nameof(value), $"{nameof(value)} is null.");
                    }

                    if (!((value.Length >= 2 && value.Length <= 60) || string.IsNullOrWhiteSpace(value)))
                    {
                        throw new ArgumentException($"{nameof(this.lastName)} isn't correct.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Error = true;
                }

                this.lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of DateOfBirth.</value>
        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfbirth;
            }

            set
            {
                DateTime date = new DateTime(1950, 1, 1);
                try
                {
                    if (value > DateTime.Now || value < date)
                    {
                        throw new ArgumentException($"{nameof(this.dateOfbirth)} isn't correct.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Error = true;
                }

                this.dateOfbirth = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of Salary.</value>
        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                try
                {
                    if (value > 10000 || value < 500)
                    {
                        throw new ArgumentException($"{nameof(this.salary)} isn't correct.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Error = true;
                }

                this.salary = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of Key.</value>
        public char Key
        {
            get
            {
                return this.key;
            }

            set
            {
                try
                {
                    if (value < 'A' || value > 'Z')
                    {
                        throw new ArgumentException($"{nameof(this.key)} isn't correct.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Error = true;
                }

                this.key = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets indicating whether.
        /// </summary>
        /// <value>Gets or sets the value of PassForCabinet.</value>
        public short PassForCabinet
        {
            get
            {
                return this.passForCabinet;
            }

            set
            {
                try
                {
                    if (value < 1 || value > 99)
                    {
                        throw new ArgumentException($"{nameof(this.passForCabinet)} isn't correct.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Error = true;
                }

                this.passForCabinet = value;
            }
        }
    }
}
