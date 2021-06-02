using Servis.Baza;
using Servis.PomocneKlase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModel
{
    public class ExecuteProcedureViewModel:BindableBase
    {
        public Window Window { get; set; }
        private string selectedOsoba;

        public string SelectedOsoba
        {
            get { return selectedOsoba; }
            set { selectedOsoba = value; OnPropertyChanged("SelectedOsoba"); }
        }

        private string rez;

        public string Rez
        {
            get { return rez; }
            set { rez = value; OnPropertyChanged("Rez"); }
        }

        private string selectedMesto;

        public string SelectedMesto
        {
            get { return selectedMesto; }
            set { selectedMesto = value; OnPropertyChanged("SelectedMesto"); }
        }

        private ObservableCollection<string> osobe;

        public ObservableCollection<string> Osobe
        {
            get { return osobe; }
            set { osobe = value; OnPropertyChanged("Osobe"); }
        }

        private ObservableCollection<string> mesta;

        public ObservableCollection<string> Mesta
        {
            get { return mesta; }
            set { mesta = value; OnPropertyChanged("Mesta"); }
        }

        public MyICommand ExecuteProcedureCommand { get; set; }
        public ExecuteProcedureViewModel()
        {
            ExecuteProcedureCommand = new MyICommand(OnExecuteProcedure);
            List<Osoba> osobee = new List<Osoba>();
            List<Mesto> mestaa = new List<Mesto>();
            ObservableCollection<string> dobavljeneOsobe = new ObservableCollection<string>();
            ObservableCollection<string> dobavljenaMesta = new ObservableCollection<string>();
            Servis.InterfejsServisi.OsobaServis os = new Servis.InterfejsServisi.OsobaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();

            osobee = os.GetAll();

            foreach (var item in osobee)
            {
                dobavljeneOsobe.Add(item.Jmbg.ToString());
            }
            Osobe = dobavljeneOsobe;

            if (Osobe.Count == 0)
            {
                MessageBox.Show("Nema osoba.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SelectedOsoba = Osobe[0];
            }

            mestaa = ms.GetAll();

            foreach (var item in mestaa)
            {
                dobavljenaMesta.Add(item.Naziv);
            }
            Mesta = dobavljenaMesta;

            if (Mesta.Count == 0)
            {
                MessageBox.Show("Nema mesta.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SelectedMesto = Mesta[0];
            }
        }

        public void OnExecuteProcedure()
        {
            SqlConnection myConn = new SqlConnection("data source=DESKTOP-F0GE8QS\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=BolnicaDB");
            Servis.InterfejsServisi.OsobaServis os = new Servis.InterfejsServisi.OsobaServis();
            Servis.InterfejsServisi.MestoServis ms = new Servis.InterfejsServisi.MestoServis();
            int osobaJmbg = Int32.Parse(SelectedOsoba);
            int mestoPBroj = ms.FindByName(SelectedMesto);
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("PronadjiZdravstveniKarton", myConn);
            SqlParameter param = new SqlParameter();

            myCmd.CommandType = CommandType.StoredProcedure;

            myCmd.Parameters.AddWithValue("@Jmbg", osobaJmbg);
            myCmd.Parameters.AddWithValue("@Mesto", mestoPBroj);
            myCmd.Parameters.Add("@Zk", SqlDbType.Int);
            myCmd.Parameters["@Zk"].Direction = ParameterDirection.Output;



            myCmd.ExecuteNonQuery();
            object zk = (myCmd.Parameters["@Zk"].Value);
            Rez = zk.ToString();

            //MessageBox.Show("Uspesno ste izvrsili proceduru!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

            myConn.Close();
            //Window.Close();
        }
    }
}
