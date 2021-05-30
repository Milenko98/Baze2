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
    public class AddBolnicaViewModel : BindableBase
    {


        public Window Window { get; set; }

        public MyICommand AddBolnicaCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        public Bolnica CreatedBolnica { get; set; }

        private string selectedMesto;

        public string SelectedMesto
        {
            get { return selectedMesto; }
            set { selectedMesto = value; OnPropertyChanged("SelectedMesto"); }
        }

        private ObservableCollection<string> mesta;

        public ObservableCollection<string> Mesta
        {
            get { return mesta; }
            set { mesta = value; }
        }


        private string nazivlbl;

        public string Nazivlbl
        {
            get { return nazivlbl; }
            set { nazivlbl = value; OnPropertyChanged("Nazivlbl"); }
        }


        private string nazivBolnice;

        public string NazivBolnice
        {
            get { return nazivBolnice; }
            set { nazivBolnice = value; OnPropertyChanged("NazivBolnice"); }
        }



        public AddBolnicaViewModel(Bolnica bolnica)
        {

            List<Mesto> mestaa = new List<Mesto>();
            ObservableCollection<string> dobavljenaMesta = new ObservableCollection<string>();
            Servis.InterfejsServisi.MestoServis mss = new Servis.InterfejsServisi.MestoServis();
            mestaa = mss.GetAll();
            foreach (var item in mestaa)
            {
                dobavljenaMesta.Add(item.Naziv);
            }
            Mesta = dobavljenaMesta;

            selectedMesto = Mesta[0];
            CreatedBolnica = bolnica;
            AddBolnicaCommand = new MyICommand(OnAddBolnica);
            CreatedBolnica = bolnica;
            if (bolnica != null)
            {
                nazivBolnice = bolnica.Naziv;
                AddButtonContent = "IZMENI";
            }
            else
            {
                AddButtonContent = "DODAJ";
            }

        }


        public void OnAddBolnica()
        {
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            Bolnica b = new Bolnica();
            if (CreatedBolnica == null)
            {
                Nazivlbl = "";
                if (String.IsNullOrWhiteSpace(NazivBolnice))
                    Nazivlbl = "Morate uneti naziv bolnice";
                else
                {
                    b.Naziv = NazivBolnice;
                    Random r = new Random();
                    int Oznaka_B_Random = r.Next(0, 200);
                    Bolnica provera = new Bolnica();
                    var pronadjena = provera;
                    do
                    {
                        pronadjena = bs.FindById(Oznaka_B_Random);

                    } while (pronadjena != null);

                    b.Oznaka_B = Oznaka_B_Random;
                    b.MestoP_Broj = ms.FindByName(selectedMesto);


                    if (bs.Insert(b))
                    {

                            MessageBox.Show("Bolnica uspešno dodata.", "Operacija uspešna!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                Nazivlbl = "";
                if (String.IsNullOrWhiteSpace(NazivBolnice))
                    Nazivlbl = "Morate uneti naziv bolnice";
                else
                {
                    CreatedBolnica.Naziv = NazivBolnice;
                    CreatedBolnica.MestoP_Broj = ms.FindByName(selectedMesto);
                    if (bs.Update(CreatedBolnica))
                    {
                        MessageBox.Show("Bolnica uspešno izmenjena.", "Operacija uspešna.", MessageBoxButton.OK, MessageBoxImage.Information);
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
