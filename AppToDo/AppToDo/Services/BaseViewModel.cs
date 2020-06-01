using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppToDo.Services
{
    public abstract class BaseViewModel : BindableObject
    {
        public virtual Task InitializeAsync(object param)
        {
            return Task.CompletedTask;
        }
    }
}
