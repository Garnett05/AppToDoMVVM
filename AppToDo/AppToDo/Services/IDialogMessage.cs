using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppToDo.Services
{
    public interface IDialogMessage
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<string> DisplayPrompt(string title, string message);
        Task<string> DisplayActionSheet(string title, string description, params string[] buttons);
    }
}
