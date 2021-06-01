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
                Naziv = lek.Naziv;
                Kolicina = lek.Kolicina.ToString();
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddLek()
        {
            Servis.InterfejsServisi.LekServis ls = new Servis.InterfejsServisi.LekServis();
            Lek l = new Lek();
            if (CreatedLek == null)
            {
                Nazivlbl = "";
                Kolicinalbl = "";
                if (String.IsNullOrWhiteSpace(Naziv))
                    Nazivlbl = "Morate uneti naziv leka!";
                else if(int.TryParse(Naziv, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if (String.IsNullOrWhiteSpace(Kolicina))
                    Kolicinalbl = "Morate uneti kolicinu leka!";
                else if (!int.TryParse(Kolicina, out _))
                    Kolicinalbl = "Kolicina mora biti broj!";
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
                    l.Naziv = Naziv;
                    l.Kolicina = Int32.Parse(Kolicina);

                    if (ls.Insert(l))
                    {

                        MessageBox.Show("Lek uspešno dodat.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom dodavanja.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        Window.Close();
                    }
                }

            }
            else
            {
                Nazivlbl = "";
                Kolicinalbl = "";
                if (String.IsNullOrWhiteSpace(Naziv))
                    Nazivlbl = "Morate uneti naziv leka!";
                else if (int.TryParse(Naziv, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if (String.IsNullOrWhiteSpace(Kolicina))
                    Kolicinalbl = "Morate uneti kolicinu leka!";
                else if (int.TryParse(Kolicina, out _))
                    Kolicinalbl = "Kolicina mora biti broj!";
                else
                {
                    CreatedLek.Naziv = Naziv;
                    CreatedLek.Kolicina = Int32.Parse(Kolicina);
                    if (ls.Update(CreatedLek))
                    {
                        MessageBox.Show("Lek uspešno izmenjen.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
}
