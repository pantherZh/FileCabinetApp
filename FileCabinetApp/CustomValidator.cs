﻿using System;
using System.Collections.Generic;
using System.Text;

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
        /// /// <param name="record">The salary to create.</param>
        public void ValidateParameters(FileCabinetRecord record)
        {
            if (record is null)
            {
                throw new ArgumentNullException($"{nameof(record)} is null.");
            }

            try
            {
                if (!((record.FirstName.Length >= 2 && record.FirstName.Length <= 15) || string.IsNullOrWhiteSpace(record.FirstName)))
                {
                    throw new ArgumentException($"{nameof(record.FirstName)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                FileCabinetRecord.Error = true;
            }

            try
            {
                if (!((record.LastName.Length >= 2 && record.LastName.Length <= 15) || string.IsNullOrWhiteSpace(record.LastName)))
                {
                    throw new ArgumentException($"{nameof(record.LastName)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                FileCabinetRecord.Error = true;
            }

            try
            {
                DateTime date = new DateTime(1980, 1, 1);
                if (record.DateOfBirth > DateTime.Now || record.DateOfBirth < date)
                {
                    throw new ArgumentException($"{nameof(record.DateOfBirth)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                FileCabinetRecord.Error = true;
            }

            try
            {
                if (record.Salary > 100000 || record.Salary < 500)
                {
                    throw new ArgumentException($"{nameof(record.Salary)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                FileCabinetRecord.Error = true;
            }

            try
            {
                if (!char.IsLetter(record.Key))
                {
                    throw new ArgumentException($"{nameof(record.Key)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                FileCabinetRecord.Error = true;
            }

            try
            {
                if (record.PassForCabinet < 1 || record.PassForCabinet > 9)
                {
                    throw new ArgumentException($"{nameof(record.PassForCabinet)} isn't correct.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                FileCabinetRecord.Error = true;
            }
        }
    }
}