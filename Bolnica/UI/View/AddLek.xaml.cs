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
    /// Interaction logic for AddLek.xaml
    /// </summary>
    public partial class AddLek : Window
    {
        public AddLek(Lek lek)
        {
            InitializeComponent();
            DataContext = new AddLekViewModel(lek) { Window = this };
        }
    }
}
