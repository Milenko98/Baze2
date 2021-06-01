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
    public class AddRecepcionerViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddRecepcionerCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedBolnica;

        public string SelectedBolnica
        {
            get { return selectedBolnica; }
            set { selectedBolnica = value; OnPropertyChanged("SelectedBolnica"); }
        }

        private string selectedMesto;

        public string SelectedMesto
        {
            get { return selectedMesto; }
            set { selectedMesto = value; OnPropertyChanged("SelectedMesto"); }
        }

        public Recepcioner CreatedRecepcioner { get; set; }

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




        public AddRecepcionerViewModel(Recepcioner recepcioner)
        {
            CreatedRecepcioner = recepcioner;
            List<Bolnica> bolnicee = new List<Bolnica>();
            List<Mesto> mestaa = new List<Mesto>();
            ObservableCollection<string> dobavljene = new ObservableCollection<string>();
            ObservableCollection<string> dobavljenaMesta = new ObservableCollection<string>();
            Servis.InterfejsServisi.BolnicaServis bs= new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            bolnicee = bs.GetAll();
            foreach (var item in bolnicee)
            {
                dobavljene.Add(item.Naziv);
            }
            Bolnice = dobavljene;
            if(Bolnice.Count == 0)
            {
                MessageBox.Show("Nema bolnica.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedBolnica = Bolnice[0];
            }

            

            mestaa = ms.GetAll();
            foreach (var item in mestaa)
            {
                dobavljenaMesta.Add(item.Naziv);
            }
            Mesta = dobavljenaMesta;

            if (Mesta.Count == 0)
            {
                MessageBox.Show("Nema mesta.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedMesto = Mesta[0];
            }
            
            AddRecepcionerCommand = new MyICommand(OnAddRecepcioner);
            if (recepcioner != null)
            {
                ime = recepcioner.Ime;
                prezime = recepcioner.Prezime;
                radni_staz = recepcioner.Radni_staz.ToString();
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddRecepcioner()
        {
            Servis.InterfejsServisi.RecepcionerServis rs = new Servis.InterfejsServisi.RecepcionerServis();
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            Recepcioner re = new Recepcioner();
            if (CreatedRecepcioner == null)
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
                    Recepcioner provera = new Recepcioner();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = rs.FindById(jmbgRandom);

                    } while (pronadjen != null);

                    re.Jmbg = jmbgRandom;
                    re.Ime = ime;
                    re.Prezime = prezime;
                    re.Radni_staz = radni_staz;
                    re.BolnicaOznaka_B = bs.FindByName(selectedBolnica);
                    re.MestoP_Broj = ms.FindByName(selectedMesto);

                    if (rs.Insert(re))
                    {

                        MessageBox.Show("Recepcioner uspešno dodat.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    CreatedRecepcioner.Ime = ime;
                    CreatedRecepcioner.Prezime = prezime;
                    CreatedRecepcioner.Radni_staz = radni_staz;
                    CreatedRecepcioner.BolnicaOznaka_B = bs.FindByName(selectedBolnica);
                    if (rs.Update(CreatedRecepcioner))
                    {
                        MessageBox.Show("Recepcioner uspešno izmenjen.", "Sucess!", MessageBoxButton.OK, MessageBoxImage.Information);
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
