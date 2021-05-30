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
    public class AddReceptViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddReceptCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }



        public Recept CreatedRecept { get; set; }

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




        public AddReceptViewModel(Recept recept)
        {
            CreatedRecept = recept;
            AddReceptCommand = new MyICommand(OnAddRecept);
            if (recept != null)
            {
                naziv = recept.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }
        }

        public void OnAddRecept()
        {
            Servis.InterfejsServisi.ReceptServis rs = new Servis.InterfejsServisi.ReceptServis();
            Recept r = new Recept();
            if (CreatedRecept == null)
            {
                nazivlbl = "";
                if (String.IsNullOrWhiteSpace(naziv))
                    nazivlbl = "Morate uneti naziv recepta!";
                else
                {
                    Random rr = new Random();
                    int oznakaRRandom = rr.Next(0, 200);
                    Recept provera = new Recept();
                    var pronadjen = provera;
                    do
                    {
                        pronadjen = rs.FindById(oznakaRRandom);

                    } while (pronadjen != null);

                    r.Oznaka_R = oznakaRRandom;
                    r.Naziv = naziv;

                    if (rs.Insert(r))
                    {

                        MessageBox.Show("Recept uspešno dodat.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    nazivlbl = "Morate uneti naziv leka!";
                else
                {
                    CreatedRecept.Naziv = naziv;
                    if (rs.Update(CreatedRecept))
                    {
                        MessageBox.Show("Recept uspešno izmenjen.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
