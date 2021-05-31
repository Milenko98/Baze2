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


        public AddZdravstveniKartonViewModel(ZdravstveniKarton karton)
        {
            CreatedZdravstveniKarton = karton;
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
                selectedPacijent = null;
            }
            else
            {
                selectedPacijent = Pacijenti[0];
            }
            AddZdravstveniKartonCommand = new MyICommand(OnAddZdravstveniKarton);
            if (karton != null)
            {
                rokVazenja = karton.Rok_vazenja;
                selectedPacijent = karton.Ime_pacijenta + " " + karton.Prezime_pacijenta;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
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
                rokVazenjalbl = "";
                if (String.IsNullOrWhiteSpace(rokVazenja))
                    rokVazenjalbl = "Morate uneti rok vazenja zdravstvenog kartona!";
                else
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
                    zk.Rok_vazenja = rokVazenja;
                    p = ps.FindByName(selectedime);
                    zk.Pacijent = p;
                    if (zks.Insert(zk))
                    {
                        MessageBox.Show("ZdravstveniKarton uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom dodavanja.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Window.Close();
                    }
                }
                if (ps.Delete(p.Jmbg))
                {
                    MessageBox.Show("ok.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("Greška prilikom brisanja pacijenta.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Window.Close();
                }
            }
            else
            {
                rokVazenjalbl = "";
                if (String.IsNullOrWhiteSpace(rokVazenja))
                    rokVazenjalbl = "Morate uneti rok vazenja zdravstvenog kartona!";
                else
                {
                    CreatedZdravstveniKarton.Ime_pacijenta = selectedPacijent.Split(' ')[0];
                    CreatedZdravstveniKarton.Prezime_pacijenta = selectedPacijent.Split(' ')[1];
                    CreatedZdravstveniKarton.Rok_vazenja = rokVazenja;
                    if (zks.Update(CreatedZdravstveniKarton))
                    {
                        MessageBox.Show("ZdravstveniKarton uspešno izmenjen.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
