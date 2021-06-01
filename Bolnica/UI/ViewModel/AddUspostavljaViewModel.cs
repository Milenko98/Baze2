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
    public class AddUspostavljaViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddUspostavljaCommand { get; set; }

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

        private string selectedDijagnoza;

        public string SelectedDijagnoza
        {
            get { return selectedDijagnoza; }
            set { selectedDijagnoza = value; OnPropertyChanged("SelectedDijagnoza"); }
        }

        private string selectedLecenje;

        public string SelectedLecenje
        {
            get { return selectedLecenje; }
            set { selectedLecenje = value; OnPropertyChanged("SelectedLecenje"); }
        }
        public Uspostavlja CreatedUspostavlja { get; set; }


        private ObservableCollection<string> pregledi;

        public ObservableCollection<string> Pregledi
        {
            get { return pregledi; }
            set { pregledi = value; }
        }

        private ObservableCollection<string> dijagnoze;

        public ObservableCollection<string> Dijagnoze
        {
            get { return dijagnoze; }
            set { dijagnoze = value; }
        }

        private ObservableCollection<string> lecenja;

        public ObservableCollection<string> Lecenja
        {
            get { return lecenja; }
            set { lecenja = value; }
        }



        public AddUspostavljaViewModel(Uspostavlja uspostavka)
        {
            CreatedUspostavlja = uspostavka;
            List<Pregled> pregledii = new List<Pregled>();
            List<Dijagnoza> dijagnozee = new List<Dijagnoza>();
            List<Lecenje> lecenjaa = new List<Lecenje>();
            ObservableCollection<string> dobavljeniPregledi = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeneDijagnoze = new ObservableCollection<string>();
            ObservableCollection<string> dobavljenaLecenja = new ObservableCollection<string>();
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();
            pregledii = ps.GetAll();
            foreach (var item in pregledii)
            {
                dobavljeniPregledi.Add(item.Naziv);
            }
            Pregledi = dobavljeniPregledi;

            if(Pregledi.Count == 0)
            {
                MessageBox.Show("Nema pregleda.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedPregled = Pregledi[0];
            }

            

            dijagnozee = ds.GetAll();
            foreach (var item in dijagnozee)
            {
                dobavljeneDijagnoze.Add(item.Naziv);
            }
            Dijagnoze = dobavljeneDijagnoze;

            if(Dijagnoze.Count == 0)
            {
                MessageBox.Show("Nema dijagnoza.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedDijagnoza = Dijagnoze[0];
            }

            lecenjaa = ls.GetAll();
            foreach (var item in lecenjaa)
            {
                dobavljenaLecenja.Add(item.TerapijaBroj_T+","+item.DijagnozaOznaka_D);
            }
            Lecenja = dobavljenaLecenja;

            if (Lecenja.Count == 0)
            {
                MessageBox.Show("Nema lecenja.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedLecenje = Lecenja[0];
            }

            AddUspostavljaCommand = new MyICommand(OnAddUspostavlja);
            if (uspostavka != null)
            {
                SelectedPregled = uspostavka.Pregled.Naziv;
                SelectedDijagnoza = uspostavka.Dijagnoza.Naziv;
                SelectedLecenje = uspostavka.Lecenje.TerapijaBroj_T + "," + uspostavka.Lecenje.DijagnozaOznaka_D;
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddUspostavlja()
        {
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();
            Uspostavlja u = new Uspostavlja();
            if (CreatedUspostavlja == null)
            {

                u.PregledBroj_P = ps.FindByName(SelectedPregled);
                u.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                u.LecenjeDijagnozaOznaka_D = Int32.Parse(SelectedLecenje.Split(',')[1]);
                u.LecenjeTerapijaBroj_T = Int32.Parse(SelectedLecenje.Split(',')[0]);

                if (us.Insert(u))
                {

                    MessageBox.Show("Uspostavlja uspešno dodat.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedUspostavlja.PregledBroj_P = ps.FindByName(SelectedPregled);
                CreatedUspostavlja.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                CreatedUspostavlja.LecenjeTerapijaBroj_T = Int32.Parse(SelectedLecenje.Split(',')[0]);
                CreatedUspostavlja.LecenjeDijagnozaOznaka_D = Int32.Parse(SelectedLecenje.Split(',')[1]);
                if (us.Update(CreatedUspostavlja))
                {
                    MessageBox.Show("Uspostavlja uspešno izmenjeno.", "Sucess!", MessageBoxButton.OK, MessageBoxImage.Information);
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
