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
    public class AddLecenjeViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddLecenjeCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedTerapija;

        public string SelectedTerapija
        {
            get { return selectedTerapija; }
            set { selectedTerapija = value; OnPropertyChanged("SelectedTerapija"); }
        }

        private string selectedDijagnoza;

        public string SelectedDijagnoza
        {
            get { return selectedDijagnoza; }
            set { selectedDijagnoza = value; OnPropertyChanged("SelectedDijagnoza"); }
        }

        public Lecenje CreatedLecenje { get; set; }


        private ObservableCollection<string> terapije;

        public ObservableCollection<string> Terapije
        {
            get { return terapije; }
            set { terapije = value; }
        }

        private ObservableCollection<string> dijagnoze;

        public ObservableCollection<string> Dijagnoze
        {
            get { return dijagnoze; }
            set { dijagnoze = value; }
        }



        public AddLecenjeViewModel(Lecenje lecenje)
        {
            CreatedLecenje = lecenje;
            List<Terapija> terapijee = new List<Terapija>();
            List<Dijagnoza> dijagnozee = new List<Dijagnoza>();
            ObservableCollection<string> dobavljeneTerapije = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeneDijagnoze = new ObservableCollection<string>();
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            terapijee = ts.GetAll();
            foreach (var item in terapijee)
            {
                dobavljeneTerapije.Add(item.Naziv);
            }
            Terapije = dobavljeneTerapije;

            selectedTerapija = Terapije[0];

            dijagnozee = ds.GetAll();
            foreach (var item in dijagnozee)
            {
                dobavljeneDijagnoze.Add(item.Naziv);
            }
            Dijagnoze = dobavljeneDijagnoze;

            selectedDijagnoza = Dijagnoze[0];
            AddLecenjeCommand = new MyICommand(OnAddLecenje);
            if (lecenje != null)
            {
                SelectedTerapija = lecenje.Terapija.Naziv;
                SelectedDijagnoza = lecenje.Dijagnoza.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddLecenje()
        {
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Lecenje l = new Lecenje();
            if (CreatedLecenje == null)
            {

                l.TerapijaBroj_T = ts.FindByName(SelectedTerapija);
                l.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);

                if (ls.Insert(l))
                {

                    MessageBox.Show("Lecenje uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedLecenje.TerapijaBroj_T = ts.FindByName(SelectedTerapija);
                CreatedLecenje.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                if (ls.Update(CreatedLecenje))
                {
                    MessageBox.Show("Lecenje uspešno izmenjeno.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
