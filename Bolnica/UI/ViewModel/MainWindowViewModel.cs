using Servis.Baza;
using Servis.PomocneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.View;

namespace UI.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        #region properties
        public Window Window { get; set; }

        public Bolnica SelectedBolnica { get; set; }
        public Mesto SelectedMesto { get; set; }
        public Lekar SelectedLekar { get; set; }
        public Recepcioner SelectedRecepcioner { get; set; }
        public Osoba SelectedOsoba { get; set; }
        public Obezbedjenje SelectedObezbedjenje { get; set; }
        public Radnik SelectedRadnik { get; set; }
        public Pacijent SelectedPacijent { get; set; }
        public Pregled SelectedPregled { get; set; }
        public ZdravstveniKarton SelectedZdravstveniKarton { get; set; }
        public Dijagnoza SelectedDijagnoza { get; set; }
        public Lek SelectedLek { get; set; }
        public Terapija SelectedTerapija { get; set; }
        public Recept SelectedRecept { get; set; }
        public Uspostavlja SelectedUspostavlja { get; set; }
        public Lecenje SelectedLecenje { get; set; }
        private List<Bolnica> bolnica;

        public List<Bolnica> Bolnica
        {
            get { return bolnica; }
            set { bolnica = value; OnPropertyChanged("Bolnica"); }
        }

        private List<Lekar> lekar;

        public List<Lekar> Lekar
        {
            get { return lekar; }
            set { lekar = value; OnPropertyChanged("Lekar"); }
        }


        private List<Mesto> mesto;

        public List<Mesto> Mesto
        {
            get { return mesto; }
            set { mesto = value; OnPropertyChanged("Mesto"); }
        }

        private List<Recepcioner> recepcioner;

        public List<Recepcioner> Recepcioner
        {
            get { return recepcioner; }
            set { recepcioner = value; OnPropertyChanged("Recepcioner"); }
        }

        private List<Osoba> osoba;

        public List<Osoba> Osoba
        {
            get { return osoba; }
            set { osoba = value; OnPropertyChanged("Osoba"); }
        }

        private List<Radnik> radnik;

        public List<Radnik> Radnik
        {
            get { return radnik; }
            set { radnik = value; OnPropertyChanged("Radnik"); }
        }

        private List<Obezbedjenje> obezbedjenje;

        public List<Obezbedjenje> Obezbedjenje
        {
            get { return obezbedjenje; }
            set { obezbedjenje = value; OnPropertyChanged("Obezbedjenje"); }
        }

        private List<Pacijent> pacijent;

        public List<Pacijent> Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; OnPropertyChanged("Pacijent"); }
        }

        private List<Pregled> pregled;

        public List<Pregled> Pregled
        {
            get { return pregled; }
            set { pregled = value; OnPropertyChanged("Pregled"); }
        }

        private List<ZdravstveniKarton> zdravstveniKarton;

        public List<ZdravstveniKarton> ZdravstveniKarton
        {
            get { return zdravstveniKarton; }
            set { zdravstveniKarton = value; OnPropertyChanged("ZdravstveniKarton"); }
        }

        private List<Dijagnoza> dijagnoza;

        public List<Dijagnoza> Dijagnoza
        {
            get { return dijagnoza; }
            set { dijagnoza = value; OnPropertyChanged("Dijagnoza"); }
        }

        private List<Lek> lek;

        public List<Lek> Lek
        {
            get { return lek; }
            set { lek = value; OnPropertyChanged("Lek"); }
        }

        private List<Terapija> terapija;

        public List<Terapija> Terapija
        {
            get { return terapija; }
            set { terapija = value; OnPropertyChanged("Terapija"); }
        }

        private List<Recept> recept;

        public List<Recept> Recept
        {
            get { return recept; }
            set { recept = value; OnPropertyChanged("Recept"); }
        }

        private List<Uspostavlja> uspostavlja;

        public List<Uspostavlja> Uspostavlja
        {
            get { return uspostavlja; }
            set { uspostavlja = value; OnPropertyChanged("Uspostavlja"); }
        }

        private List<Lecenje> lecenje;

        public List<Lecenje> Lecenje
        {
            get { return lecenje; }
            set { lecenje = value; OnPropertyChanged("Lecenje"); }
        }
        #endregion

        #region commands
        public MyICommand CreateBolnicaCommand { get; set; }
        public MyICommand CreateMestoCommand { get; set; }
        public MyICommand UpdateBolnicaCommand { get; set; }
        public MyICommand UpdateMestoCommand { get; set; }
        public MyICommand CreateLekarCommand { get; set; }
        public MyICommand UpdateLekarCommand { get; set; }
        public MyICommand CreateRecepcionerCommand { get; set; }
        public MyICommand CreateObezbedjenjeCommand { get; set; }
        public MyICommand UpdateRecepcionerCommand { get; set; }
        public MyICommand UpdateObezbedjenjeCommand { get; set; }
        public MyICommand DeleteBolnicaCommand { get; set; }
        public MyICommand DeleteMestoCommand { get; set; }
        public MyICommand DeleteLekarCommand { get; set; }
        public MyICommand DeleteOsobaCommand { get; set; }
        public MyICommand DeleteRecepcionerCommand { get; set; }
        public MyICommand DeleteRadnikCommand { get; set; }
        public MyICommand DeleteObezbedjenjeCommand { get; set; }
        public MyICommand CreatePacijentCommand { get; set; }
        public MyICommand UpdatePacijentCommand { get; set; }
        public MyICommand DeletePacijentCommand { get; set; }
        public MyICommand CreatePregledCommand { get; set; }
        public MyICommand UpdatePregledCommand { get; set; }
        public MyICommand DeletePregledCommand { get; set; }
        public MyICommand CreateZdravstveniKartonCommand { get; set; }
        public MyICommand UpdateZdravstveniKartonCommand { get; set; }
        public MyICommand DeleteZdravstveniKartonCommand { get; set; }
        public MyICommand CreateDijagnozaCommand { get; set; }
        public MyICommand UpdateDijagnozaCommand { get; set; }
        public MyICommand DeleteDijagnozaCommand { get; set; }
        public MyICommand CreateLekCommand { get; set; }
        public MyICommand UpdateLekCommand { get; set; }
        public MyICommand DeleteLekCommand { get; set; }
        public MyICommand CreateTerapijaCommand { get; set; }
        public MyICommand UpdateTerapijaCommand { get; set; }
        public MyICommand DeleteTerapijaCommand { get; set; }
        public MyICommand CreateReceptCommand { get; set; }
        public MyICommand UpdateReceptCommand { get; set; }
        public MyICommand DeleteReceptCommand { get; set; }
        public MyICommand CreateUspostavljaCommand { get; set; }
        public MyICommand UpdateUspostavljaCommand { get; set; }
        public MyICommand DeleteUspostavljaCommand { get; set; }
        public MyICommand CreateLecenjeCommand { get; set; }
        public MyICommand UpdateLecenjeCommand { get; set; }
        public MyICommand DeleteLecenjeCommand { get; set; }
        #endregion


        public MainWindowViewModel()
        {
            CreateBolnicaCommand = new MyICommand(OnCreateBolnica);
            UpdateBolnicaCommand = new MyICommand(OnUpdateBolnica);
            CreateMestoCommand = new MyICommand(OnCreateMesto);
            CreateLekarCommand = new MyICommand(OnCreateLekar);
            UpdateMestoCommand = new MyICommand(OnUpdateMesto);
            UpdateLekarCommand = new MyICommand(OnUpdateLekar);
            CreateRecepcionerCommand = new MyICommand(OnCreateRecepcioner);
            CreateObezbedjenjeCommand = new MyICommand(OnCreateObezbedjenje);
            UpdateRecepcionerCommand = new MyICommand(OnUpdateRecepcioner);
            UpdateObezbedjenjeCommand = new MyICommand(OnUpdateObezbedjenje);
            DeleteBolnicaCommand = new MyICommand(OnDeleteBolnica);
            DeleteMestoCommand = new MyICommand(OnDeleteMesto);
            DeleteLekarCommand = new MyICommand(OnDeleteLekar);
            DeleteOsobaCommand = new MyICommand(OnDeleteOsoba);
            DeleteRecepcionerCommand = new MyICommand(OnDeleteRecepcioner);
            DeleteRadnikCommand = new MyICommand(OnDeleteRadnik);
            DeleteObezbedjenjeCommand = new MyICommand(OnDeleteObezbedjenje);
            DeletePacijentCommand = new MyICommand(OnDeletePacijent);
            UpdatePacijentCommand = new MyICommand(OnUpdatePacijent);
            CreatePacijentCommand = new MyICommand(OnCreatePacijent);
            DeletePregledCommand = new MyICommand(OnDeletePregled);
            UpdatePregledCommand = new MyICommand(OnUpdatePregled);
            CreatePregledCommand = new MyICommand(OnCreatePregled);
            DeleteZdravstveniKartonCommand = new MyICommand(OnDeleteZdravstveniKarton);
            UpdateZdravstveniKartonCommand = new MyICommand(OnUpdateZdravstveniKarton);
            CreateZdravstveniKartonCommand = new MyICommand(OnCreateZdravstveniKarton);
            DeleteDijagnozaCommand = new MyICommand(OnDeleteDijagnoza);
            UpdateDijagnozaCommand = new MyICommand(OnUpdateDijagnoza);
            CreateDijagnozaCommand = new MyICommand(OnCreateDijagnoza);
            DeleteLekCommand = new MyICommand(OnDeleteLek);
            UpdateLekCommand = new MyICommand(OnUpdateLek);
            CreateLekCommand = new MyICommand(OnCreateLek);
            DeleteTerapijaCommand = new MyICommand(OnDeleteTerapija);
            UpdateTerapijaCommand = new MyICommand(OnUpdateTerapija);
            CreateTerapijaCommand = new MyICommand(OnCreateTerapija);
            DeleteReceptCommand = new MyICommand(OnDeleteRecept);
            UpdateReceptCommand = new MyICommand(OnUpdateRecept);
            CreateReceptCommand = new MyICommand(OnCreateRecept);
            DeleteUspostavljaCommand = new MyICommand(OnDeleteUspostavlja);
            UpdateUspostavljaCommand = new MyICommand(OnUpdateUspostavlja);
            CreateUspostavljaCommand = new MyICommand(OnCreateUspostavlja);
            DeleteLecenjeCommand = new MyICommand(OnDeleteLecenje);
            UpdateLecenjeCommand = new MyICommand(OnUpdateLecenje);
            CreateLecenjeCommand = new MyICommand(OnCreateLecenje);

            ReadAllMesto();
            ReadAllBolnica();
            ReadAllLekar();
            ReadAllRecepcioner();
            ReadAllOsoba();
            ReadAllRadnik();
            ReadAllObezbedjenje();
            ReadAllPregled();
            ReadAllPacijent();
            ReadAllZdravstveniKarton();
            ReadAllDijagnoza();
            ReadAllLek();
            ReadAllTerapija();
            ReadAllRecept();
            ReadAllUspostavlja();
            ReadAllLecenje();
        }

        public void OnCreateBolnica()
        {
            new AddBolnica(null).ShowDialog();
            OnChangeBolnica();
        }

        public void OnCreateLecenje()
        {
            new AddLecenje(null).ShowDialog();
            OnChangeLecenje();
        }

        public void OnCreateUspostavlja()
        {
            new AddUspostavlja(null).ShowDialog();
            OnChangeUspostavlja();
        }

        public void OnCreateRecept()
        {
            new AddRecept(null).ShowDialog();
            OnChangeRecept();
        }

        public void OnCreateTerapija()
        {
            new AddTerapija(null).ShowDialog();
            OnChangeTerapija();
        }

        public void OnCreateLek()
        {
            new AddLek(null).ShowDialog();
            OnChangeLek();
        }

        public void OnCreateDijagnoza()
        {
            new AddDijagnoza(null).ShowDialog();
            OnChangeDijagnoza();
        }

        public void OnCreateZdravstveniKarton()
        {
            new AddZdravstveniKarton(null).ShowDialog();
            OnChangeZdravstveniKarton();
        }

        public void OnCreatePacijent()
        {
            new AddPacijent(null).ShowDialog();
            OnChangePacijent();
            OnChangeOsoba();
        }

        public void OnCreatePregled()
        {
            new AddPregled(null).ShowDialog();
            OnChangePregled();
        }

        public void OnCreateLekar()
        {
            new AddLekar(null).ShowDialog();
            OnChangeLekar();
            OnChangeRadnik();
            OnChangeOsoba();
        }

        public void OnUpdateBolnica()
        {
            new AddBolnica(SelectedBolnica).ShowDialog();
            OnChangeBolnica();
        }

        public void OnUpdateLecenje()
        {
            new AddLecenje(SelectedLecenje).ShowDialog();
            OnChangeLecenje();
        }

        public void OnUpdateUspostavlja()
        {
            new AddUspostavlja(SelectedUspostavlja).ShowDialog();
            OnChangeUspostavlja();
        }

        public void OnUpdateDijagnoza()
        {
            new AddDijagnoza(SelectedDijagnoza).ShowDialog();
            OnChangeDijagnoza();
        }

        public void OnUpdateRecept()
        {
            new AddRecept(SelectedRecept).ShowDialog();
            OnChangeRecept();
        }

        public void OnUpdateTerapija()
        {
            new AddTerapija(SelectedTerapija).ShowDialog();
            OnChangeTerapija();
        }

        public void OnUpdateLek()
        {
            new AddLek(SelectedLek).ShowDialog();
            OnChangeLek();
        }

        public void OnUpdatePregled()
        {
            new AddPregled(SelectedPregled).ShowDialog();
            OnChangePregled();
        }

        public void OnUpdateZdravstveniKarton()
        {
            new AddZdravstveniKarton(SelectedZdravstveniKarton).ShowDialog();
            OnChangeZdravstveniKarton();
        }

        public void OnUpdatePacijent()
        {
            new AddPacijent(SelectedPacijent).ShowDialog();
            OnChangePacijent();
            OnChangeOsoba();
        }

        public void OnDeletePacijent()
        {
            Servis.InterfejsServisi.PacijentServis ps = new Servis.InterfejsServisi.PacijentServis();
            if(SelectedPacijent != null)
            {
                ps.Delete(SelectedPacijent.Jmbg);
            }
            else
            {
                MessageBox.Show("Niste izabrali pacijenta!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            OnChangeBolnica();
            OnChangePacijent();
            OnChangeOsoba();
        }

        public void OnDeleteUspostavlja()
        {
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            if (SelectedUspostavlja != null)
            {
                us.Delete(SelectedUspostavlja.PregledBroj_P, SelectedUspostavlja.DijagnozaOznaka_D);
            }
            else
            {
                MessageBox.Show("Niste izabrali uspostavku!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeUspostavlja();
        }

        public void OnDeleteLecenje()
        {
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();
            if (SelectedLecenje != null)
            {
                ls.Delete(SelectedLecenje.TerapijaBroj_T, SelectedLecenje.DijagnozaOznaka_D);
            }
            else
            {
                MessageBox.Show("Niste izabrali lecenje!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeLecenje();
        }

        public void OnDeleteRecept()
        {
            Servis.InterfejsServisi.ReceptServis rs = new Servis.InterfejsServisi.ReceptServis();
            if (SelectedRecept != null)
            {
                rs.Delete(SelectedRecept.Oznaka_R);
            }
            else
            {
                MessageBox.Show("Niste izabrali recept!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeRecept();
        }

        public void OnDeleteTerapija()
        {
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            if (SelectedTerapija != null)
            {
                ts.Delete(SelectedTerapija.Broj_T);
            }
            else
            {
                MessageBox.Show("Niste izabrali terapiju!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeTerapija();
        }

        public void OnDeleteLek()
        {
            Servis.InterfejsServisi.LekServis ps = new Servis.InterfejsServisi.LekServis();
            if (SelectedLek != null)
            {
                ps.Delete(SelectedLek.Id_Leka);
            }
            else
            {
                MessageBox.Show("Niste izabrali lek!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeLek();
        }

        public void OnDeleteDijagnoza()
        {
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            if (SelectedDijagnoza != null)
            {
                ds.Delete(SelectedDijagnoza.Oznaka_D);
            }
            else
            {
                MessageBox.Show("Niste izabrali dijagnozu!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeDijagnoza();
        }

        public void OnDeleteZdravstveniKarton()
        {
            Servis.InterfejsServisi.ZdravstveniKartonServis ps = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            if (SelectedZdravstveniKarton != null)
            {
                ps.Delete(SelectedZdravstveniKarton.Broj_K);
            }
            else
            {
                MessageBox.Show("Niste izabrali zdravstveni karton!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeZdravstveniKarton();
        }

        public void OnDeletePregled()
        {
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            if (SelectedPregled != null)
            {
                ps.Delete(SelectedPregled.Broj_P);
            }
            else
            {
                MessageBox.Show("Niste izabrali pregled!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            OnChangePregled();
        }

        public void OnDeleteBolnica()
        {
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            if (SelectedBolnica != null)
            {
                bs.Delete(SelectedBolnica.Oznaka_B);
            }
            else
            {
                MessageBox.Show("Niste izabrali bolnicu!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeBolnica();
        }


        public void OnDeleteOsoba()
        {
            Servis.InterfejsServisi.OsobaServis os = new Servis.InterfejsServisi.OsobaServis();
            if (SelectedOsoba != null)
            {
                os.Delete(SelectedOsoba.Jmbg);
            }
            else
            {
                MessageBox.Show("Niste izabrali osobu!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeOsoba();
            OnChangeRadnik();
            OnChangeLekar();
        }

        public void OnDeleteObezbedjenje()
        {
            Servis.InterfejsServisi.ObezbedjenjeServis os = new Servis.InterfejsServisi.ObezbedjenjeServis();
            if (SelectedObezbedjenje != null)
            {
                os.Delete(SelectedObezbedjenje.Jmbg);
            }
            else
            {
                MessageBox.Show("Niste izabrali obezbedjenje!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeObezbedjenje();
            OnChangeOsoba();
            OnChangeRadnik();
        }

        public void OnDeleteRadnik()
        {
            Servis.InterfejsServisi.RadnikServis rs = new Servis.InterfejsServisi.RadnikServis();
            if (SelectedRadnik != null)
            {
                rs.Delete(SelectedRadnik.Jmbg);
            }
            else
            {
                MessageBox.Show("Niste izabrali radnika!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeRadnik();
            OnChangeOsoba();
            OnChangeLekar();
            OnChangeRecepcioner();

        }

        public void OnDeleteRecepcioner()
        {
            Servis.InterfejsServisi.RecepcionerServis rs = new Servis.InterfejsServisi.RecepcionerServis();
            if (SelectedRecepcioner != null)
            {
                rs.Delete(SelectedRecepcioner.Jmbg);
            }
            else
            {
                MessageBox.Show("Niste izabrali recepcionera!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            OnChangeRecepcioner();
            OnChangeOsoba();
            OnChangeRadnik();
        }

        public void OnDeleteLekar()
        {
            Servis.InterfejsServisi.LekarServis ls = new Servis.InterfejsServisi.LekarServis();
            if(SelectedLekar != null)
            { 
                ls.Delete(SelectedLekar.Jmbg);
            }
            else
            {
                MessageBox.Show("Niste izabrali lekara!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            OnChangeLekar();
            OnChangeOsoba();
            OnChangeRadnik();
        }

        public void OnDeleteMesto()
        {
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            if (SelectedMesto != null)
            {
                ms.Delete(SelectedMesto.P_Broj);
            }
            else
            {
                MessageBox.Show("Niste izabrali mesto!", "Operacija neuspesna!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            OnChangeMesto();
        }

        public void OnCreateRecepcioner()
        {
            new AddRecepcioner(null).ShowDialog();
            OnChangeRecepcioner();
            OnChangeOsoba();
            OnChangeRadnik();
        }

        public void OnCreateObezbedjenje()
        {
            new AddObezbedjenje(null).ShowDialog();
            OnChangeOsoba();
            OnChangeRadnik();
            OnChangeObezbedjenje();
        }

        public void OnUpdateRecepcioner()
        {
            new AddRecepcioner(SelectedRecepcioner).ShowDialog();
            OnChangeRecepcioner();
            OnChangeOsoba();
            OnChangeRadnik();
        }

        public void OnUpdateObezbedjenje()
        {
            new AddObezbedjenje(SelectedObezbedjenje).ShowDialog();
            OnChangeOsoba();
            OnChangeRadnik();
            OnChangeObezbedjenje();
        }

        public void ReadAllMesto()
        {
            OnChangeMesto();
        }

        public void ReadAllUspostavlja()
        {
            OnChangeUspostavlja();
        }

        public void ReadAllLek()
        {
            OnChangeLek();
        }

        public void ReadAllLecenje()
        {
            OnChangeLecenje();
        }

        public void ReadAllTerapija()
        {
            OnChangeTerapija();
        }

        public void ReadAllPacijent()
        {
            OnChangePacijent();
        }

        public void ReadAllRecepcioner()
        {
            OnChangeRecepcioner();
        }

        public void ReadAllDijagnoza()
        {
            OnChangeDijagnoza();
        }


        public void ReadAllRecept()
        {
            OnChangeRecept();
        }

        public void ReadAllLekar()
        {
            OnChangeLekar();
        }

        public void ReadAllZdravstveniKarton()
        {
            OnChangeZdravstveniKarton();
        }

        public void ReadAllPregled()
        {
            OnChangePregled();
        }

        public void ReadAllRadnik()
        {
            OnChangeRadnik();
        }

        public void ReadAllObezbedjenje()
        {
            OnChangeObezbedjenje();
        }

        public void ReadAllOsoba()
        {
            OnChangeOsoba();
        }

        public void ReadAllBolnica()
        {
            OnChangeBolnica();
        }

        public void OnCreateMesto()
        {
            new AddMesto(null).ShowDialog();
            OnChangeMesto();
        }


        public void OnUpdateMesto()
        {
            new AddMesto(SelectedMesto).ShowDialog();
            OnChangeMesto();
        }

        public void OnUpdateLekar()
        {
            new AddLekar(SelectedLekar).ShowDialog();
            OnChangeLekar();
            OnChangeOsoba();
            OnChangeRadnik();
        }


        public void OnChangeBolnica()
        {
            Servis.InterfejsServisi.BolnicaServis bo = new Servis.InterfejsServisi.BolnicaServis();
            try
            {
                Bolnica = bo.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeLecenje()
        {
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();
            try
            {
                Lecenje = ls.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeDijagnoza()
        {
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            try
            {
                Dijagnoza = ds.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeLek()
        {
            Servis.InterfejsServisi.LekServis ls = new Servis.InterfejsServisi.LekServis();
            try
            {
                Lek = ls.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeRecept()
        {
            Servis.InterfejsServisi.ReceptServis rs = new Servis.InterfejsServisi.ReceptServis();
            try
            {
                Recept = rs.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeOsoba()
        {
            Servis.InterfejsServisi.OsobaServis os = new Servis.InterfejsServisi.OsobaServis();
            try
            {
                Osoba = os.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeUspostavlja()
        {
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            try
            {
                Uspostavlja = us.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeTerapija()
        {
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            try
            {
                Terapija = ts.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangePacijent()
        {
            Servis.InterfejsServisi.PacijentServis ps = new Servis.InterfejsServisi.PacijentServis();
            try
            {
                Pacijent = ps.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeObezbedjenje()
        {
            Servis.InterfejsServisi.ObezbedjenjeServis os = new Servis.InterfejsServisi.ObezbedjenjeServis();
            try
            {
                Obezbedjenje = os.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeRadnik()
        {
            Servis.InterfejsServisi.RadnikServis rs = new Servis.InterfejsServisi.RadnikServis();
            try
            {
                Radnik = rs.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeRecepcioner()
        {
            Servis.InterfejsServisi.RecepcionerServis rs = new Servis.InterfejsServisi.RecepcionerServis();
            try
            {
                Recepcioner = rs.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangePregled()
        {
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            try
            {
                Pregled = ps.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeLekar()
        {
            Servis.InterfejsServisi.LekarServis bo = new Servis.InterfejsServisi.LekarServis();
            try
            {
                Lekar = bo.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeMesto()
        {
            Servis.InterfejsServisi.MestoServis bo = new Servis.InterfejsServisi.MestoServis();
            try
            {
                Mesto = bo.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }

        public void OnChangeZdravstveniKarton()
        {
            Servis.InterfejsServisi.ZdravstveniKartonServis zks = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            try
            {
                ZdravstveniKarton = zks.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\n\nTrace:\n" + e.StackTrace + "\n\nInner:\n\n" + e.InnerException);
            }
        }
    }
}
