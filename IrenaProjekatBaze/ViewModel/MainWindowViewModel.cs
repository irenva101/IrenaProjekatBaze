using IrenaProjekatBaze.Command;
using IrenaProjekatBaze.Models;
using IrenaProjekatBaze.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IrenaProjekatBaze.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            LogInCommand = new LogInCommand(this);

            
            //GuestCommand = new GuestCommand(this);
            //OpenCACommand = new OpenCACommand(this);
        }
        public Window? Window { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
        public ICommand LogInCommand
        {
            get;
            private set;
        }

        public bool CanLogIn
        {
            get
            {
                return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password);
            }

        }
        public void LogIn()
        {
            var optionBuilder = new DbContextOptionsBuilder<ProjekatBaze2Context>();
            optionBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ProjekatBaze2ConnectionString"].ConnectionString);
            using (var db = new ProjekatBaze2Context(optionBuilder.Options))
            {
                //List<Korisnik> lk = db.Korisniks.ToList();
                Korisnik k = db.Korisniks.FirstOrDefault(x => x.Username == Username);
                if (k == null)
                {
                    MessageBox.Show("Username doesn't exist in base! Try again!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    new LoggedView(Username, Password).Show();
                    Window.Close();
                }
            }
        }


    }
    
}
