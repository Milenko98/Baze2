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
    public class AddPregledViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddPregledCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedPacijent;

        public string SelectedPacijent
        {
            get { return selectedPacijent; }
            set { selectedPacijent = value; OnPropertyChanged("SelectedPacijent"); }
        }

        public Pregled CreatedPregled { get; set; }


        private string nazivPregleda;

        public string NazivPregleda
        {
            get { return nazivPregleda; }
            set { nazivPregleda = value; OnPropertyChanged("NazivPregleda"); }
        }

        private ObservableCollection<string> pacijenti;

        public ObservableCollection<string> Pacijenti
        {
            get { return pacijenti; }
            set { pacijenti = value; }
        }


        private string nazivpregledalbl;

        public string Nazivpregledalbl
        {
            get { return nazivpregledalbl; }
            set { nazivpregledalbl = value; OnPropertyChanged("Nazivpregledalbl"); }
        }


        public AddPregledViewModel(Pregled pregled)
        {
            CreatedPregled = pregled;
            List<Pacijent> pacijenti = new List<Pacijent>();
            ObservableCollection<string> dobavljeniPacijenti = new ObservableCollection<string>();
            Servis.InterfejsServisi.PacijentServis ps = new Servis.InterfejsServisi.PacijentServis();
            pacijenti = ps.GetAll();
            foreach (var item in pacijenti)
            {
                dobavljeniPacijenti.Add(item.Ime +" "+item.Prezime);
            }
            Pacijenti = dobavljeniPacijenti;
            if(Pacijenti.Count == 0)
            {
                MessageBox.Show("Nema pacijenata.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                selectedPacijent = Pacijenti[0];
            }

            
            AddPregledCommand = new MyICommand(OnAddPregled);
            if (pregled != null)
            {
                nazivPregleda = pregled.Naziv;
                selectedPacijent = pregled.Ime_pacijenta + " "+ pregled.Prezime_pacijenta;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddPregled()
        {
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            Pregled p = new Pregled();
            if (CreatedPregled == null)
            {
                nazivpregledalbl = "";
                if (String.IsNullOrWhiteSpace(nazivPregleda))
                    nazivpregledalbl = "Morate uneti naziv pregleda!";
                else
                {
                    Random r = new Random();
                    int brojPRandom = r.Next(0, 200);
                    Pregled provera = new Pregled();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = ps.FindById(brojPRandom);

                    } while (pronadjen != null);

                    p.Broj_P = brojPRandom;
                    string selectedime = selectedPacijent.Split(' ')[0];
                    string selectedprezime = selectedPacijent.Split(' ')[1];
                    p.Ime_pacijenta = selectedime;
                    p.Prezime_pacijenta = selectedprezime;
                    p.Naziv = nazivPregleda;
                    if (ps.Insert(p))
                    {

                        MessageBox.Show("Pregled uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                nazivpregledalbl = "";
                if (String.IsNullOrWhiteSpace(nazivPregleda))
                    nazivpregledalbl = "Morate uneti naziv pregleda!";
                else
                {
                    CreatedPregled.Ime_pacijenta = selectedPacijent.Split(' ')[0];
                    CreatedPregled.Prezime_pacijenta = selectedPacijent.Split(' ')[1];
                    CreatedPregled.Naziv = nazivPregleda;
                    if (ps.Update(CreatedPregled))
                    {
                        MessageBox.Show("Pregled uspešno izmenjen.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
