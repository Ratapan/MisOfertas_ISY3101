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
    /// Lógica de interacción para CambiarContrasena.xaml
    /// </summary>
    public partial class CambiarContrasena
    {
        public CambiarContrasena()
        {
            InitializeComponent();

        }
        public string id; //Rcupera rut de la ventana"perfilConsumidor"

        public void Limpiar()
        {
            pass_actual.Password = null;
            pass_nueva.Password = null;
            pass_repite.Password = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Btn_confi_Click(object sender, RoutedEventArgs e)
        {
          Cliente cli = new Cliente();

            if (pass_nueva.Password.Equals(pass_repite.Password))
            {
                if (cli.UpdatePass(id, pass_actual.Password.ToString().Trim(), pass_nueva.Password.ToString().Trim()))
                {
                    
                    MessageDialogResult Result = await this.ShowMessageAsync("AVISO", "Modificacion Realizada Correctamente.", MessageDialogStyle.Affirmative);
                    if (Result == MessageDialogResult.Affirmative)
                    {
                        this.Close();
                    }
                }
                else
                {
                    await this.ShowMessageAsync("ERROR", "La Contraseña Actual es Incorrecta.");
                    Limpiar();
                }
            }
            else
            {
                await this.ShowMessageAsync("ATENCIÓN", "La Confirmacion de contraseña es Distinta a La nueva Contraseña.");
                Limpiar();
            }




        }
    }
}
