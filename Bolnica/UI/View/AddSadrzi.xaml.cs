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
    /// Interaction logic for AddSadrzi.xaml
    /// </summary>
    public partial class AddSadrzi : Window
    {
        public AddSadrzi(Sadrzi sa)
        {
            InitializeComponent();
            DataContext = new AddSadrziViewModel(sa) { Window = this };
        }
    }
}
