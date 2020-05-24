using AppToDo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AppToDo.Models;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace AppToDo.ViewModels
{
    public class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;
        public ObservableCollection<ToDoItem> Items { get; set; }
        public string PageTitle { get; set; }
        public ToDoItem SelectedItem {
            get { return _selectedItem; } 
            set { _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            } }
        public ICommand AddItemCommand => new Command(() => AddNewCommand());
        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(MarkAsCompleted);

        private void MarkAsCompleted(ToDoItem obj)
        {
            obj.Completed = true;
        }

        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
        }
        private void AddNewCommand()
        {
            Items.Add(new ToDoItem($"ToDo Item {Items.Count + 1}"));
        }
    }
}
