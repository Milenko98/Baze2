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
            if(Mesta.Count == 0)
            {
                MessageBox.Show("Nema mesta za kreiranje bolnice!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedMesto = Mesta[0];
            }
        
            CreatedBolnica = bolnica;
            AddBolnicaCommand = new MyICommand(OnAddBolnica);
            CreatedBolnica = bolnica;
            if (bolnica != null)
            {
                nazivBolnice = bolnica.Naziv;
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
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
                    Nazivlbl = "Morate uneti naziv bolnice!";
                else if(int.TryParse(NazivBolnice, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if(NazivBolnice.Length < 3)
                    Nazivlbl = "Naziv mora sadrzati bar 3 slova!";
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

                    if (bs.Validate(b.Naziv))
                    {

                        if (bs.Insert(b))
                        {

                            MessageBox.Show("Bolnica uspešno dodata.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        MessageBox.Show("Vec postoji bolnica sa tim nazivom.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                Nazivlbl = "";
                if (String.IsNullOrWhiteSpace(NazivBolnice))
                    Nazivlbl = "Morate uneti naziv bolnice!";
                else if (int.TryParse(NazivBolnice, out _))
                    Nazivlbl = "Naziv ne moze biti broj!";
                else if (NazivBolnice.Length < 3)
                    Nazivlbl = "Naziv mora sadrzati bar 3 slova!";
                else
                {
                    CreatedBolnica.Naziv = NazivBolnice;
                    CreatedBolnica.MestoP_Broj = ms.FindByName(selectedMesto);
                    if (bs.Update(CreatedBolnica))
                    {
                        MessageBox.Show("Bolnica uspešno izmenjena.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
