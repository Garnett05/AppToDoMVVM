using AppToDo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AppToDo.Models;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;

namespace AppToDo.ViewModels
{
    public class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress;
        public event EventHandler<double> UpdateProgressBar;
        public ObservableCollection<ToDoItem> Items { get; set; }
        public string PageTitle { get; set; }
        public ToDoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }
        public ICommand AddItemCommand => new Command(() => AddNewCommand());
        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(MarkAsCompleted);
        public string CompletedHeader
        {
            get { return _completedHeader; }
            set
            {
                _completedHeader = value;
                OnPropertyChanged();
            }
        }
        public double CompletedProgress
        {
            get { return _completedProgress; }
            set
            {
                _completedProgress = value;
                OnPropertyChanged();
            }
        }
        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
            CalculateCompletedHeader();
        }
        private void MarkAsCompleted(ToDoItem obj)
        {
            obj.Completed = true;
            Items.Remove(obj);
            Items.Add(obj);
            CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            CompletedHeader = $"Completed { Items.Count(x => x.Completed)}/{ Items.Count}";
            CompletedProgress = (double)Items.Count(x => x.Completed) / (double)Items.Count;
            UpdateProgressBar?.Invoke(this, CompletedProgress);
        }

        private void AddNewCommand()
        {
            Items.Add(new ToDoItem($"ToDo Item {Items.Count + 1}"));
            CalculateCompletedHeader();
        }
    }
}
