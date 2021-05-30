using Servis.Baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI.ViewModel;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for AddBolnica.xaml
    /// </summary>
    public partial class AddBolnica : Window
    {
        public AddBolnica(Bolnica bolnica)
        {
            InitializeComponent();
            DataContext = new AddBolnicaViewModel(bolnica) { Window = this };
        }
    }
}
