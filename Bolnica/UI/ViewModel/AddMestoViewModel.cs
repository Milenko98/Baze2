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
    public class AddMestoViewModel : BindableBase
    {
        public Window Window { get; set; }

        public MyICommand AddMestoCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        public Mesto CreatedMesto { get; set; }


        private string nazivlbl;

        public string Nazivlbl
        {
            get { return nazivlbl; }
            set { nazivlbl = value; OnPropertyChanged("Nazivlbl"); }
        }


        private string nazivMesta;

        public string NazivMesta
        {
            get { return nazivMesta; }
            set { nazivMesta = value; OnPropertyChanged("NazivMesta"); }
        }



        public AddMestoViewModel(Mesto mesto)
        {
            CreatedMesto = mesto;
            AddMestoCommand = new MyICommand(OnAddMesto);
            if (mesto != null)
            {
                nazivMesta = mesto.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }

        }


        public void OnAddMesto()
        {
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            Mesto m = new Mesto();
            if (CreatedMesto == null)
            {
                Nazivlbl = "";
                if (String.IsNullOrWhiteSpace(NazivMesta))
                    Nazivlbl = "Morate uneti naziv mesta";
                else if (int.TryParse(NazivMesta, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if (NazivMesta.Length < 2)
                    Nazivlbl = "Mesto mora da sadrzi bar 2 slova!";
                else
                {
                    Random r = new Random();
                    int Oznaka_B_Random = r.Next(0, 200);
                    Mesto provera = new Mesto();
                    var pronadjena = provera;
                    do
                    {
                        pronadjena = ms.FindById(Oznaka_B_Random);

                    } while (pronadjena != null);

                    m.P_Broj = Oznaka_B_Random;
                    m.Naziv = NazivMesta;

                    if (ms.Validate(m.Naziv))
                    {

                        if (ms.Insert(m))
                        {

                            MessageBox.Show("Mesto uspešno dodato.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        MessageBox.Show("Vec postoji mesto sa tim nazivom.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                Nazivlbl = "";
                if (String.IsNullOrWhiteSpace(NazivMesta))
                    nazivlbl = "Morate uneti naziv mesta";
                else if (int.TryParse(NazivMesta, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if (NazivMesta.Length < 2)
                    Nazivlbl = "Mesto mora da sadrzi bar 2 slova!";
                else
                {
                    CreatedMesto.Naziv = NazivMesta;
                    if (ms.Update(CreatedMesto))
                    {
                        MessageBox.Show("Mesto uspešno izmenjeno.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
