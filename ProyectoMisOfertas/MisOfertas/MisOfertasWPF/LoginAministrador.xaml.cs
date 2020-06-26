﻿using MahApps.Metro.Controls.Dialogs;
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

namespace MisOfertasWPF
{
    /// <summary>
    /// Lógica de interacción para LoginAministrador.xaml
    /// </summary>
    public partial class LoginAministrador
    {
        public LoginAministrador()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Btn_Iniciarsesion_Click(object sender, RoutedEventArgs e)
        {
            //encriptacion de la contraseña para poder compararla con la que esta en la BBDD
            string pass = Encrypt.Encriptar(pass_contrasena.Password.ToString().Trim());

            MisOfertas.Negocio.Administrador admin = new MisOfertas.Negocio.Administrador();

            //llamando a metodo para validar datos
            if (admin.ValidacionAdmin(txt_usuario.Text, pass))
            {
                //MessageBox.Show("Usuario Existe", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                Bienvenido saludo = new Bienvenido();

                admin.Rut = txt_usuario.Text;
                if (admin.Read())
                {
                    saludo.txt_nombre.Text = "Bienvenido " + admin.Nombres + " " + admin.Apellidos;
                }

                saludo.Show();
                saludo.Topmost = true;

                PerfilAdministrador pAdmin = new PerfilAdministrador();
                this.Hide();
                App.Current.MainWindow.Hide(); //esto me permite cerrar la ventana main ya que con la intruccion hide() por si sola no lo logra.
                pAdmin.Closed += (s, args) => App.Current.Shutdown(); //Detiene la app. //opci....this.close();//
                pAdmin.Show();
            }
            else
            {
                //MessageBox.Show("Usuario No Existe", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                await this.ShowMessageAsync("ERROR", "Usuario No Encontrado // Usuario o Contraseña Incorrecto");
            }
        }
    }
}