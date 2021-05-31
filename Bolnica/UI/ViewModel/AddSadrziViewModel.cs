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
    public class AddSadrziViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddSadrziCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedZk;

        public string SelectedZk
        {
            get { return selectedZk; }
            set { selectedZk = value; OnPropertyChanged("SelectedZk"); }
        }

        private string selectedDijagnoza;

        public string SelectedDijagnoza
        {
            get { return selectedDijagnoza; }
            set { selectedDijagnoza = value; OnPropertyChanged("SelectedDijagnoza"); }
        }


        public Sadrzi CreatedSadrzi { get; set; }


        private ObservableCollection<string> zkovi;

        public ObservableCollection<string> Zkovi
        {
            get { return zkovi; }
            set { zkovi = value; }
        }

        private ObservableCollection<string> dijagnoze;

        public ObservableCollection<string> Dijagnoze
        {
            get { return dijagnoze; }
            set { dijagnoze = value; }
        }



        public AddSadrziViewModel(Sadrzi sadrzi)
        {
            CreatedSadrzi = sadrzi;
            List<ZdravstveniKarton> zkovii = new List<ZdravstveniKarton>();
            List<Dijagnoza> dijagnozee = new List<Dijagnoza>();
            ObservableCollection<string> dobavljeniZkovi = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeneDijagnoze = new ObservableCollection<string>();
            Servis.InterfejsServisi.ZdravstveniKartonServis zks = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();

            zkovii = zks.GetAll();
            foreach (var item in zkovii)
            {
                dobavljeniZkovi.Add(item.Broj_K.ToString());
            }
            Zkovi = dobavljeniZkovi;

            if (Zkovi.Count == 0)
            {
                MessageBox.Show("Nema zdravstvenih kartona.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                selectedZk = Zkovi[0];
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


            AddSadrziCommand = new MyICommand(OnAddSadrzi);
            if (sadrzi != null)
            {
                SelectedZk = sadrzi.ZdravstveniKarton.Broj_K.ToString();
                SelectedDijagnoza = sadrzi.Dijagnoza.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddSadrzi()
        {
            Servis.InterfejsServisi.ZdravstveniKartonServis zks = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Servis.InterfejsServisi.SadrziServis sas = new Servis.InterfejsServisi.SadrziServis();
            Sadrzi s = new Sadrzi();
            if (CreatedSadrzi == null)
            {

                s.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                s.ZdravstveniKartonBroj_K = Int32.Parse(SelectedZk);

                if (sas.Insert(s))
                {

                    MessageBox.Show("Sadrzi uspešno dodato.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedSadrzi.DijagnozaOznaka_D = ds.FindByName(SelectedDijagnoza);
                CreatedSadrzi.ZdravstveniKartonBroj_K = Int32.Parse(SelectedZk);
                if (sas.Update(CreatedSadrzi))
                {
                    MessageBox.Show("Sadrzi uspešno izmenjeno.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
