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
            set { imelbl = value; }
        }

        private string prezimelbl;

        public string Prezimelbl
        {
            get { return prezimelbl; }
            set { prezimelbl = value; }
        }

        private string radnistazlbl;

        public string Radnistazlbl
        {
            get { return radnistazlbl; }
            set { radnistazlbl = value; }
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

            selectedBolnica = Bolnice[0];

            mestaa = ms.GetAll();
            foreach (var item in mestaa)
            {
                dobavljenaMesta.Add(item.Naziv);
            }
            Mesta = dobavljenaMesta;

            selectedMesto = Mesta[0];
            AddRecepcionerCommand = new MyICommand(OnAddRecepcioner);
            if (recepcioner != null)
            {
                ime = recepcioner.Ime;
                prezime = recepcioner.Prezime;
                radni_staz = recepcioner.Radni_staz.ToString();
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
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
                imelbl = "";
                prezimelbl = "";
                radnistazlbl = "";
                if (String.IsNullOrWhiteSpace(ime))
                    imelbl = "Morate uneti ime!";
                else if (String.IsNullOrWhiteSpace(prezime))
                    prezimelbl = "Morate uneti prezime!";
                else if (String.IsNullOrWhiteSpace(radni_staz))
                    radnistazlbl = "Morate uneti radni staz!";
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

                        MessageBox.Show("Recepcioner uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom dodavanja.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Window.Close();
                    }
                }

            }
            else
            {
                imelbl = "";
                prezimelbl = "";
                radnistazlbl = "";
                if (String.IsNullOrWhiteSpace(ime))
                    imelbl = "Morate uneti ime!";
                else if (String.IsNullOrWhiteSpace(prezime))
                    prezimelbl = "Morate uneti prezime!";
                else if (String.IsNullOrWhiteSpace(radni_staz))
                    radnistazlbl = "Morate uneti radni staz!";
                else
                {
                    CreatedRecepcioner.Ime = ime;
                    CreatedRecepcioner.Prezime = prezime;
                    CreatedRecepcioner.Radni_staz = radni_staz;
                    CreatedRecepcioner.BolnicaOznaka_B = bs.FindByName(selectedBolnica);
                    if (rs.Update(CreatedRecepcioner))
                    {
                        MessageBox.Show("Recepcioner uspešno izmenjen.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom izmene.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Window.Close();
                    }
                }
            }
        }
    }
}
