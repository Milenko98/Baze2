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
    public class AddTerapijaViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddTerapijaCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }



        public Terapija CreatedTerapija { get; set; }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }


        private string nazivlbl;

        public string Nazivlbl
        {
            get { return nazivlbl; }
            set { nazivlbl = value; OnPropertyChanged("Nazivlbl"); }
        }





        public AddTerapijaViewModel(Terapija terapija)
        {
            CreatedTerapija = terapija;
            AddTerapijaCommand = new MyICommand(OnAddLek);
            if (terapija != null)
            {
                naziv = terapija.Naziv;
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddLek()
        {
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            Terapija t = new Terapija();
            if (CreatedTerapija == null)
            {
                Nazivlbl = "";
                if (String.IsNullOrWhiteSpace(Naziv))
                    Nazivlbl = "Morate uneti naziv terapije!";
                else if(int.TryParse(Naziv, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if(Naziv.Length < 3)
                    Nazivlbl = "Naziv mora sadrzati bar 3 slova!";
                else
                {
                    Random r = new Random();
                    int brojTRandom = r.Next(0, 200);
                    Terapija provera = new Terapija();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = ts.FindById(brojTRandom);

                    } while (pronadjen != null);

                    t.Broj_T = brojTRandom;
                    t.Naziv = naziv;

                    if (ts.Insert(t))
                    {

                        MessageBox.Show("Terapija uspešno dodata.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                if (String.IsNullOrWhiteSpace(Naziv))
                    Nazivlbl = "Morate uneti naziv terapije!";
                else if (int.TryParse(Naziv, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if (Naziv.Length < 3)
                    Nazivlbl = "Naziv mora sadrzati bar 3 slova!";
                else
                {
                    CreatedTerapija.Naziv = naziv;
                    if (ts.Update(CreatedTerapija))
                    {
                        MessageBox.Show("Terapija uspešno izmenjena.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
