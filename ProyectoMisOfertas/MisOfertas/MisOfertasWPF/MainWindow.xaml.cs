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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MisOfertas.Negocio;

//using MahApps.Metro.Controls;
//using MahApps.Metro.Controls.Dialogs;
//using MahApps.Metro.Behaviours;


namespace MisOfertasWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public void CerrarMain()
        {
            this.Hide();
        }

        private void Btn_iniciarS_Click(object sender, RoutedEventArgs e)
        {
            LoginConsumidor consumidor = new LoginConsumidor();
            
            consumidor.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
