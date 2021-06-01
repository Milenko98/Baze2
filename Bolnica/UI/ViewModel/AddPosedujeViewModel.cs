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
    public class AddPosedujeViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddPosedujeCommand { get; set; }

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

        private string selectedTerapija;

        public string SelectedTerapija
        {
            get { return selectedTerapija; }
            set { selectedTerapija = value; OnPropertyChanged("SelectedTerapija"); }
        }


        public Poseduje CreatedPoseduje { get; set; }


        private ObservableCollection<string> zkovi;

        public ObservableCollection<string> Zkovi
        {
            get { return zkovi; }
            set { zkovi = value; }
        }

        private ObservableCollection<string> terapije;

        public ObservableCollection<string> Terapije
        {
            get { return terapije; }
            set { terapije = value; }
        }



        public AddPosedujeViewModel(Poseduje poseduje)
        {
            CreatedPoseduje = poseduje;
            List<ZdravstveniKarton> zkovii = new List<ZdravstveniKarton>();
            List<Terapija> terapijee = new List<Terapija>();
            ObservableCollection<string> dobavljeniZkovi = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeneTerapije = new ObservableCollection<string>();
            Servis.InterfejsServisi.ZdravstveniKartonServis zks = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();

            zkovii = zks.GetAll();
            foreach (var item in zkovii)
            {
                dobavljeniZkovi.Add(item.Broj_K.ToString());
            }
            Zkovi = dobavljeniZkovi;

            if (Zkovi.Count == 0)
            {
                MessageBox.Show("Nema zdravstvenih kartona.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedZk = Zkovi[0];
            }

            terapijee = ts.GetAll();
            foreach (var item in terapijee)
            {
                dobavljeneTerapije.Add(item.Naziv);
            }
            Terapije = dobavljeneTerapije;

            if (Terapije.Count == 0)
            {
                MessageBox.Show("Nema terapija.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedTerapija = Terapije[0];
            }


            AddPosedujeCommand = new MyICommand(OnAddPoseduje);
            if (poseduje != null)
            {

                SelectedTerapija = poseduje.Terapija.Broj_T.ToString();
                SelectedZk = poseduje.ZdravstveniKarton.Broj_K.ToString();
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddPoseduje()
        {
            Servis.InterfejsServisi.ZdravstveniKartonServis zks = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            Servis.InterfejsServisi.PosedujeServis pos = new Servis.InterfejsServisi.PosedujeServis();
            Poseduje p = new Poseduje();
            if (CreatedPoseduje == null)
            {
                p.ZdravstveniKartonBroj_K = zks.FindById(Int32.Parse(SelectedZk)).Broj_K;
                p.TerapijaBroj_T = ts.FindByName(SelectedTerapija);
                if (pos.Insert(p))
                {

                    MessageBox.Show("Poseduje uspešno dodato.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedPoseduje.ZdravstveniKartonBroj_K = zks.FindById(Int32.Parse(SelectedZk)).Broj_K;
                CreatedPoseduje.TerapijaBroj_T = ts.FindByName(SelectedTerapija);
                if (pos.Update(CreatedPoseduje))
                {
                    MessageBox.Show("Poseduje uspešno izmenjeno.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
