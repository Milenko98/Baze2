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
    public class AddZdravstveniKartonViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddZdravstveniKartonCommand { get; set; }

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

        public ZdravstveniKarton CreatedZdravstveniKarton { get; set; }


        private string rokVazenja;

        public string RokVazenja
        {
            get { return rokVazenja; }
            set { rokVazenja = value; OnPropertyChanged("RokVazenja"); }
        }

        private ObservableCollection<string> pacijenti;

        public ObservableCollection<string> Pacijenti
        {
            get { return pacijenti; }
            set { pacijenti = value; }
        }


        private string rokVazenjalbl;

        public string RokVazenjalbl
        {
            get { return rokVazenjalbl; }
            set { rokVazenjalbl = value; OnPropertyChanged("RokVazenjalbl"); }
        }

        private DateTime izabranDatum;

        public DateTime IzabranDatum
        {
            get { return izabranDatum; }
            set { izabranDatum = value; OnPropertyChanged("IzabranDatum"); }
        }


        public AddZdravstveniKartonViewModel(ZdravstveniKarton karton)
        {
            CreatedZdravstveniKarton = karton;
            IzabranDatum = DateTime.Now;
            List<Pacijent> pacijenti = new List<Pacijent>();
            ObservableCollection<string> dobavljeniPacijenti = new ObservableCollection<string>();
            Servis.InterfejsServisi.PacijentServis ps = new Servis.InterfejsServisi.PacijentServis();
            pacijenti = ps.GetAll();
            foreach (var item in pacijenti)
            {
                dobavljeniPacijenti.Add(item.Ime + " " + item.Prezime);
            }
            Pacijenti = dobavljeniPacijenti;
            if (pacijenti.Count == 0)
            {
                MessageBox.Show("Nema pacijenata.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedPacijent = Pacijenti[0];
            }
            AddZdravstveniKartonCommand = new MyICommand(OnAddZdravstveniKarton);
            if (karton != null)
            {
                SelectedPacijent = karton.Ime_pacijenta + " " + karton.Prezime_pacijenta;
                IzabranDatum = DateTime.Parse(karton.Rok_vazenja);
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddZdravstveniKarton()
        {
            Servis.InterfejsServisi.ZdravstveniKartonServis zks = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            Servis.InterfejsServisi.PacijentServis ps = new Servis.InterfejsServisi.PacijentServis();
            ZdravstveniKarton zk = new ZdravstveniKarton();
            Pacijent p = new Pacijent();
            if (CreatedZdravstveniKarton == null)
            {
                Random r = new Random();
                int brojKRandom = r.Next(0, 200);
                ZdravstveniKarton provera = new ZdravstveniKarton();
                var pronadjen = provera;
                do
                {
                    pronadjen = zks.FindById(brojKRandom);

                } while (pronadjen != null);

                zk.Broj_K = brojKRandom;
                string selectedime = selectedPacijent.Split(' ')[0];
                string selectedprezime = selectedPacijent.Split(' ')[1];
                zk.Ime_pacijenta = selectedime;
                zk.Prezime_pacijenta = selectedprezime;
                zk.Rok_vazenja = IzabranDatum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                p = ps.FindByName(selectedime);
                zk.PacijentJmbg = p.Jmbg;
                if (zks.Insert(zk))
                {
                    MessageBox.Show("ZdravstveniKarton uspešno dodat.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedZdravstveniKarton.Ime_pacijenta = selectedPacijent.Split(' ')[0];
                CreatedZdravstveniKarton.Prezime_pacijenta = selectedPacijent.Split(' ')[1];
                CreatedZdravstveniKarton.Rok_vazenja = IzabranDatum.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (zks.Update(CreatedZdravstveniKarton))
                {
                    MessageBox.Show("ZdravstveniKarton uspešno izmenjen.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
