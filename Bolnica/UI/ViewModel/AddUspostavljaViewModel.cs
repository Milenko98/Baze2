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



        public AddUspostavljaViewModel(Uspostavlja uspostavka)
        {
            CreatedUspostavlja = uspostavka;
            List<Pregled> pregledii = new List<Pregled>();
            List<Dijagnoza> dijagnozee = new List<Dijagnoza>();
            ObservableCollection<string> dobavljeniPregledi = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeneDijagnoze = new ObservableCollection<string>();
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            pregledii = ps.GetAll();
            foreach (var item in pregledii)
            {
                dobavljeniPregledi.Add(item.Naziv);
            }
            Pregledi = dobavljeniPregledi;

            selectedPregled = Pregledi[0];

            dijagnozee = ds.GetAll();
            foreach (var item in dijagnozee)
            {
                dobavljeneDijagnoze.Add(item.Naziv);
            }
            Dijagnoze = dobavljeneDijagnoze;

            selectedDijagnoza = Dijagnoze[0];
            AddUspostavljaCommand = new MyICommand(OnAddUspostavlja);
            if (uspostavka != null)
            {
                SelectedPregled = uspostavka.Pregled.Naziv;
                SelectedDijagnoza = uspostavka.Dijagnoza.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddUspostavlja()
        {
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Uspostavlja u = new Uspostavlja();
            if (CreatedUspostavlja == null)
            {

                u.PregledBroj_P = ps.FindByName(SelectedPregled);
                u.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                u.LecenjeId_Lecenja = 1;

                if (us.Insert(u))
                {

                    MessageBox.Show("Uspostavlja uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedUspostavlja.PregledBroj_P = ps.FindByName(SelectedPregled);
                CreatedUspostavlja.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                if (us.Update(CreatedUspostavlja))
                {
                    MessageBox.Show("Uspostavlja uspešno izmenjeno.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
