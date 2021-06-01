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
    public class AddIzdajeViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand AddIzdajeCommand { get; set; }

        private string addButtonContent;
        public string AddButtonContent
        {
            get { return addButtonContent; }
            set { addButtonContent = value; OnPropertyChanged("AddButtonContent"); }
        }

        private string selectedUspostavka;

        public string SelectedUspostavka
        {
            get { return selectedUspostavka; }
            set { selectedUspostavka = value; OnPropertyChanged("SelectedUspostavka"); }
        }

        private string selectedRecept;

        public string SelectedRecept
        {
            get { return selectedRecept; }
            set { selectedRecept = value; OnPropertyChanged("SelectedRecept"); }
        }


        public Izdaje CreatedIzdaje { get; set; }


        private ObservableCollection<string> uspostavke;

        public ObservableCollection<string> Uspostavke
        {
            get { return uspostavke; }
            set { uspostavke = value; }
        }

        private ObservableCollection<string> recepti;

        public ObservableCollection<string> Recepti
        {
            get { return recepti; }
            set { recepti = value; }
        }



        public AddIzdajeViewModel(Izdaje izdaje)
        {
            CreatedIzdaje = izdaje;
            List<Recept> receptii = new List<Recept>();
            List<Uspostavlja> uspostavkee = new List<Uspostavlja>();
            ObservableCollection<string> dobavljeniRecepti = new ObservableCollection<string>();
            ObservableCollection<string> dobavljeneUspostavke = new ObservableCollection<string>();
            Servis.InterfejsServisi.ReceptServis rs = new Servis.InterfejsServisi.ReceptServis();
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();

            uspostavkee = us.GetAll();
            foreach (var item in uspostavkee)
            {
                dobavljeneUspostavke.Add(item.DijagnozaOznaka_D + "," + item.PregledBroj_P);
            }
            Uspostavke = dobavljeneUspostavke;

            if (Uspostavke.Count == 0)
            {
                MessageBox.Show("Nema uspostavke.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedUspostavka = Uspostavke[0];
            }

            receptii = rs.GetAll();
            foreach (var item in receptii)
            {
                dobavljeniRecepti.Add(item.Naziv);
            }
            Recepti = dobavljeniRecepti;

            if (Recepti.Count == 0)
            {
                MessageBox.Show("Nema recepata.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                selectedRecept = Recepti[0];
            }


            AddIzdajeCommand = new MyICommand(OnAddIzdaje);
            if (izdaje != null)
            {
                SelectedRecept = izdaje.Recept.Naziv;
                SelectedUspostavka = izdaje.Uspostavlja.DijagnozaOznaka_D + "," + izdaje.Uspostavlja.PregledBroj_P;
                AddButtonContent = "Izmeni";
            }
            else
            {
                AddButtonContent = "Dodaj";
            }
        }

        public void OnAddIzdaje()
        {
            Servis.InterfejsServisi.ReceptServis rs = new Servis.InterfejsServisi.ReceptServis();
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Servis.InterfejsServisi.IzdajeServis iss = new Servis.InterfejsServisi.IzdajeServis();
            Izdaje i = new Izdaje();
            if (CreatedIzdaje == null)
            {
                i.UspostavljaDijagnozaOznaka_D = ds.FindById(Int32.Parse(SelectedUspostavka.Split(',')[0])).Oznaka_D;
                i.UspostavljaPregledBroj_P = ps.FindById(Int32.Parse(SelectedUspostavka.Split(',')[1])).Broj_P;
                i.ReceptOznaka_R = rs.FindByName(SelectedRecept);

                if (iss.Insert(i))
                {

                    MessageBox.Show("Izdaje uspešno dodato.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
                CreatedIzdaje.UspostavljaDijagnozaOznaka_D = ds.FindById(Int32.Parse(SelectedUspostavka.Split(',')[0])).Oznaka_D;
                CreatedIzdaje.UspostavljaPregledBroj_P = ps.FindById(Int32.Parse(SelectedUspostavka.Split(',')[1])).Broj_P;
                CreatedIzdaje.ReceptOznaka_R = rs.FindByName(SelectedRecept);
                if (iss.Update(CreatedIzdaje))
                {
                    MessageBox.Show("Izdaje uspešno izmenjeno.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
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
