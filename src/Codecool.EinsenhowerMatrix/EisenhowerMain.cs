using System;
using System.Collections.Generic;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Main class for program
    /// </summary>
    public class EisenhowerMain
    {
        /// <summary>
        /// Runs program with basic user UI
        /// </summary>
        public void Run()
        {
            TodoMatrix matrix = new TodoMatrix();
            string path = @"C:\Users\CTNW74\Desktop\projects\einsenhower-matrix-csharp-SylwiaLeung\src\Codecool.EinsenhowerMatrix\tasks.txt";
            matrix.AddItemsFromFile(path);
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nPlease select option:\n1 - Create a new task\n2 - Display all tasks\n3 - Mark task as done\n4 - Delete task\n5 - Archive completed tasks\n0 - Exit");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Insert title of the new task:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Insert deadline of the new task in format dd/MM/YYYY:");
                        DateTime deadline = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Do you want to mark the task as important? Y/N");
                        bool isImportant = Console.ReadLine().ToUpper().Trim() == "Y";
                        matrix.AddItem(title, deadline, isImportant);
                        Console.WriteLine("The task has been successfully added.");
                        break;
                    case "2":
                        Console.WriteLine(matrix.ToString());
                        break;
                    case "3":
                        string chosenQuarterNumber = SelectQuarter(matrix);
                        string chosenQuarterName = TodoMatrix.AvailableQuarters[Convert.ToInt32(chosenQuarterNumber) - 1];
                        Console.WriteLine(matrix.Quarters[chosenQuarterName].ToString());
                        Console.WriteLine("Select task number if you want to mark/unmark it as completed - or any other number to go back to the main menu.");
                        int taskToMark = int.Parse(Console.ReadLine());
                        MarkTask(matrix, taskToMark, chosenQuarterName);
                        break;
                    case "4":
                        string quarterNumber = SelectQuarter(matrix);
                        string quarterName = TodoMatrix.AvailableQuarters[Convert.ToInt32(quarterNumber) - 1];
                        Console.WriteLine(matrix.Quarters[quarterName].ToString());
                        Console.WriteLine("Select task number if you want to delete it - or any other number to go back to main menu");
                        int taskToDelete = int.Parse(Console.ReadLine());
                        DeleteTask(matrix, quarterName, taskToDelete);
                        Console.WriteLine("The task has been removed.");
                        break;
                    case "5":
                        Console.WriteLine("Do you want to archive all completed tasks (press 1) or from the selected quarter (press 2)?");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            matrix.ArchiveItems();
                            Console.WriteLine("All completed tasks have been archived.");
                        }
                        else if (choice == 2)
                        {
                            ArchiveTasks(matrix);
                            Console.WriteLine("All completed tasks from the chosen quarter have been archived.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }

                        break;
                    case "0":
                        isRunning = false;
                        break;
                }
            }

            matrix.SaveItemsToFile(path);
        }

        /// <summary>
        /// Displays available quarters to choose from
        /// </summary>
        /// <param name="matrix">current matrix object</param>
        /// <returns>Number of the chosen quarter in a string format</returns>
        public string SelectQuarter(TodoMatrix matrix)
        {
            var availableQuarters = TodoMatrix.AvailableQuarters;
            Console.WriteLine($"Please select the quarter:\n1 - {availableQuarters[0]} ({matrix.Quarters[availableQuarters[0]].Items.Count} task(s))\n2 - {availableQuarters[1]} ({matrix.Quarters[availableQuarters[1]].Items.Count} task(s))\n3 - {availableQuarters[2]} ({matrix.Quarters[availableQuarters[2]].Items.Count} task(s))\n4 - {availableQuarters[3]} ({matrix.Quarters[availableQuarters[3]].Items.Count} task(s))");
            string selectedQuarter = Console.ReadLine();
            return selectedQuarter;
        }

        /// <summary>
        /// Marks / unmarks chosen task as done
        /// </summary>
        /// <param name="matrix">current matrix object</param>
        /// <param name="taskToMark">task number to mark/unmark</param>
        /// <param name="chosenQuarter">quarter name</param>
        public void MarkTask(TodoMatrix matrix, int taskToMark, string chosenQuarter)
        {
            var taskList = matrix.Quarters[chosenQuarter].Items;
            if (taskToMark == 0 || taskToMark > taskList.Count)
            {
                return;
            }

            if (taskList[taskToMark - 1].IsDone)
            {
                taskList[taskToMark - 1].UnMark();
                Console.WriteLine("Task has been unmarked as completed.");
            }
            else
            {
                taskList[taskToMark - 1].Mark();
                Console.WriteLine("Task has been marked as completed.");
            }
        }

        /// <summary>
        /// Archives tasks from the chosen quarter
        /// </summary>
        /// <param name="matrix">current matrix object</param>
        public void ArchiveTasks(TodoMatrix matrix)
        {
            string quarterNumber = SelectQuarter(matrix);
            string chosenQuarter = TodoMatrix.AvailableQuarters[Convert.ToInt32(quarterNumber) - 1];
            matrix.Quarters[chosenQuarter].ArchiveItems();
        }

        /// <summary>
        /// Deletes task from the chosen quarter
        /// </summary>
        /// <param name="matrix">current matrix object</param>
        /// <param name="quarter">quarter name</param>
        /// <param name="task">task number to delete</param>
        public void DeleteTask(TodoMatrix matrix, string quarter, int task)
        {
            var taskList = matrix.Quarters[quarter].Items;
            if (task == 0 || task > taskList.Count)
            {
                return;
            }
            else
            {
                matrix.Quarters[quarter].RemoveItem(task - 1);
            }
        }
    }
}
