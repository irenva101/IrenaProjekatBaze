using IrenaProjekatBaze.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IrenaProjekatBaze.View
{
    /// <summary>
    /// Interaction logic for LoggedView.xaml
    /// </summary>
    public partial class LoggedView : Window
    {
        private ProjekatBaze2Context bazecontext = new ProjekatBaze2Context();
        private CollectionViewSource autobusViewSource;
        private CollectionViewSource automobilViewSource;
        private CollectionViewSource kombiViewSource;
        private CollectionViewSource korisnikViewSource;
        private CollectionViewSource putnikViewSource;
        private CollectionViewSource rezervacijaViewSource;
        private CollectionViewSource rutaViewSource;
        private CollectionViewSource terminViewSource;
        private CollectionViewSource uplataViewSource;
        private CollectionViewSource vozacViewSource;
        private CollectionViewSource voziViewSource;
        private CollectionViewSource voziloViewSource;
        //private CollectionViewSource sekreceViewSource;
        public LoggedView(string user, string pass)
        {
            InitializeComponent();

            autobusViewSource = (CollectionViewSource)FindResource(nameof(autobusViewSource));
            automobilViewSource = (CollectionViewSource)FindResource(nameof(automobilViewSource));
            kombiViewSource = (CollectionViewSource)FindResource(nameof(kombiViewSource));
            korisnikViewSource = (CollectionViewSource)FindResource(nameof(korisnikViewSource));
            putnikViewSource=(CollectionViewSource)FindResource(nameof(putnikViewSource));
            rezervacijaViewSource= (CollectionViewSource)FindResource(nameof(rezervacijaViewSource));
            rutaViewSource= (CollectionViewSource)FindResource(nameof(rutaViewSource));
            terminViewSource= (CollectionViewSource)FindResource(nameof(terminViewSource));
            uplataViewSource= (CollectionViewSource)FindResource(nameof(uplataViewSource));
            vozacViewSource= (CollectionViewSource)FindResource(nameof(vozacViewSource));
            voziViewSource= (CollectionViewSource)FindResource(nameof(voziViewSource));
            voziloViewSource= (CollectionViewSource)FindResource(nameof(voziloViewSource));
            //sekreceViewSource= (CollectionViewSource)FindResource(nameof(sekreceViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bazecontext.Autobus.Load();
            bazecontext.Automobils.Load();
            bazecontext.Kombis.Load();
            bazecontext.Korisniks.Load();
            bazecontext.Putniks.Load();
            bazecontext.Rezervacijas.Load();
            bazecontext.Ruta.Load();
            bazecontext.Termins.Load();
            bazecontext.Uplata.Load();  
            bazecontext.Vozacs.Load();
            bazecontext.Vozis.Load();
            bazecontext.Vozilos.Load();

            autobusViewSource.Source = bazecontext.Autobus.Local.ToObservableCollection();
            automobilViewSource.Source = bazecontext.Automobils.Local.ToObservableCollection();
            kombiViewSource.Source = bazecontext.Kombis.Local.ToObservableCollection();
            korisnikViewSource.Source=bazecontext.Korisniks.Local.ToObservableCollection();
            putnikViewSource.Source = bazecontext.Putniks.Local.ToObservableCollection();
            rezervacijaViewSource.Source=bazecontext.Rezervacijas.Local.ToObservableCollection();
            rutaViewSource.Source=bazecontext.Ruta.Local.ToObservableCollection();
            terminViewSource.Source=bazecontext.Termins.Local.ToObservableCollection();
            uplataViewSource.Source=bazecontext.Uplata.Local.ToObservableCollection();
            vozacViewSource.Source=bazecontext.Vozacs.Local.ToObservableCollection();
            //voziViewSource.Source=bazecontext.Vozis.Local.ToObservableCollection();
            voziloViewSource.Source=bazecontext.Vozilos.Local.ToObservableCollection();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bazecontext.Dispose();
        }

        private void Snimi_Button_Click(object sender, RoutedEventArgs e)
        {
            int n = bazecontext.SaveChanges();

            AutobusiDataGrid.Items.Refresh();
            AutomobiliDataGrid.Items.Refresh();
            KombiDataGrid.Items.Refresh();
            PutniciDataGrid.Items.Refresh();
            RezervacijeDataGrid.Items.Refresh();
            RuteDataGrid.Items.Refresh();
            TerminiDataGrid.Items.Refresh();
            UplateDataGrid.Items.Refresh();
            VozaciDataGrid.Items.Refresh();
            //VoziDataGrid.Items.Refresh();
            VozilaDataGrid.Items.Refresh();

            MessageBox.Show("Broj izvršenih zapisa: " + n, "Snimanje");
        }
    }
}
