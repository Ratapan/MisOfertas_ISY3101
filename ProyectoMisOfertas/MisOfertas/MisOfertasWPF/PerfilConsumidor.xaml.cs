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
using MahApps.Metro.Controls.Dialogs;
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

        }
        public string id;

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

        private async void Btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogResult Result = await this.ShowMessageAsync("CONFIRMACIÓN", "¿Seguro Que Desea Actualizar Los datos?", MessageDialogStyle.Affirmative);
            if (Result == MessageDialogResult.Affirmative)
            {
                Cliente cli = new Cliente();
                if (cli.UpdateData(txt_rut.Text, txt_nombres.Text, txt_apellidos.Text, cb_sexo.SelectedIndex, cb_ciudad.SelectedIndex,
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
    }
}
