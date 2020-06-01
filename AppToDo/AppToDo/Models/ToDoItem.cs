using System;
using System.Collections.Generic;
using System.Text;

namespace AppToDo.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        public ToDoItem(string name)
        {
            Name = name;
        }
        public static IEnumerable<ToDoItem> GetToDoItems()
        {
            return new List<ToDoItem>();
        }
    }
}
