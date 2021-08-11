using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Top level class for Matrix
    /// </summary>
    public class TodoMatrix
    {
        /// <summary>
        /// Gets or sets dictionary with quarters
        /// </summary>
        public Dictionary<string, TodoQuarter> Quarters { get; set; }

        /// <summary>
        /// Gets or sets dictionary with quarters
        /// </summary>
        public static string[] AvailableQuarters = { "Important & urgent", "Important & not urgent", "Not important & urgent", "Not important & not urgent" };

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoMatrix"/> class.
        /// </summary>
        public TodoMatrix()
        {
            Quarters = new Dictionary<string, TodoQuarter>();
            CreateQuarters();
        }

        /// <summary>
        /// Creates new item based on given parameters
        /// </summary>
        /// <param name="title">title for new task</param>
        /// <param name="date">deadline for new task</param>
        /// <param name="isImportant">boolean value that indicates whenever task is important or not</param>
        public void AddItem(string title, DateTime date, bool isImportant = false)
        {
            if (date.Subtract(DateTime.Now).TotalDays <= 3 && isImportant)
            {
                Quarters[AvailableQuarters[0]].AddItem(title, date, isImportant);
            }
            else if (date.Subtract(DateTime.Now).TotalDays > 3 && isImportant)
            {
                Quarters[AvailableQuarters[1]].AddItem(title, date, isImportant);
            }
            else if (date.Subtract(DateTime.Now).TotalDays <= 3 && !isImportant)
            {
                Quarters[AvailableQuarters[2]].AddItem(title, date, isImportant);
            }
            else
            {
                Quarters[AvailableQuarters[3]].AddItem(title, date, isImportant);
            }
        }

        /// <summary>
        /// Deletes all items that are marked as done
        /// </summary>
        public void ArchiveItems()
        {
            foreach (KeyValuePair<string, TodoQuarter> item in Quarters)
            {
                item.Value.ArchiveItems();
            }
        }

        /// <summary>
        /// Reads the content from given file, creates and add item to given quarter
        /// </summary>
        /// <param name="filePath">string with path leading to source file</param>
        public void AddItemsFromFile(string filePath)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = "|",
                TrimOptions = TrimOptions.Trim,
            };
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, csvConfig);
            var records = csv.GetRecords<TodoItem>().ToList();
            foreach (var item in records)
            {
                AddItem(item.Title, item.Deadline, item.IsImportant);
            }
        }

        /// <summary>
        /// Saves current matrix content to file
        /// </summary>
        /// <param name="filePath">file path under all task will be saved</param>
        public void SaveItemsToFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = " | ",
                };
                using var writer = new StreamWriter(filePath);
                using var csv = new CsvWriter(writer, csvConfig);
                for (int i = 0; i < 4; i++)
                {
                    foreach (var item in Quarters[AvailableQuarters[i]].Items)
                    {
                        csv.WriteField(item.Title);
                        csv.WriteField(item.Deadline);
                        csv.WriteField(item.IsImportant);
                        csv.NextRecord();
                    }
                }

                writer.Flush();
            }
        }

        /// <summary>
        /// Returns human readable representation for matrix
        /// </summary>
        /// <returns>string with all quarters and associated items</returns>
        public override string ToString()
        {
            StringBuilder matrixString = new StringBuilder();
            foreach (var item in Quarters.Keys)
            {
                matrixString.Append($"\n{item}: {Quarters[item]}\n");
            }

            return matrixString.ToString();
        }

        private DateTime ConvertToDateFrom(string representation)
        {
            return DateTime.Parse(representation);
        }

        private void CreateQuarters()
        {
            Quarters[AvailableQuarters[0]] = new TodoQuarter();
            Quarters[AvailableQuarters[1]] = new TodoQuarter();
            Quarters[AvailableQuarters[2]] = new TodoQuarter();
            Quarters[AvailableQuarters[3]] = new TodoQuarter();
        }
    }
}