using AppToDo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoView : ContentPage
    {
        public ToDoView()
        {
            InitializeComponent();
            ToDoViewModel toDoVM = new ToDoViewModel();
            BindingContext = toDoVM;
            toDoVM.UpdateProgressBar += ToDoViewModel_UpdateProgressBar;
        }

        private void ToDoViewModel_UpdateProgressBar(object sender, double e)
        {
            progressBar.ProgressTo(e, 300, Easing.Linear);
        }
    }
}