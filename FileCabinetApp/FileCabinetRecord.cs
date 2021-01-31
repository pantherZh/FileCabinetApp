using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinetApp
{
    public class FileCabinetRecord
    {
        private string firstname;
        private string lastName;
        private DateTime dateOfbirth;
        private decimal salary;
        private char key;
        private short passForCabinet;

        public static bool Error { get; set; }

        public int Id { get; set; }

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
