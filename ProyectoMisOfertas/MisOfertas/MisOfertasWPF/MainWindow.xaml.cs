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

            MisOfertas.Negocio.Producto pro = new MisOfertas.Negocio.Producto();
            MisOfertas.Negocio.Oferta Ofer = new MisOfertas.Negocio.Oferta();

            lboxProductos.ItemsSource = pro.ListaProductos();
            lboxOfertas.ItemsSource = Ofer.ListaOferta();

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

        private void Btn_alimentos_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();

            lboxProductos.ItemsSource = pro.ListaFiltrada(1);
            lboxProductos.Items.Refresh();
        }

        private void Btn_electronica_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();

            lboxProductos.ItemsSource = pro.ListaFiltrada(2);
            lboxProductos.Items.Refresh();
        }

        private void Btn_blanca_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();

            lboxProductos.ItemsSource = pro.ListaFiltrada(3);
            lboxProductos.Items.Refresh();
        }

        private void Btn_ropa_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();

            lboxProductos.ItemsSource = pro.ListaFiltrada(4);
            lboxProductos.Items.Refresh();
        }

        private void Btn_todos_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();

            lboxProductos.ItemsSource = pro.ListaProductos();
            lboxProductos.Items.Refresh();

        }

        private void Btn_alimentosOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();

            lboxOfertas.ItemsSource = ofer.ListaFiltrada(1);
            lboxOfertas.Items.Refresh();
        }

        private void Btn_todosOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();

            lboxOfertas.ItemsSource = ofer.ListaOferta();
            lboxOfertas.Items.Refresh();

        }

        private void Btn_electronicaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();

            lboxOfertas.ItemsSource = ofer.ListaFiltrada(2);
            lboxOfertas.Items.Refresh();
        }

        private void Btn_blancaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();

            lboxOfertas.ItemsSource = ofer.ListaFiltrada(3);
            lboxOfertas.Items.Refresh();
        }

        private void Btn_ropaOfer_Click(object sender, RoutedEventArgs e)
        {

            Oferta ofer = new MisOfertas.Negocio.Oferta();

            lboxOfertas.ItemsSource = ofer.ListaFiltrada(4);
            lboxOfertas.Items.Refresh();


        }

        //*****************************COMPLETE*****************************
    }
}