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
    public class AddDijagnozaViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddDijagnozaCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

    
        public Dijagnoza CreatedDijagnoza { get; set; }

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




        public AddDijagnozaViewModel(Dijagnoza dijagnoza)
        {
            CreatedDijagnoza = dijagnoza;
            AddDijagnozaCommand = new MyICommand(OnAddDijagnoza);
            if (dijagnoza != null)
            {
                naziv = dijagnoza.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddDijagnoza()
        {
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Dijagnoza d = new Dijagnoza();
            if (CreatedDijagnoza == null)
            {
                nazivlbl = "";
                if (String.IsNullOrWhiteSpace(naziv))
                    nazivlbl = "Morate uneti naziv dijagnoze!";
                else
                {
                    Random r = new Random();
                    int oznakaRandom = r.Next(0, 200);
                    Dijagnoza provera = new Dijagnoza();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = ds.FindById(oznakaRandom);

                    } while (pronadjen != null);

                    d.Oznaka_D = oznakaRandom;
                    d.Naziv = naziv;


                    if (ds.Insert(d))
                    {

                        MessageBox.Show("Dijagnoza uspešno dodata.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    nazivlbl = "Morate uneti naziv dijagnoze!";
                else
                {
                    CreatedDijagnoza.Naziv = naziv;
                    if (ds.Update(CreatedDijagnoza))
                    {
                        MessageBox.Show("Dijagnoza uspešno izmenjena.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
