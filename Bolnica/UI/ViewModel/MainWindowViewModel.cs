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
        #region Propertiji
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
        public Izdaje SelectedIzdaje { get; set; }
        public SeLeci SelectedSeLeci { get; set; }
        public Sadrzi SelectedSadrzi { get; set; }
        public Poseduje SelectedPoseduje { get; set; }
        public Dolazi SelectedDolazi { get; set; }
        public Pregleda SelectedPregleda { get; set; }
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

        private List<Izdaje> izdaje;

        public List<Izdaje> Izdaje
        {
            get { return izdaje; }
            set { izdaje = value; OnPropertyChanged("Izdaje"); }
        }

        private List<SeLeci> seLeci;

        public List<SeLeci> SeLeci
        {
            get { return seLeci; }
            set { seLeci = value; OnPropertyChanged("SeLeci"); }
        }

        private List<Sadrzi> sadrzi;

        public List<Sadrzi> Sadrzi
        {
            get { return sadrzi; }
            set { sadrzi = value; OnPropertyChanged("Sadrzi"); }
        }

        private List<Poseduje> poseduje;

        public List<Poseduje> Poseduje
        {
            get { return poseduje; }
            set { poseduje = value; OnPropertyChanged("Poseduje"); }
        }

        private List<Dolazi> dolazi;

        public List<Dolazi> Dolazi
        {
            get { return dolazi; }
            set { dolazi = value; OnPropertyChanged("Dolazi"); }
        }


        private List<Pregleda> pregleda;

        public List<Pregleda> Pregleda
        {
            get { return pregleda; }
            set { pregleda = value; OnPropertyChanged("Pregleda"); }
        }
        #endregion

        #region Komande
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
        public MyICommand CreateIzdajeCommand { get; set; }
        public MyICommand UpdateIzdajeCommand { get; set; }
        public MyICommand DeleteIzdajeCommand { get; set; }
        public MyICommand CreateSeLeciCommand { get; set; }
        public MyICommand UpdateSeLeciCommand { get; set; }
        public MyICommand DeleteSeLeciCommand { get; set; }
        public MyICommand CreateSadrziCommand { get; set; }
        public MyICommand UpdateSadrziCommand { get; set; }
        public MyICommand DeleteSadrziCommand { get; set; }
        public MyICommand CreatePosedujeCommand { get; set; }
        public MyICommand UpdatePosedujeCommand { get; set; }
        public MyICommand DeletePosedujeCommand { get; set; }
        public MyICommand CreateDolaziCommand { get; set; }
        public MyICommand UpdateDolaziCommand { get; set; }
        public MyICommand DeleteDolaziCommand { get; set; }
        public MyICommand CreatePregledaCommand { get; set; }
        public MyICommand UpdatePregledaCommand { get; set; }
        public MyICommand DeletePregledaCommand { get; set; }
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
            DeleteIzdajeCommand = new MyICommand(OnDeleteIzdaje);
            UpdateIzdajeCommand = new MyICommand(OnUpdateIzdaje);
            CreateIzdajeCommand = new MyICommand(OnCreateIzdaje);
            DeleteSeLeciCommand = new MyICommand(OnDeleteSeLeci);
            UpdateSeLeciCommand = new MyICommand(OnUpdateSeLeci);
            CreateSeLeciCommand = new MyICommand(OnCreateSeLeci);
            DeleteSadrziCommand = new MyICommand(OnDeleteSadrzi);
            UpdateSadrziCommand = new MyICommand(OnUpdateSadrzi);
            CreateSadrziCommand = new MyICommand(OnCreateSadrzi);
            DeletePosedujeCommand = new MyICommand(OnDeletePoseduje);
            UpdatePosedujeCommand = new MyICommand(OnUpdatePoseduje);
            CreatePosedujeCommand = new MyICommand(OnCreatePoseduje);
            DeleteDolaziCommand = new MyICommand(OnDeleteDolazi);
            UpdateDolaziCommand = new MyICommand(OnUpdateDolazi);
            CreateDolaziCommand = new MyICommand(OnCreateDolazi);
            DeletePregledaCommand = new MyICommand(OnDeletePregleda);
            UpdatePregledaCommand = new MyICommand(OnUpdatePregleda);
            CreatePregledaCommand = new MyICommand(OnCreatePregleda);

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
            ReadAllIzdaje();
            ReadAllSeLeci();
            ReadAllSadrzi();
            ReadAllPoseduje();
            ReadAllDolazi();
            ReadAllPregleda();
        }

        public void OnCreateBolnica()
        {
            new AddBolnica(null).ShowDialog();
            OnChangeBolnica();
        }

        public void OnCreatePregleda()
        {
            new AddPregleda(null).ShowDialog();
            OnChangePregleda();
        }

        public void OnCreateLecenje()
        {
            new AddLecenje(null).ShowDialog();
            OnChangeLecenje();
        }

        public void OnCreateDolazi()
        {
            new AddDolazi(null).ShowDialog();
            OnChangeDolazi();
        }

        public void OnCreatePoseduje()
        {
            new AddPoseduje(null).ShowDialog();
            OnChangePoseduje();
        }

        public void OnCreateSadrzi()
        {
            new AddSadrzi(null).ShowDialog();
            OnChangeSadrzi();
        }

        public void OnCreateIzdaje()
        {
            new AddIzdaje(null).ShowDialog();
            OnChangeIzdaje();
        }

        public void OnCreateSeLeci()
        {
            new AddSeLeci(null).ShowDialog();
            OnChangeSeLeci();
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

        public void OnUpdatePoseduje()
        {
            new AddPoseduje(SelectedPoseduje).ShowDialog();
            OnChangePoseduje();
        }

        public void OnUpdateDolazi()
        {
            new AddDolazi(SelectedDolazi).ShowDialog();
            OnChangeDolazi();
        }

        public void OnUpdateSeLeci()
        {
            new AddSeLeci(SelectedSeLeci).ShowDialog();
            OnChangeSeLeci();
        }

        public void OnUpdatePregleda()
        {
            new AddPregleda(SelectedPregleda).ShowDialog();
            OnChangePregleda();
        }

        public void OnUpdateLecenje()
        {
            new AddLecenje(SelectedLecenje).ShowDialog();
            OnChangeLecenje();
        }

        public void OnUpdateIzdaje()
        {
            new AddIzdaje(SelectedIzdaje).ShowDialog();
            OnChangeIzdaje();
        }

        public void OnUpdateSadrzi()
        {
            new AddSadrzi(SelectedSadrzi).ShowDialog();
            OnChangeSadrzi();
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
            Servis.InterfejsServisi.ZdravstveniKartonServis zks = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            Servis.InterfejsServisi.DolaziServis ds = new Servis.InterfejsServisi.DolaziServis();
            bool zksobrisan = false;
            bool dsobrisan = false;

            if (zks.DeletePacijent(SelectedPacijent.Jmbg))
            {
                zksobrisan = true;
            }

            if (ds.DeletePacijent(SelectedPacijent.Jmbg))
            {
                dsobrisan = true;
            }

            if (zksobrisan || dsobrisan)
            {
                if (SelectedPacijent != null)
                {
                    ps.Delete(SelectedPacijent.Jmbg);
                }
                else
                {
                    MessageBox.Show("Niste izabrali pacijenta!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedPacijent != null)
                {
                    ps.Delete(SelectedPacijent.Jmbg);
                }
                else
                {
                    MessageBox.Show("Niste izabrali pacijenta!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            OnChangePacijent();
            OnChangeZdravstveniKarton();
            OnChangeDolazi();
        }

        public void OnDeleteDolazi()
        {
            Servis.InterfejsServisi.DolaziServis ds = new Servis.InterfejsServisi.DolaziServis();
            if (SelectedDolazi != null)
            {
                ds.Delete(SelectedDolazi.PacijentJmbg, SelectedDolazi.PregledBroj_P);
            }
            else
            {
                MessageBox.Show("Niste izabrali dolazi!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OnChangeDolazi();
        }

        public void OnDeletePoseduje()
        {
            Servis.InterfejsServisi.PosedujeServis ps = new Servis.InterfejsServisi.PosedujeServis();
            if (SelectedPoseduje != null)
            {
                ps.Delete(SelectedPoseduje.ZdravstveniKartonBroj_K, SelectedPoseduje.TerapijaBroj_T);
            }
            else
            {
                MessageBox.Show("Niste izabrali poseduje!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OnChangePoseduje();
        }

        public void OnDeleteSadrzi()
        {
            Servis.InterfejsServisi.SadrziServis sas = new Servis.InterfejsServisi.SadrziServis();
            if (SelectedSadrzi != null)
            {
                sas.Delete(SelectedSadrzi.ZdravstveniKartonBroj_K, SelectedSadrzi.DijagnozaOznaka_D);
            }
            else
            {
                MessageBox.Show("Niste izabrali sadrzi!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OnChangeSadrzi();
        }

        public void OnDeletePregleda()
        {
            Servis.InterfejsServisi.PregledaServis ps = new Servis.InterfejsServisi.PregledaServis();
            if (SelectedPregleda != null)
            {
                ps.Delete(SelectedPregleda.LekarJmbg, SelectedPregleda.PregledBroj_P);
            }
            else
            {
                MessageBox.Show("Niste izabrali pregleda!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OnChangePregleda();
        }

        public void OnDeleteSeLeci()
        {
            Servis.InterfejsServisi.SeLeciServis sls = new Servis.InterfejsServisi.SeLeciServis();
            if (SelectedSeLeci != null)
            {
                sls.Delete(SelectedSeLeci.LekId_Leka, SelectedSeLeci.DijagnozaOznaka_D);
            }
            else
            {
                MessageBox.Show("Niste izabrali SeLeci!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OnChangeSeLeci();
        }

        public void OnDeleteUspostavlja()
        {
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            Servis.InterfejsServisi.IzdajeServis iss = new Servis.InterfejsServisi.IzdajeServis();
            if (iss.DeleteUspostavlja(SelectedUspostavlja.DijagnozaOznaka_D, SelectedUspostavlja.PregledBroj_P))
            {
                if (SelectedUspostavlja != null)
                {
                    us.Delete(SelectedUspostavlja.PregledBroj_P, SelectedUspostavlja.DijagnozaOznaka_D);
                }
                else
                {
                    MessageBox.Show("Niste izabrali uspostavku!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedUspostavlja != null)
                {
                    us.Delete(SelectedUspostavlja.PregledBroj_P, SelectedUspostavlja.DijagnozaOznaka_D);
                }
                else
                {
                    MessageBox.Show("Niste izabrali uspostavku!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            OnChangeUspostavlja();
            OnChangeIzdaje();
            OnChangeRecept();
        }

        public void OnDeleteIzdaje()
        {
            Servis.InterfejsServisi.IzdajeServis iss = new Servis.InterfejsServisi.IzdajeServis();
            if (SelectedIzdaje != null)
            {
                iss.Delete(SelectedIzdaje.ReceptOznaka_R, SelectedIzdaje.UspostavljaPregledBroj_P,SelectedIzdaje.UspostavljaDijagnozaOznaka_D);
            }
            else
            {
                MessageBox.Show("Niste izabrali izdaje!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OnChangeIzdaje();
        }

        public void OnDeleteLecenje()
        {
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            if (us.DeleteLecenje(SelectedLecenje.DijagnozaOznaka_D, SelectedLecenje.TerapijaBroj_T))
            {
                if (SelectedLecenje != null)
                {
                    ls.Delete(SelectedLecenje.TerapijaBroj_T, SelectedLecenje.DijagnozaOznaka_D);
                }
                else
                {
                    MessageBox.Show("Niste izabrali lecenje!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedLecenje != null)
                {
                    ls.Delete(SelectedLecenje.TerapijaBroj_T, SelectedLecenje.DijagnozaOznaka_D);
                }
                else
                {
                    MessageBox.Show("Niste izabrali lecenje!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            OnChangeUspostavlja();
            OnChangeLecenje();
        }

        public void OnDeleteRecept()
        {
            Servis.InterfejsServisi.ReceptServis rs = new Servis.InterfejsServisi.ReceptServis();
            Servis.InterfejsServisi.IzdajeServis iss = new Servis.InterfejsServisi.IzdajeServis();
            if (iss.DeleteRecept(SelectedRecept.Oznaka_R))
            {
                if (SelectedRecept != null)
                {
                    rs.Delete(SelectedRecept.Oznaka_R);
                }
                else
                {
                    MessageBox.Show("Niste izabrali recept!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedRecept != null)
                {
                    rs.Delete(SelectedRecept.Oznaka_R);
                }
                else
                {
                    MessageBox.Show("Niste izabrali recept!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            OnChangeRecept();
            OnChangeIzdaje();
            OnChangeUspostavlja();
        }



        public void OnDeleteTerapija()
        {
            Servis.InterfejsServisi.TerapijaServis ts = new Servis.InterfejsServisi.TerapijaServis();
            Servis.InterfejsServisi.PosedujeServis ps = new Servis.InterfejsServisi.PosedujeServis();
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();

            bool psobrisan = false;
            bool lsobrisan = false;

            if (ps.DeleteTerapija(SelectedTerapija.Broj_T))
            {
                psobrisan = true;
            }

            if (ls.DeleteTerapija(SelectedTerapija.Broj_T))
            {
                lsobrisan = true;
            }

            if (psobrisan || lsobrisan)
            {
                if (SelectedTerapija != null)
                {
                    ts.Delete(SelectedTerapija.Broj_T);
                }
                else
                {
                    MessageBox.Show("Niste izabrali terapiju!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedTerapija != null)
                {
                    ts.Delete(SelectedTerapija.Broj_T);
                }
                else
                {
                    MessageBox.Show("Niste izabrali terapiju!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            OnChangePoseduje();
            OnChangeLecenje();
            OnChangeTerapija();
        }

        public void OnDeleteLek()
        {
            Servis.InterfejsServisi.LekServis ps = new Servis.InterfejsServisi.LekServis();
            Servis.InterfejsServisi.SeLeciServis ss = new Servis.InterfejsServisi.SeLeciServis();

            if (ss.DeleteLek(SelectedLek.Id_Leka))
            {
                if (SelectedLek != null)
                {
                    ps.Delete(SelectedLek.Id_Leka);
                }
                else
                {
                    MessageBox.Show("Niste izabrali lek!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedLek != null)
                {
                    ps.Delete(SelectedLek.Id_Leka);
                }
                else
                {
                    MessageBox.Show("Niste izabrali lek!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            OnChangeLek();
        }

        public void OnDeleteDijagnoza()
        {
            Servis.InterfejsServisi.DijagnozaServis ds = new Servis.InterfejsServisi.DijagnozaServis();
            Servis.InterfejsServisi.SeLeciServis ss = new Servis.InterfejsServisi.SeLeciServis();
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            Servis.InterfejsServisi.LecenjeServis ls = new Servis.InterfejsServisi.LecenjeServis();
            Servis.InterfejsServisi.SadrziServis sas = new Servis.InterfejsServisi.SadrziServis();

            bool ssobrisan = false;
            bool usobrisan = false;
            bool lsobrisan = false;
            bool sasobrisan = false;

            if (ss.DeleteDijagnoza(SelectedDijagnoza.Oznaka_D))
            {
                ssobrisan = true;
            }

            if (us.DeleteDijagnoza(SelectedDijagnoza.Oznaka_D))
            {
                usobrisan = true;
            }

            if (ls.DeleteDijagnoza(SelectedDijagnoza.Oznaka_D))
            {
                lsobrisan = true;
            }

            if (sas.DeleteDijagnoza(SelectedDijagnoza.Oznaka_D))
            {
                sasobrisan = true;
            }

            if (ssobrisan || usobrisan || lsobrisan || sasobrisan)
            {
                if (SelectedDijagnoza != null)
                {
                    ds.Delete(SelectedDijagnoza.Oznaka_D);
                }
                else
                {
                    MessageBox.Show("Niste izabrali dijagnozu!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedDijagnoza != null)
                {
                    ds.Delete(SelectedDijagnoza.Oznaka_D);
                }
                else
                {
                    MessageBox.Show("Niste izabrali dijagnozu!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            OnChangeSeLeci();
            OnChangeUspostavlja();
            OnChangeSadrzi();
            OnChangeLecenje();
            OnChangeDijagnoza();
        }

        public void OnDeleteZdravstveniKarton()
        {
            Servis.InterfejsServisi.ZdravstveniKartonServis ps = new Servis.InterfejsServisi.ZdravstveniKartonServis();
            Servis.InterfejsServisi.PosedujeServis pos = new Servis.InterfejsServisi.PosedujeServis();
            Servis.InterfejsServisi.SadrziServis sas = new Servis.InterfejsServisi.SadrziServis();

            bool posobrisan = false;
            bool sasobrisan = false;

            if (pos.DeleteZdravstveniKarton(SelectedZdravstveniKarton.Broj_K))
            {
                posobrisan = true;
            }

            if (sas.DeleteZdravstveniKarton(SelectedZdravstveniKarton.Broj_K))
            {
                sasobrisan = true;
            }

            if(posobrisan || sasobrisan)
            {
                if (SelectedZdravstveniKarton != null)
                {
                    ps.Delete(SelectedZdravstveniKarton.Broj_K);
                }
                else
                {
                    MessageBox.Show("Niste izabrali zdravstveni karton!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                if (SelectedZdravstveniKarton != null)
                {
                    ps.Delete(SelectedZdravstveniKarton.Broj_K);
                }
                else
                {
                    MessageBox.Show("Niste izabrali zdravstveni karton!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            OnChangeSadrzi();
            OnChangePoseduje();
            OnChangeZdravstveniKarton();
        }

        public void OnDeletePregled()
        {
            Servis.InterfejsServisi.PregledServis ps = new Servis.InterfejsServisi.PregledServis();
            Servis.InterfejsServisi.DolaziServis ds = new Servis.InterfejsServisi.DolaziServis();
            Servis.InterfejsServisi.PregledaServis prs = new Servis.InterfejsServisi.PregledaServis();
            Servis.InterfejsServisi.UspostavljaServis us = new Servis.InterfejsServisi.UspostavljaServis();
            bool dsobrisan = false;
            bool prsobrisan = false;
            bool usobrisan = false;
            if (ds.DeletePregled(SelectedPregled.Broj_P))
            {
                dsobrisan = true;
            }

            if (prs.DeletePregled(SelectedPregled.Broj_P))
            {
                prsobrisan = true;
            }

            if (us.DeletePregled(SelectedPregled.Broj_P))
            {
                usobrisan = true;
            }

            if (dsobrisan || prsobrisan || usobrisan)
            {
                if (SelectedPregled != null)
                {
                    ps.Delete(SelectedPregled.Broj_P);
                }
                else
                {
                    MessageBox.Show("Niste izabrali pregled!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedPregled != null)
                {
                    ps.Delete(SelectedPregled.Broj_P);
                }
                else
                {
                    MessageBox.Show("Niste izabrali pregled!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            OnChangePregled();
            OnChangeDolazi();
            OnChangeUspostavlja();
            OnChangePregleda();
        }

        public void OnDeleteBolnica()
        {
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            Servis.InterfejsServisi.PacijentServis ps = new Servis.InterfejsServisi.PacijentServis();
            Servis.InterfejsServisi.LekarServis ls = new Servis.InterfejsServisi.LekarServis();
            Servis.InterfejsServisi.ObezbedjenjeServis os = new Servis.InterfejsServisi.ObezbedjenjeServis();
            Servis.InterfejsServisi.RecepcionerServis rs = new Servis.InterfejsServisi.RecepcionerServis();

            bool psobrisan = false;
            bool lsobrisan = false;
            bool osobrisan = false;
            bool rsobrisan = false;

            if (ps.DeleteBolnica(SelectedBolnica.Oznaka_B))
            {
                psobrisan = true;
            }
            if (ls.DeleteBolnica(SelectedBolnica.Oznaka_B))
            {
                lsobrisan = true;
            }
            if (os.DeleteBolnica(SelectedBolnica.Oznaka_B))
            {
                osobrisan = true;
            }
            if (rs.DeleteBolnica(SelectedBolnica.Oznaka_B))
            {
                rsobrisan = true;
            }

            if (psobrisan || lsobrisan || osobrisan || rsobrisan)
            {
                if (SelectedBolnica != null)
                {
                    bs.Delete(SelectedBolnica.Oznaka_B);
                }
                else
                {
                    MessageBox.Show("Niste izabrali bolnicu!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedBolnica != null)
                {
                    bs.Delete(SelectedBolnica.Oznaka_B);
                }
                else
                {
                    MessageBox.Show("Niste izabrali bolnicu!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            OnChangeOsoba();
            OnChangeRadnik();
            OnChangePacijent();
            OnChangeLekar();
            OnChangeRecepcioner();
            OnChangeObezbedjenje();
            OnChangeBolnica();
            OnChangeZdravstveniKarton();
            OnChangeSadrzi();
            OnChangePoseduje();
            OnChangePregleda();
            OnChangeDolazi();
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
                MessageBox.Show("Niste izabrali osobu!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Niste izabrali obezbedjenje!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Niste izabrali radnika!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Niste izabrali recepcionera!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OnChangeRecepcioner();
            OnChangeOsoba();
            OnChangeRadnik();
        }

        public void OnDeleteLekar()
        {
            Servis.InterfejsServisi.LekarServis ls = new Servis.InterfejsServisi.LekarServis();
            Servis.InterfejsServisi.PregledaServis ps = new Servis.InterfejsServisi.PregledaServis();

            if (ps.DeleteLekar(SelectedLekar.Jmbg))
            {
                if (SelectedLekar != null)
                {
                    ls.Delete(SelectedLekar.Jmbg);
                }
                else
                {
                    MessageBox.Show("Niste izabrali lekara!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedLekar != null)
                {
                    ls.Delete(SelectedLekar.Jmbg);
                }
                else
                {
                    MessageBox.Show("Niste izabrali lekara!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            OnChangeLekar();
            OnChangePregleda();
            OnChangeOsoba();
            OnChangeRadnik();
        }

        public void OnDeleteMesto()
        {
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            Servis.InterfejsServisi.BolnicaServis bs = new Servis.InterfejsServisi.BolnicaServis();
            bool bsobrisan = false;

            if (bs.DeleteMesto(SelectedMesto.P_Broj))
            {
                bsobrisan = true;
            }


            if (bsobrisan)
            {
                if (SelectedMesto != null)
                {
                    ms.Delete(SelectedMesto.P_Broj);
                }
                else
                {
                    MessageBox.Show("Niste izabrali mesto!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (SelectedMesto != null)
                {
                    ms.Delete(SelectedMesto.P_Broj);
                }
                else
                {
                    MessageBox.Show("Niste izabrali mesto!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            OnChangeMesto();
            OnChangeOsoba();
            OnChangeRadnik();
            OnChangePacijent();
            OnChangeLekar();
            OnChangeRecepcioner();
            OnChangeObezbedjenje();
            OnChangeBolnica();
            OnChangeZdravstveniKarton();
            OnChangeSadrzi();
            OnChangePoseduje();
            OnChangePregleda();
            OnChangeDolazi();
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

        public void ReadAllSeLeci()
        {
            OnChangeSeLeci();
        }

        public void ReadAllDolazi()
        {
            OnChangeDolazi();
        }

        public void ReadAllPregleda()
        {
            OnChangePregleda();
        }

        public void ReadAllUspostavlja()
        {
            OnChangeUspostavlja();
        }

        public void ReadAllPoseduje()
        {
            OnChangePoseduje();
        }
        public void ReadAllIzdaje()
        {
            OnChangeIzdaje();
        }

        public void ReadAllLek()
        {
            OnChangeLek();
        }

        public void ReadAllSadrzi()
        {
            OnChangeSadrzi();
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
                Console.WriteLine("Message: " + e.Message);
            }
        }

        public void OnChangeSeLeci()
        {
            Servis.InterfejsServisi.SeLeciServis sls = new Servis.InterfejsServisi.SeLeciServis();
            try
            {
                SeLeci = sls.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
            }
        }

        public void OnChangeSadrzi()
        {
            Servis.InterfejsServisi.SadrziServis sas = new Servis.InterfejsServisi.SadrziServis();
            try
            {
                Sadrzi = sas.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
            }
        }

        public void OnChangePoseduje()
        {
            Servis.InterfejsServisi.PosedujeServis pos = new Servis.InterfejsServisi.PosedujeServis();
            try
            {
                Poseduje = pos.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
            }
        }

        public void OnChangeDolazi()
        {
            Servis.InterfejsServisi.DolaziServis ds = new Servis.InterfejsServisi.DolaziServis();
            try
            {
                Dolazi = ds.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
            }
        }

        public void OnChangeIzdaje()
        {
            Servis.InterfejsServisi.IzdajeServis iss = new Servis.InterfejsServisi.IzdajeServis();
            try
            {
                Izdaje = iss.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
            }
        }

        public void OnChangePregleda()
        {
            Servis.InterfejsServisi.PregledaServis ps = new Servis.InterfejsServisi.PregledaServis();
            try
            {
                Pregleda = ps.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
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
                Console.WriteLine("Message: " + e.Message);
            }
        }
    }
}
