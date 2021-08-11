using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Class that represents quarter for items from different categories
    /// </summary>
    public class TodoQuarter
    {
        /// <summary>
        /// Gets or sets list of items
        /// </summary>
        public List<TodoItem> Items { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoQuarter"/> class.
        /// </summary>
        public TodoQuarter()
        {
            Items = new List<TodoItem>();
        }

        /// <summary>
        /// Add item to list
        /// </summary>
        /// <param name="title">title of item</param>
        /// <param name="deadline">deadline of item</param>
        public void AddItem(string title, DateTime deadline)
        {
            TodoItem newItem = new TodoItem(title, deadline);
            Items.Add(newItem);
            SortToDoItems();
        }

        /// <summary>
        /// Add item to list
        /// </summary>
        /// <param name="title">title of item</param>
        /// <param name="deadline">deadline of item</param>
        /// <param name="isImportant">boolean that indicates whenever item is important or not</param>
        public void AddItem(string title, DateTime deadline, bool isImportant)
        {
            TodoItem newItem = new TodoItem(title, deadline, isImportant);
            Items.Add(newItem);
            SortToDoItems();
        }

        /// <summary>
        /// Removes item instance under given index
        /// </summary>
        /// <param name="index">index of </param>
        public void RemoveItem(int index)
        {
            Items.RemoveAt(index);
        }

        /// <summary>
        /// Destroys all done items
        /// </summary>
        public void ArchiveItems()
        {
            foreach (TodoItem item in Items.ToList())
            {
                if (item.IsDone)
                {
                    Items.Remove(item);
                }
            }
        }

        /// <summary>
        /// Returns human readable representation of quarter
        /// </summary>
        /// <returns>string with all nested items</returns>
        public override string ToString()
        {
            List<TodoItem> sorted = Items.ToList();
            StringBuilder quarterRepresentation = new StringBuilder();
            foreach (TodoItem item in sorted)
            {
                quarterRepresentation.Append($"\nTask {sorted.IndexOf(item) + 1}: {item}");
            }

            return quarterRepresentation.ToString();
        }

        /// <summary>
        /// Sorts tasks in ascending order according to deadline
        /// </summary>
        private void SortToDoItems()
        {
            Items = Items.OrderBy(i => i.Deadline).ToList();
        }
    }
}