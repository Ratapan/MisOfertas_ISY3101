using System;
using System.Collections.Generic;
using System.IO;
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
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using MisOfertas.Negocio;


namespace MisOfertasWPF
{
    /// <summary>
    /// Lógica de interacción para PerfilConsumidor.xaml
    /// </summary>
    public partial class PerfilConsumidor
    {

        public PerfilConsumidor()
        {
            InitializeComponent();

            MisOfertas.Negocio.Producto pro = new Producto();
            MisOfertas.Negocio.Oferta Ofer = new MisOfertas.Negocio.Oferta();

            lboxProductosConsu.ItemsSource = pro.ListaProductos();
            lboxOfertasConsu.ItemsSource = Ofer.ListaOferta();
        }
        public string id;
        Byte[] FotoBoleta = null;

        public void Limpiar()
        {
            txt_rut.Text = string.Empty;
            txt_nombres.Text = string.Empty;
            txt_apellidos.Text = string.Empty;
            cb_sexo.SelectedIndex = 0;
            cb_ciudad.SelectedIndex = 0;
            dp_nacimiento.SelectedDate = null;
            txt_email.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CambiarContrasena cambiar = new CambiarContrasena();
            
            Cliente cli = new Cliente()
            {
                Rut = txt_rut.Text,
            };
            if (cli.Read())
            {
                cambiar.id = cli.Rut;
            }
            cambiar.Show();


        }



        private async void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult Result = await this.ShowMessageAsync("CONFIRMACIÓN", "¿Seguro Que Desea Actualizar Los datos?", MessageDialogStyle.Affirmative);
            if (Result == MessageDialogResult.Affirmative)
            {
                Cliente cli = new Cliente();
                if (cli.UpdateData(txt_rut.Text, txt_nombres.Text, txt_apellidos.Text, 
                    cb_sexo.SelectedIndex, cb_ciudad.SelectedIndex,
                    (DateTime)dp_nacimiento.SelectedDate, txt_email.Text))
                {
                    await this.ShowMessageAsync(null, "Modificacion Realizada Correctamente.");

                }
                else
                {
                    await this.ShowMessageAsync(null, "Error, No se Pudieron Modificar los Datos.");
                }
            }



        }

        private async void Btn_iniciarS_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult Result = await this.ShowMessageAsync("Confirmación", "¿Está Seguro que Desea Cerrar sesión.?", MessageDialogStyle.AffirmativeAndNegative);

            if (Result == MessageDialogResult.Affirmative)
            {
                this.Hide();
                App.Current.MainWindow.Show();
                App.Current.MainWindow.Closed += (s, args) => App.Current.Shutdown();


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public int idofer; 


        private void LboxOfertasConsu_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var Oferta = (MisOfertas.Datos.Oferta)item.SelectedItem;

            Oferta ofer = new Oferta();

            try
            {
                txt_NomProduc.Text = Oferta.Descripcion;
                txt_ValorProduc.Text = "Valor: " + Oferta.Precio.ToString();
                txt_Ofertaproduc.Text = "Valor Oferta: " + Oferta.PrecioOferta.ToString();
                Img_Produc.Source = Encrypt.ByteToImage(Oferta.Fotoproducto);
                idofer = Oferta.Idoferta;


            }
            catch (Exception)
            {
                txt_NomProduc.Text = null;
                txt_ValorProduc.Text = null;
                txt_Ofertaproduc.Text = null;
                Img_Produc.Source = null;
                idofer = 0;

            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            openFileDlg.FilterIndex = 1;
            openFileDlg.RestoreDirectory = true;

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                txt_ruta.Text = openFileDlg.FileName;

                //Byte[] FotoBoleta = null;
                Stream myStream = openFileDlg.OpenFile();

                FotoBoleta = Encrypt.StreamToByte(myStream);

            }

        }

        private async void Btn_Valorar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_ruta.Text.Equals(""))
            {
                await this.ShowMessageAsync("ERROR", "La Foto de la Boleta es obligatoria para poder realizar la Valoración");
            }
            else
            {
                Valoracion_Oferta valorar = new Valoracion_Oferta()
                    {
                        Fotooferta = FotoBoleta,
                        Idoferta = idofer,
                        Rut = txt_rutValorar.Text,
                        Idnotaoferta = cb_nota.SelectedIndex,
                    };

                if (valorar.Create())
                {
                    await this.ShowMessageAsync("EXITO", "Su valoracion Fue Ingresada Correctamente");
                }
                else
                {
                    await this.ShowMessageAsync("ERROR", "Su valoracion No pudo ser Ingresada");
                }
            }
        }

        private void Btn_todos_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();
            lboxProductosConsu.ItemsSource = pro.ListaProductos();
            lboxProductosConsu.Items.Refresh();
        }

        private void Btn_alimentos_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();
            lboxProductosConsu.ItemsSource = pro.ListaFiltrada(1);
            lboxProductosConsu.Items.Refresh();
        }

        private void Btn_electronica_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();
            lboxProductosConsu.ItemsSource = pro.ListaFiltrada(2);
            lboxProductosConsu.Items.Refresh();
        }

        private void Btn_blanca_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();
            lboxProductosConsu.ItemsSource = pro.ListaFiltrada(3);
            lboxProductosConsu.Items.Refresh();
        }

        private void Btn_ropa_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new MisOfertas.Negocio.Producto();
            lboxProductosConsu.ItemsSource = pro.ListaFiltrada(4);
            lboxProductosConsu.Items.Refresh();
        }

        private void Btn_todosOfer_Click(object sender, RoutedEventArgs e)
        {

            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasConsu.ItemsSource = ofer.ListaOferta();
            lboxOfertasConsu.Items.Refresh();
        }

        private void Btn_alimentosOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasConsu.ItemsSource = ofer.ListaFiltrada(1);
            lboxOfertasConsu.Items.Refresh();
        }

        private void Btn_electronicaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasConsu.ItemsSource = ofer.ListaFiltrada(2);
            lboxOfertasConsu.Items.Refresh();
        }

        private void Btn_blancaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasConsu.ItemsSource = ofer.ListaFiltrada(3);
            lboxOfertasConsu.Items.Refresh();
        }

        private void Btn_ropaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasConsu.ItemsSource = ofer.ListaFiltrada(4);
            lboxOfertasConsu.Items.Refresh();
        }

        //private void TCPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //if (TCPrincipal.SelectedIndex == 1)
        //    //{
                
        //    //    Mensaje msj = new Mensaje();
        //    //    msj.Show();
                
        //    //}
            
        //}
    }
}
