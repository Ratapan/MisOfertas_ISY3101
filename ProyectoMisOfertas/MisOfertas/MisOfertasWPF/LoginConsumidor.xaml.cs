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
    /// Lógica de interacción para LoginConsumidor.xaml
    /// </summary>
    public partial class LoginConsumidor 
    {

        public LoginConsumidor()
        {
            InitializeComponent();
        }


        
        private async void Btn_Iniciarsesion_Click(object sender, RoutedEventArgs e)
        {

            
            MisOfertas.Negocio.Cliente cli = new MisOfertas.Negocio.Cliente();

            //llamando a metodo para validar datos
            if (cli.ValidacionCli(txt_usuario.Text, pass_contrasena.Password.ToString().Trim()))
            {
                
                Bienvenido saludo = new Bienvenido();

                cli.Rut = txt_usuario.Text;
                if (cli.Read())
                {
                    saludo.txt_nombre.Text = "Bienvenido " + cli.Nombres + " " + cli.Apellidos;
                }
                saludo.Show();
                saludo.Topmost = true;

                PerfilConsumidor pConsu = new PerfilConsumidor();
                //CambiarContrasena contra = new CambiarContrasena();
                this.Hide();
                App.Current.MainWindow.Hide(); //esto me permite cerrar la ventana main ya que con la intruccion hide() por si sola no lo logra.
                pConsu.Closed += (s, args) => App.Current.Shutdown(); //Detiene la app. //opci....this.close();//
                pConsu.Show();

                cli.Rut = txt_usuario.Text;


                if (cli.Read())
                {
                    pConsu.txt_rut.Text = cli.Rut;
                    pConsu.txt_nombres.Text = cli.Nombres;
                    pConsu.txt_apellidos.Text = cli.Apellidos;
                    pConsu.cb_sexo.SelectedIndex = cli.Idsexo;
                    pConsu.cb_ciudad.SelectedIndex = cli.Idciudad;
                    pConsu.dp_nacimiento.SelectedDate = cli.Nacimiento;
                    pConsu.txt_email.Text = cli.Email;
                    pConsu.txt_puntos.Text = cli.Puntos.ToString();
                    
                    
                }
            }
            else
            {
                
                await this.ShowMessageAsync("ERROR", "Usuario No Encontrado // Usuario o Contraseña Incorrecto");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginAministrador ladmin = new LoginAministrador();
            this.Hide();
            ladmin.Closed += (s, args) => this.Close();
            ladmin.Show();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegistroConsumidor Rconsu = new RegistroConsumidor();
            Rconsu.Show();
        }

    }
}
