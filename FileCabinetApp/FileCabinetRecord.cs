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

        public int Id { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstname;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value), $"{nameof(value)} is null.");
                }

                if (!((value.Length >= 2 && value.Length <= 60) || string.IsNullOrWhiteSpace(value)))
                {
                    throw new ArgumentException($"Incorrect data entry.", nameof(value));
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
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value), $"{nameof(value)} is null.");
                }

                if (!((value.Length >= 2 && value.Length <= 60) || string.IsNullOrWhiteSpace(value)))
                {
                    throw new ArgumentException($"Incorrect data entry.", nameof(value));
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
               if (value > DateTime.Now || value < date)
               {
                  throw new ArgumentException("Incorrect data entry.", nameof(value));
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
                if (value > 10000 || value < 500)
                {
                    throw new ArgumentException("Incorrect data entry.", nameof(value));
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
                if (value < 'A' || value > 'Z')
                {
                    throw new ArgumentException("Incorrect data entry.", nameof(value));
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
                if (value < 1 || value > 99)
                {
                    throw new ArgumentException("Incorrect data entry.", nameof(value));
                }

                this.passForCabinet = value;
            }
        }
    }
}
