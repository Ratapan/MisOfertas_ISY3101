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
    /// Lógica de interacción para RegistroConsumidor.xaml
    /// </summary>
    public partial class RegistroConsumidor
    {
        public RegistroConsumidor()
        {
            InitializeComponent();
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
            pass_contrasena.Password = null;
            pass_confir_contrasena.Password = null;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            if (pass_contrasena.Password.ToString().Trim() != pass_confir_contrasena.Password.ToString().Trim())
            {
                MessageBox.Show("La confirmacion de contraseña es distinta de Contraseña");
            }
            else
            {

                

                Cliente cli = new Cliente()
                {
                    Rut = txt_rut.Text,
                    Nombres = txt_nombres.Text,
                    Apellidos = txt_apellidos.Text,
                    Idsexo = cb_sexo.SelectedIndex,
                    Idciudad = cb_ciudad.SelectedIndex,
                    Nacimiento = (DateTime)dp_nacimiento.SelectedDate,
                    Email = txt_email.Text,
                    Contrasena = pass_contrasena.Password.ToString().Trim()
                };

                if (cli.Create())
                {
                    
                    await this.ShowMessageAsync("AVISO", "Haz sido Registrado exitosamente");
                    Limpiar();
                    this.Close();

                }
                else
                {
                    await this.ShowMessageAsync("ERROR", "No se ha Podido Registrar tus Datos");
                }
            }




        }
    }
}
