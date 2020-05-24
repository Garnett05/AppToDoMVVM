using AppToDo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AppToDo.Models;
using System.ComponentModel;
using Xamarin.Forms;

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
        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
        }
    }
}
