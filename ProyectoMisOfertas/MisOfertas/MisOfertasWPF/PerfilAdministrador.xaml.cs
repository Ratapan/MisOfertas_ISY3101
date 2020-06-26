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
    /// Lógica de interacción para PerfilAdministrador.xaml
    /// </summary>
    public partial class PerfilAdministrador
    {
        public PerfilAdministrador()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txt_rut.Text = string.Empty;
            txt_nombres.Text = string.Empty;
            txt_apellidos.Text = string.Empty;
            cb_sexo.SelectedIndex = 0;
            cb_tienda.SelectedIndex = 0;
            cb_tipo.SelectedIndex = 0;
            txt_contrasena.Text = string.Empty;
            txt_conf_contrasena.Text = string.Empty;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_tipo.SelectedIndex == 1)
            {
                if (txt_contrasena.Text != txt_conf_contrasena.Text)
                {
                    //MessageBox.Show("La confirmacion de contraseña es distinta a la Nueva Contraseña");
                    await this.ShowMessageAsync("ERROR", "La confirmacion de contraseña es distinta a la Nueva Contraseña");
                }
                else
                {
                    string pass = Encrypt.Encriptar(txt_contrasena.Text.Trim());

                    Administrador admin = new Administrador()
                    {
                        Rut = txt_rut.Text,
                        Nombres = txt_nombres.Text,
                        Apellidos = txt_apellidos.Text,
                        Idsexo = cb_sexo.SelectedIndex,
                        Idtienda = cb_tienda.SelectedIndex,
                        Contrasena = pass
                    };

                    if (admin.Create())
                    {
                        //MessageBox.Show("Registrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        await this.ShowMessageAsync("AVISO", "El Usuario se Registro Correctamente");
                        Limpiar();
                    }
                    else
                    {
                        //MessageBox.Show("No Registrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        await this.ShowMessageAsync("AVISO", "El Usuario se Registro Correctamente");
                    }
                }
            }
            else if (cb_tipo.SelectedIndex == 2)
            {
                if (txt_contrasena.Text != txt_conf_contrasena.Text)
                {
                    //MessageBox.Show("La confirmacion de contraseña es distinta de Contraseña");
                    await this.ShowMessageAsync("ERROR", "La confirmacion de contraseña es distinta a la Nueva Contraseña");
                }
                else
                {
                    string pass = Encrypt.Encriptar(txt_contrasena.Text.Trim());

                    Encargado_Tienda encargado = new Encargado_Tienda()
                    {
                        Rut = txt_rut.Text,
                        Nombres = txt_nombres.Text,
                        Apellidos = txt_apellidos.Text,
                        Idsexo = cb_sexo.SelectedIndex,
                        Idtienda = cb_tienda.SelectedIndex,
                        Contrasena = pass
                    };

                    if (encargado.Create())
                    {
                        //MessageBox.Show("Registrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        await this.ShowMessageAsync("AVISO", "El Usuario se Registro Correctamente");
                        Limpiar();
                    }
                    else
                    {
                        //MessageBox.Show("No Registrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        await this.ShowMessageAsync("ERROR", "El Usuario No pudo Ser Registrado");

                    }
                }

            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Encargado_Tienda encargado = new Encargado_Tienda()
            {
                Rut = txt_rut.Text,
            };
            if (encargado.Read())
            {
                txt_rut.Text = encargado.Rut;
                txt_nombres.Text = encargado.Nombres;
                txt_apellidos.Text = encargado.Apellidos;
                cb_sexo.SelectedIndex = encargado.Idsexo;
                cb_tienda.SelectedIndex = encargado.Idtienda;
                cb_tipo.SelectedIndex = 2;
                txt_contrasena.Text = Encrypt.DesEncriptar(encargado.Contrasena);
                txt_conf_contrasena.Text = Encrypt.DesEncriptar(encargado.Contrasena);

                //MessageBox.Show("Encargado de Tienda Encontrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                await this.ShowMessageAsync("AVISO", "Encargado de Tienda Encontrado!");
            }
            else
            {
                Administrador admin = new Administrador()
                {
                    Rut = txt_rut.Text,
                };
                if (admin.Read())
                {
                    txt_rut.Text = admin.Rut;
                    txt_nombres.Text = admin.Nombres;
                    txt_apellidos.Text = admin.Apellidos;
                    cb_sexo.SelectedIndex = admin.Idsexo;
                    cb_tienda.SelectedIndex = admin.Idtienda;
                    cb_tipo.SelectedIndex = 1;
                    txt_contrasena.Text = Encrypt.DesEncriptar(admin.Contrasena);
                    txt_conf_contrasena.Text = Encrypt.DesEncriptar(admin.Contrasena);

                    //MessageBox.Show("Administrador Encontrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    await this.ShowMessageAsync("AVISO", "Administrador Encontrado!");
                }
                else
                {
                    //MessageBox.Show("Usuario No Encontrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    await this.ShowMessageAsync("AVISO", "Usuario No Encontrado!");
                    Limpiar();
                }
            }



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageDialogResult Result = await this.ShowMessageAsync("Confirmación", "¿Está Seguro que Desea Actualizar Este Usuario?", MessageDialogStyle.AffirmativeAndNegative);

            if (Result == MessageDialogResult.Affirmative)
            {
                if (cb_tipo.SelectedIndex == 1)
                {
                    if (txt_contrasena.Text != txt_conf_contrasena.Text)
                    {
                        //MessageBox.Show("La confirmacion de contraseña es distinta de la Nueva Contraseña");
                        await this.ShowMessageAsync("ERROR", "La confirmacion de contraseña es distinta de la Nueva Contraseña");

                    }
                    else
                    {
                        string pass = Encrypt.Encriptar(txt_contrasena.Text.Trim());

                        Administrador admin = new Administrador()
                        {
                            Rut = txt_rut.Text,
                            Nombres = txt_nombres.Text,
                            Apellidos = txt_apellidos.Text,
                            Idsexo = cb_sexo.SelectedIndex,
                            Idtienda = cb_tienda.SelectedIndex,
                            Contrasena = pass
                        };

                        if (admin.Update())
                        {
                            //MessageBox.Show("Actualizado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                            await this.ShowMessageAsync("AVISO", "El usuario Fue Actualizado Correctamente");
                            Limpiar();
                        }
                        else
                        {
                            //MessageBox.Show("No Actualizado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                            await this.ShowMessageAsync("ERROR", "El usuario No Pudo Ser Actualizado");
                        }
                    }
                }
                else if (cb_tipo.SelectedIndex == 2)
                {
                    if (txt_contrasena.Text != txt_conf_contrasena.Text)
                    {
                        //MessageBox.Show("La confirmacion de contraseña es distinta de Contraseña");
                        await this.ShowMessageAsync("ERROR", "La confirmacion de contraseña es distinta de la Nueva Contraseña");
                    }
                    else
                    {
                        string pass = Encrypt.Encriptar(txt_contrasena.Text.Trim());

                        Encargado_Tienda encargado = new Encargado_Tienda()
                        {
                            Rut = txt_rut.Text,
                            Nombres = txt_nombres.Text,
                            Apellidos = txt_apellidos.Text,
                            Idsexo = cb_sexo.SelectedIndex,
                            Idtienda = cb_tienda.SelectedIndex,
                            Contrasena = pass
                        };

                        if (encargado.Update())
                        {
                            //MessageBox.Show("Actualizado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                            await this.ShowMessageAsync("AVISO", "El usuario Fue Actualizado Correctamente");
                            Limpiar();
                        }
                        else
                        {
                            //MessageBox.Show("No Actualizado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                            await this.ShowMessageAsync("ERROR", "El usuario No Pudo Ser Actualizado");

                        }
                    }

                }

            }



        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageDialogResult Result = await this.ShowMessageAsync("Confirmación", "¿Está Seguro que Desea Eliminar Este Usuario?", MessageDialogStyle.AffirmativeAndNegative);

            if (Result == MessageDialogResult.Affirmative)
            {
                Encargado_Tienda encargado = new Encargado_Tienda()
                {
                    Rut = txt_rut.Text,
                };
                if (encargado.Delete())
                {
                    //MessageBox.Show("Eliminado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    await this.ShowMessageAsync("ASISO", "El Usuario Encargado de Tienda Fue Eliminado Correctamente");
                    Limpiar();
                }
                else
                {
                    Administrador admin = new Administrador()
                    {
                        Rut = txt_rut.Text,
                    };
                    if (admin.Delete())
                    {
                        //MessageBox.Show("Eliminado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        await this.ShowMessageAsync("ASISO", "El Usuario Administrador Fue Eliminado Correctamente");
                        Limpiar();
                    }
                    else
                    {
                        //MessageBox.Show("NO Eliminado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        await this.ShowMessageAsync("ERROR", "El Usuario No Pudo ser Eliminado");
                    }

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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
