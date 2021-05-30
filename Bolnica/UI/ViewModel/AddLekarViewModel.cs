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
    public class AddLekarViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddLekarCommand { get; set; }

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



        public Lekar CreatedLekar { get; set; }

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




        public AddLekarViewModel(Lekar lekar)
        {
            CreatedLekar = lekar;
            List<Bolnica> bolnicee = new List<Bolnica>();
            List<Mesto> mestaa = new List<Mesto>();
            ObservableCollection<string> dobavljeneBolnice = new ObservableCollection<string>();
            ObservableCollection<string> dobavljenaMesta = new ObservableCollection<string>();
            Servis.InterfejsServisi.BolnicaServis bss = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis mss = new Servis.InterfejsServisi.MestoServis();
            bolnicee = bss.GetAll();
            foreach (var item in bolnicee)
            {
                dobavljeneBolnice.Add(item.Naziv);
            }
            Bolnice = dobavljeneBolnice;

            selectedBolnica = Bolnice[0];

            mestaa = mss.GetAll();
            foreach (var item in mestaa)
            {
                dobavljenaMesta.Add(item.Naziv);
            }
            Mesta = dobavljenaMesta;

            selectedMesto = Mesta[0];
            AddLekarCommand = new MyICommand(OnAddLekar);
            if (lekar != null)
            {
                ime = lekar.Ime;
                prezime = lekar.Prezime;
                radni_staz = lekar.Radni_staz.ToString();
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddLekar()
        {
            Servis.InterfejsServisi.LekarServis ls = new Servis.InterfejsServisi.LekarServis();
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            Lekar l = new Lekar();
            if (CreatedLekar == null)
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
                    Lekar provera = new Lekar();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = ls.FindById(jmbgRandom);

                    } while (pronadjen != null);

                    l.Jmbg = jmbgRandom;
                    l.Ime = ime;
                    l.Prezime = prezime;
                    l.Radni_staz = radni_staz;
                    l.BolnicaOznaka_B = bs.FindByName(selectedBolnica);
                    l.MestoP_Broj = ms.FindByName(selectedMesto);

                    if (ls.Insert(l))
                    {

                        MessageBox.Show("Lekar uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    CreatedLekar.Ime = ime;
                    CreatedLekar.Prezime = prezime;
                    CreatedLekar.Radni_staz = radni_staz;
                    CreatedLekar.BolnicaOznaka_B = bs.FindByName(selectedBolnica);
                    if (ls.Update(CreatedLekar))
                    {
                        MessageBox.Show("Lekar uspešno izmenjen.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
