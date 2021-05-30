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
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddLek()
        {
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            Terapija t = new Terapija();
            if (CreatedTerapija == null)
            {
                nazivlbl = "";
                if (String.IsNullOrWhiteSpace(naziv))
                    nazivlbl = "Morate uneti naziv terapije!";
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

                        MessageBox.Show("Terapija uspešno dodata.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                if (String.IsNullOrWhiteSpace(naziv))
                    nazivlbl = "Morate uneti naziv terapije!";
                else
                {
                    CreatedTerapija.Naziv = naziv;
                    if (ts.Update(CreatedTerapija))
                    {
                        MessageBox.Show("Terapija uspešno izmenjena.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
