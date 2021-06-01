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
    public class AddPacijentViewModel : BindableBase
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



        public Pacijent CreatedPacijent { get; set; }

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




        public AddPacijentViewModel(Pacijent pacijent)
        {
            CreatedPacijent = pacijent;
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
            if (pacijent != null)
            {
                ime = pacijent.Ime;
                prezime = pacijent.Prezime;
                radni_staz = pacijent.Radni_staz.ToString();
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddLekar()
        {
            Servis.InterfejsServisi.PacijentServis ps = new Servis.InterfejsServisi.PacijentServis();
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            Pacijent p = new Pacijent();
            if (CreatedPacijent == null)
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
                    Pacijent provera = new Pacijent();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = ps.FindById(jmbgRandom);

                    } while (pronadjen != null);

                    p.Jmbg = jmbgRandom;
                    p.Ime = ime;
                    p.Prezime = prezime;
                    p.Radni_staz = radni_staz;
                    p.BolnicaOznaka_B = bs.FindByName(selectedBolnica);
                    p.MestoP_Broj = ms.FindByName(selectedMesto);

                    if (ps.Insert(p))
                    {

                        MessageBox.Show("Pacijent uspešno dodat.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    CreatedPacijent.Ime = ime;
                    CreatedPacijent.Prezime = prezime;
                    CreatedPacijent.Radni_staz = radni_staz;
                    CreatedPacijent.BolnicaOznaka_B = bs.FindByName(selectedBolnica);
                    if (ps.Update(CreatedPacijent))
                    {
                        MessageBox.Show("Lekar uspešno izmenjen.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
