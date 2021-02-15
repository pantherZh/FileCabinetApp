using System;
using System.Globalization;

namespace FileCabinetApp
{
    /// <summary>
    /// Class-validator with custom settings.
    /// </summary>
    internal class CustomValidator : IRecordValidator
    {
        /// <summary>
        /// Mrthod sets default settings.
        /// </summary>
        /// <param name="firstName">The salary to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        public Tuple<bool, string> FirstNameValidator(string firstName)
        {
            if (firstName is null)
            {
                throw new ArgumentNullException($"{nameof(firstName)} is null.");
            }

            try
            {
                if (!((firstName.Length >= 2 && firstName.Length <= 15) || string.IsNullOrWhiteSpace(firstName)))
                {
                    throw new ArgumentException($"{nameof(firstName)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<bool, string>(false, firstName);
            }

            return new Tuple<bool, string>(true, firstName);
        }

        /// <summary>
        /// Mrthod sets default settings.
        /// </summary>
        /// <param name="lastName">The salary to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        public Tuple<bool, string> LastNameValidator(string lastName)
        {
            if (lastName is null)
            {
                throw new ArgumentNullException($"{nameof(lastName)} is null.");
            }

            try
            {
                if (!((lastName.Length >= 2 && lastName.Length <= 15) || string.IsNullOrWhiteSpace(lastName)))
                {
                    throw new ArgumentException($"{nameof(lastName)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<bool, string>(false, lastName);
            }

            return new Tuple<bool, string>(true, lastName);
        }

        /// <summary>
        /// Mrthod sets default settings.
        /// </summary>
        /// <param name="birthDay">The salary to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        public Tuple<bool, string> BirhtdayValidator(DateTime birthDay)
        {
            try
            {
                DateTime date = new DateTime(1980, 1, 1);
                if (birthDay > DateTime.Now || birthDay < date)
                {
                    throw new ArgumentException($"{nameof(birthDay)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<bool, string>(false, birthDay.ToString(CultureInfo.InvariantCulture));
            }

            return new Tuple<bool, string>(true, birthDay.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Mrthod sets default settings.
        /// </summary>
        /// <param name="salary">The salary to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        public Tuple<bool, string> SalaryValidator(decimal salary)
        {
            try
            {
                if (salary > 100000 || salary < 500)
                {
                    throw new ArgumentException($"{nameof(salary)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<bool, string>(false, salary.ToString(CultureInfo.InvariantCulture));
            }

            return new Tuple<bool, string>(true, salary.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Mrthod sets default settings.
        /// </summary>
        /// <param name="key">The salary to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        public Tuple<bool, string> KeyValidator(char key)
        {
            try
            {
                if (!char.IsLetter(key))
                {
                    throw new ArgumentException($"{nameof(key)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<bool, string>(false, key.ToString(CultureInfo.InvariantCulture));
            }

            return new Tuple<bool, string>(true, key.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Mrthod sets default settings.
        /// </summary>
        /// <param name="passForCabinet">The salary to create.</param>
        /// <returns>The tuple from bool and string.</returns>
        public Tuple<bool, string> PassForCabinetValidator(short passForCabinet)
        {
            try
            {
                if (passForCabinet < 1 || passForCabinet > 9)
                {
                    throw new ArgumentException($"{nameof(passForCabinet)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return new Tuple<bool, string>(false, passForCabinet.ToString(CultureInfo.InvariantCulture));
            }

            return new Tuple<bool, string>(true, passForCabinet.ToString(CultureInfo.InvariantCulture));
        }
    }
}
