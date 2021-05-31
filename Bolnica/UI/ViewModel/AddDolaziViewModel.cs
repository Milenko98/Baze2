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
    public class AddDolaziViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddDolaziCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedPregled;

        public string SelectedPregled
        {
            get { return selectedPregled; }
            set { selectedPregled = value; OnPropertyChanged("SelectedPregled"); }
        }

        private string selectedPacijent;

        public string SelectedPacijent
        {
            get { return selectedPacijent; }
            set { selectedPacijent = value; OnPropertyChanged("SelectedPacijent"); }
        }


        public Dolazi CreatedDolazi { get; set; }


        private ObservableCollection<string> pacijenti;

        public ObservableCollection<string> Pacijenti
        {
            get { return pacijenti; }
            set { pacijenti = value; }
        }

        private ObservableCollection<string> pregledi;

        public ObservableCollection<string> Pregledi
        {
            get { return pregledi; }
            set { pregledi = value; }
        }



        public AddDolaziViewModel(Dolazi dolazi)
        {
            CreatedDolazi = dolazi;
            List<Pregled> pregledii = new List<Pregled>();
            List<Pacijent> pacijentii = new List<Pacijent>();
            ObservableCollection<string> dobavljeniPregledi = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeniPacijenti = new ObservableCollection<string>();
            Servis.InterfejsServisi.PregledServis prs = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.PacijentServis pas = new Servis.InterfejsServisi.PacijentServis();

            pregledii = prs.GetAll();
            foreach (var item in pregledii)
            {
                dobavljeniPregledi.Add(item.Naziv);
            }
            Pregledi = dobavljeniPregledi;

            if (Pregledi.Count == 0)
            {
                MessageBox.Show("Nema pregleda.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                selectedPregled = Pregledi[0];
            }

            pacijentii = pas.GetAll();
            foreach (var item in pacijentii)
            {
                dobavljeniPacijenti.Add(item.Ime + " "+ item.Prezime);
            }
            Pacijenti = dobavljeniPacijenti;

            if (Pacijenti.Count == 0)
            {
                MessageBox.Show("Nema pacijenata.", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                selectedPacijent = Pacijenti[0];
            }


            AddDolaziCommand = new MyICommand(OnAddDolazi);
            if (dolazi != null)
            {

                SelectedPregled = dolazi.Pregled.Broj_P.ToString();
                SelectedPacijent = dolazi.Pacijent.Ime + " " + dolazi.Pacijent.Prezime;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddDolazi()
        {
            Servis.InterfejsServisi.PregledServis prs = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.PacijentServis pas = new Servis.InterfejsServisi.PacijentServis();
            Servis.InterfejsServisi.DolaziServis ds = new Servis.InterfejsServisi.DolaziServis();
            Dolazi d = new Dolazi();
            if (CreatedDolazi == null)
            {
                d.PregledBroj_P = prs.FindByName(SelectedPregled);
                d.PacijentJmbg = pas.FindByName(SelectedPacijent.Split(' ')[0]).Jmbg;
                if (ds.Insert(d))
                {

                    MessageBox.Show("Dolazi uspešno dodato.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("Greška prilikom dodavanja.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Window.Close();
                }

            }
            else
            {
                CreatedDolazi.PregledBroj_P = prs.FindByName(SelectedPregled);
                CreatedDolazi.PacijentJmbg = pas.FindByName(SelectedPacijent.Split(',')[1]).Jmbg;
                if (ds.Update(CreatedDolazi))
                {
                    MessageBox.Show("Dolazi uspešno izmenjeno.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
