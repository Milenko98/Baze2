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
    public class AddSeLeciViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddSeLeciCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedLek;

        public string SelectedLek
        {
            get { return selectedLek; }
            set { selectedLek = value; OnPropertyChanged("SelectedLek"); }
        }

        private string selectedDijagnoza;

        public string SelectedDijagnoza
        {
            get { return selectedDijagnoza; }
            set { selectedDijagnoza = value; OnPropertyChanged("SelectedDijagnoza"); }
        }


        public SeLeci CreatedSeLeci { get; set; }


        private ObservableCollection<string> lekovi;

        public ObservableCollection<string> Lekovi
        {
            get { return lekovi; }
            set { lekovi = value; }
        }

        private ObservableCollection<string> dijagnoze;

        public ObservableCollection<string> Dijagnoze
        {
            get { return dijagnoze; }
            set { dijagnoze = value; }
        }



        public AddSeLeciViewModel(SeLeci seLeci)
        {
            CreatedSeLeci = seLeci;
            List<Lek> lekovii = new List<Lek>();
            List<Dijagnoza> dijagnozee = new List<Dijagnoza>();
            ObservableCollection<string> dobavljeniLekovi = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeneDijagnoze = new ObservableCollection<string>();
            Servis.InterfejsServisi.LekServis ls = new Servis.InterfejsServisi.LekServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();

            lekovii = ls.GetAll();
            foreach (var item in lekovii)
            {
                dobavljeniLekovi.Add(item.Naziv);
            }
            Lekovi = dobavljeniLekovi;

            if (Lekovi.Count == 0)
            {
                MessageBox.Show("Nema lekova.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                selectedLek = Lekovi[0];
            }

            dijagnozee = ds.GetAll();
            foreach (var item in dijagnozee)
            {
                dobavljeneDijagnoze.Add(item.Naziv);
            }
            Dijagnoze = dobavljeneDijagnoze;

            if (Dijagnoze.Count == 0)
            {
                MessageBox.Show("Nema dijagnoza.", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                selectedDijagnoza = Dijagnoze[0];
            }


            AddSeLeciCommand = new MyICommand(OnAddSeLeci);
            if (seLeci != null)
            {
                SelectedLek = seLeci.Lek.Naziv;
                SelectedDijagnoza = seLeci.Dijagnoza.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddSeLeci()
        {
            Servis.InterfejsServisi.LekServis ls = new Servis.InterfejsServisi.LekServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Servis.InterfejsServisi.SeLeciServis sls = new Servis.InterfejsServisi.SeLeciServis();
            SeLeci sl = new SeLeci();
            if (CreatedSeLeci == null)
            {
                sl.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                sl.LekId_Leka = ls.FindByName(SelectedLek);

                if (sls.Insert(sl))
                {

                    MessageBox.Show("SeLeci uspešno dodato.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedSeLeci.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                CreatedSeLeci.LekId_Leka = ls.FindByName(SelectedLek);
                if (sls.Update(CreatedSeLeci))
                {
                    MessageBox.Show("SeLeci uspešno izmenjeno.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
