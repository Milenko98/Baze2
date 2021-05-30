using Servis.Baza;
using Servis.PomocneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModel
{
    public class AddLekViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddLekCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }



        public Lek CreatedLek { get; set; }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        private string kolicina;

        public string Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; OnPropertyChanged("Kolicina"); }
        }

        private string nazivlbl;

        public string Nazivlbl
        {
            get { return nazivlbl; }
            set { nazivlbl = value; OnPropertyChanged("Nazivlbl"); }
        }

        private string kolicinalbl;

        public string Kolicinalbl
        {
            get { return kolicinalbl; }
            set { kolicinalbl = value; OnPropertyChanged("Kolicinalbl"); }
        }




        public AddLekViewModel(Lek lek)
        {
            CreatedLek = lek;
            AddLekCommand = new MyICommand(OnAddLek);
            if (lek != null)
            {
                naziv = lek.Naziv;
                kolicina = lek.Kolicina.ToString();
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddLek()
        {
            Servis.InterfejsServisi.LekServis ls = new Servis.InterfejsServisi.LekServis();
            Lek l = new Lek();
            if (CreatedLek == null)
            {
                nazivlbl = "";
                kolicinalbl = "";
                if (String.IsNullOrWhiteSpace(naziv))
                    nazivlbl = "Morate uneti naziv leka!";
                else if (String.IsNullOrWhiteSpace(kolicina))
                    kolicinalbl = "Morate uneti kolicinu leka!";
                else
                {
                    Random r = new Random();
                    int idLekaRandom = r.Next(0, 200);
                    Lek provera = new Lek();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = ls.FindById(idLekaRandom);

                    } while (pronadjen != null);

                    l.Id_Leka = idLekaRandom;
                    l.Naziv = naziv;
                    l.Kolicina = Int32.Parse(kolicina);

                    if (ls.Insert(l))
                    {

                        MessageBox.Show("Lek uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom dodavanja.", "Operacija neuspešna!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Window.Close();
                    }
                }

            }
            else
            {
                nazivlbl = "";
                kolicinalbl = "";
                if (String.IsNullOrWhiteSpace(naziv))
                    nazivlbl = "Morate uneti naziv leka!";
                else
                {
                    CreatedLek.Naziv = naziv;
                    CreatedLek.Kolicina = Int32.Parse(kolicina);
                    if (ls.Update(CreatedLek))
                    {
                        MessageBox.Show("Lek uspešno izmenjen.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
