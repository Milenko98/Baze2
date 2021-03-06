using Servis.Baza;
using Servis.PomocneKlase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModel
{
    public class AddObezbedjenjeViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddObezbedjenjeCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedbolnica;

        public string SelectedBolnica
        {
            get { return selectedbolnica; }
            set { selectedbolnica = value; OnPropertyChanged("SelectedBolnica"); }
        }

        private string selectedMesto;

        public string SelectedMesto
        {
            get { return selectedMesto; }
            set { selectedMesto = value; OnPropertyChanged("SelectedMesto"); }
        }

        public Obezbedjenje CreatedObezbedjenje { get; set; }

        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }

        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }

        private string radni_staz;

        public string Radni_staz
        {
            get { return radni_staz; }
            set { radni_staz = value; OnPropertyChanged("Radni_staz"); }
        }

        private ObservableCollection<string> bolnice;

        public ObservableCollection<string> Bolnice
        {
            get { return bolnice; }
            set { bolnice = value; }
        }

        private ObservableCollection<string> mesta;

        public ObservableCollection<string> Mesta
        {
            get { return mesta; }
            set { mesta = value; }
        }

        private string imelbl;

        public string Imelbl
        {
            get { return imelbl; }
            set { imelbl = value; OnPropertyChanged("Imelbl"); }
        }

        private string prezimelbl;

        public string Prezimelbl
        {
            get { return prezimelbl; }
            set { prezimelbl = value; OnPropertyChanged("Prezimelbl"); }
        }

        private string radnistazlbl;

        public string Radnistazlbl
        {
            get { return radnistazlbl; }
            set { radnistazlbl = value; OnPropertyChanged("Radnistazlbl"); }
        }




        public AddObezbedjenjeViewModel(Obezbedjenje obezbedjenje)
        {
            CreatedObezbedjenje = obezbedjenje;
            List<Bolnica> bolnicee = new List<Bolnica>();
            List<Mesto> mestaa = new List<Mesto>();
            ObservableCollection<string> dobavljene = new ObservableCollection<string>();
            ObservableCollection<string> dobavljenaMesta = new ObservableCollection<string>();
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            bolnicee = bs.GetAll();
            foreach (var item in bolnicee)
            {
                dobavljene.Add(item.Naziv);
            }
            Bolnice = dobavljene;

            selectedbolnica = Bolnice[0];

            mestaa = ms.GetAll();
            foreach (var item in mestaa)
            {
                dobavljenaMesta.Add(item.Naziv);
            }
            Mesta = dobavljenaMesta;

            selectedMesto = Mesta[0];
            AddObezbedjenjeCommand = new MyICommand(OnAddObezbedjenje);
            if (obezbedjenje != null)
            {
                ime = obezbedjenje.Ime;
                prezime = obezbedjenje.Prezime;
                radni_staz = obezbedjenje.Radni_staz.ToString();
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddObezbedjenje()
        {
            Servis.InterfejsServisi.ObezbedjenjeServis os = new Servis.InterfejsServisi.ObezbedjenjeServis();
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            Obezbedjenje ob = new Obezbedjenje();
            if (CreatedObezbedjenje == null)
            {
                Imelbl = "";
                Prezimelbl = "";
                Radnistazlbl = "";
                if (String.IsNullOrWhiteSpace(Ime))
                    Imelbl = "Morate uneti ime!";
                else if (int.TryParse(Ime, out _))
                    Imelbl = "Ime ne moze biti broj!";
                else if (Ime.Length < 3)
                    Imelbl = "Ime mora sadrzati bar 3 slova!";
                else if (String.IsNullOrWhiteSpace(Prezime))
                    Prezimelbl = "Morate uneti prezime!";
                else if (int.TryParse(Prezime, out _))
                    Prezimelbl = "Prezime ne moze biti broj!";
                else if (Prezime.Length < 3)
                    Prezimelbl = "Prezime mora sadrzati bar 3 slova!";
                else if (String.IsNullOrWhiteSpace(Radni_staz))
                    Radnistazlbl = "Morate uneti radni staz!";
                else if (!int.TryParse(Radni_staz, out _))
                    Radnistazlbl = "Radni staz mora biti broj!";
                else if (int.Parse(Radni_staz) > 80)
                    Radnistazlbl = "Radni staz ne moze biti veci od 80 godina!";
                else
                {
                    Random r = new Random();
                    int jmbgRandom = r.Next(0, 200);
                    Obezbedjenje provera = new Obezbedjenje();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = os.FindById(jmbgRandom);

                    } while (pronadjen != null);

                    ob.Jmbg = jmbgRandom;
                    ob.Ime = ime;
                    ob.Prezime = prezime;
                    ob.Radni_staz = radni_staz;
                    ob.BolnicaOznaka_B = bs.FindByName(SelectedBolnica);
                    ob.MestoP_Broj = ms.FindByName(selectedMesto);

                    if (os.Insert(ob))
                    {

                        MessageBox.Show("Obezbedjenje uspešno dodato.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom dodavanja.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Window.Close();
                    }
                }

            }
            else
            {
                Imelbl = "";
                Prezimelbl = "";
                Radnistazlbl = "";
                if (String.IsNullOrWhiteSpace(Ime))
                    Imelbl = "Morate uneti ime!";
                else if (int.TryParse(Ime, out _))
                    Imelbl = "Ime ne moze biti broj!";
                else if (Ime.Length < 3)
                    Imelbl = "Ime mora sadrzati bar 3 slova!";
                else if (String.IsNullOrWhiteSpace(Prezime))
                    Prezimelbl = "Morate uneti prezime!";
                else if (int.TryParse(Prezime, out _))
                    Prezimelbl = "Prezime ne moze biti broj!";
                else if (Prezime.Length < 3)
                    Prezimelbl = "Prezime mora sadrzati bar 3 slova!";
                else if (String.IsNullOrWhiteSpace(Radni_staz))
                    Radnistazlbl = "Morate uneti radni staz!";
                else if (!int.TryParse(Radni_staz, out _))
                    Radnistazlbl = "Radni staz mora biti broj!";
                else if (int.Parse(Radni_staz) > 80)
                    Radnistazlbl = "Radni staz ne moze biti veci od 80 godina!";
                else
                {
                    CreatedObezbedjenje.Ime = ime;
                    CreatedObezbedjenje.Prezime = prezime;
                    CreatedObezbedjenje.Radni_staz = radni_staz;
                    CreatedObezbedjenje.BolnicaOznaka_B = bs.FindByName(SelectedBolnica);
                    if (os.Update(CreatedObezbedjenje))
                    {
                        MessageBox.Show("Recepcioner uspešno izmenjen.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom izmene.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Window.Close();
                    }
                }
            }
        }
    }
}
