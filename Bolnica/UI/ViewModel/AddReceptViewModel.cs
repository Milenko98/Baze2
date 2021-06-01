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
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddRecept()
        {
            Servis.InterfejsServisi.ReceptServis rs = new Servis.InterfejsServisi.ReceptServis();
            Recept r = new Recept();
            if (CreatedRecept == null)
            {
                Nazivlbl = "";
                if (String.IsNullOrWhiteSpace(Naziv))
                    Nazivlbl = "Morate uneti naziv recepta!";
                else if(int.TryParse(Naziv, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if(Naziv.Length < 3)
                    Nazivlbl = "Naziv mora sadrzati bar 3 slova!";
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

                        MessageBox.Show("Recept uspešno dodat.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    Nazivlbl = "Morate uneti naziv recepta!";
                else if (int.TryParse(Naziv, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if (Naziv.Length < 3)
                    Nazivlbl = "Naziv mora sadrzati bar 3 slova!";
                else
                {
                    CreatedRecept.Naziv = naziv;
                    if (rs.Update(CreatedRecept))
                    {
                        MessageBox.Show("Recept uspešno izmenjen.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
