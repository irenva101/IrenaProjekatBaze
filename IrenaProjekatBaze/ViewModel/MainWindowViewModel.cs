using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IrenaProjekatBaze.ViewModel
{
    public class MainWindowModel
    {
        //public MainWindowViewModel()
        //{
        //    //LogInCommand = new LogInCommand(this);
        //    //GuestCommand = new GuestCommand(this);
        //    //OpenCACommand = new OpenCACommand(this);
        //}
        public Window? Window { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }

        public bool CanLogIn
        {
            get
            {
                return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password);
            }
        }

       
    }
    
}
