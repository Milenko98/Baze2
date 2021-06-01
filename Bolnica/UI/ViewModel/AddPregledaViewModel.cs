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
    public class AddPregledaViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddPregledaCommand { get; set; }

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

        private string selectedLekar;

        public string SelectedLekar
        {
            get { return selectedLekar; }
            set { selectedLekar = value; OnPropertyChanged("SelectedLekar"); }
        }


        public Pregleda CreatedPregleda { get; set; }


        private ObservableCollection<string> lekari;

        public ObservableCollection<string> Lekari
        {
            get { return lekari; }
            set { lekari = value; }
        }

        private ObservableCollection<string> pregledi;

        public ObservableCollection<string> Pregledi
        {
            get { return pregledi; }
            set { pregledi = value; }
        }



        public AddPregledaViewModel(Pregleda pregleda)
        {
            CreatedPregleda = pregleda;
            List<Pregled> pregledii = new List<Pregled>();
            List<Lekar> lekarii = new List<Lekar>();
            ObservableCollection<string> dobavljeniPregledi = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeniLekari = new ObservableCollection<string>();
            Servis.InterfejsServisi.PregledServis prs = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.LekarServis ls = new Servis.InterfejsServisi.LekarServis();

            pregledii = prs.GetAll();
            foreach (var item in pregledii)
            {
                dobavljeniPregledi.Add(item.Naziv);
            }
            Pregledi = dobavljeniPregledi;

            if (Pregledi.Count == 0)
            {
                MessageBox.Show("Nema pregleda.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedPregled = Pregledi[0];
            }

            lekarii = ls.GetAll();
            foreach (var item in lekarii)
            {
                dobavljeniLekari.Add(item.Ime + " " + item.Prezime);
            }
            Lekari = dobavljeniLekari;

            if (Lekari.Count == 0)
            {
                MessageBox.Show("Nema lekara.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedLekar = Lekari[0];
            }


            AddPregledaCommand = new MyICommand(OnAddPregleda);
            if (pregleda != null)
            {

                selectedPregled = pregleda.Pregled.Naziv;
                SelectedLekar = pregleda.Lekar.Ime + " " + pregleda.Lekar.Prezime;
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddPregleda()
        {
            Servis.InterfejsServisi.PregledServis prs = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.LekarServis ls = new Servis.InterfejsServisi.LekarServis();
            Servis.InterfejsServisi.PregledaServis ps = new Servis.InterfejsServisi.PregledaServis();
            Pregleda p = new Pregleda();
            if (CreatedPregleda == null)
            {
                p.PregledBroj_P = prs.FindByName(selectedPregled);
                p.LekarJmbg = ls.FindByName(SelectedLekar.Split(' ')[0]).Jmbg;
                if (ps.Insert(p))
                {

                    MessageBox.Show("Pregleda uspešno dodato.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("Greška prilikom dodavanja.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Window.Close();
                }

            }
            else
            {
                CreatedPregleda.PregledBroj_P = prs.FindByName(selectedPregled);
                CreatedPregleda.LekarJmbg = ls.FindByName(SelectedLekar.Split(' ')[0]).Jmbg;
                if (ps.Update(CreatedPregleda))
                {
                    MessageBox.Show("Pregleda uspešno izmenjeno.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
