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
using System.IO;

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

            dp_fdesde.SelectedDate = DateTime.Today;

            MisOfertas.Negocio.Producto pro = new Producto();
            MisOfertas.Negocio.Oferta Ofer = new MisOfertas.Negocio.Oferta();

            lboxProductos.ItemsSource = pro.ListaProductos(); //productos para Ralizar dscunto
            lboxProductosAdmi.ItemsSource = pro.ListaProductos(); //productos
            lboxOfertasAdmi.ItemsSource = Ofer.ListaOferta(); //ofertas
        }
        public int idpro;
        public string descrip;
        public double Precio;
        public double Precioofer;
        public Byte[] Fotoproducto;

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

        public BitmapImage ObtenerImagen(byte[] codeFoto)
        {
            Stream stream = new MemoryStream(codeFoto);

            BitmapImage image = new BitmapImage();
            stream.Position = 0;
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
            image.Freeze();

            return image;

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
                   

                    MisOfertas.Negocio.Administrador admin = new MisOfertas.Negocio.Administrador()
                    {
                        Rut = txt_rut.Text,
                        Nombres = txt_nombres.Text,
                        Apellidos = txt_apellidos.Text,
                        Idsexo = cb_sexo.SelectedIndex,
                        Idtienda = cb_tienda.SelectedIndex,
                        Contrasena = txt_contrasena.Text.Trim()
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
                    

                    MisOfertas.Negocio.Encargado_Tienda encargado = new MisOfertas.Negocio.Encargado_Tienda()
                    {
                        Rut = txt_rut.Text,
                        Nombres = txt_nombres.Text,
                        Apellidos = txt_apellidos.Text,
                        Idsexo = cb_sexo.SelectedIndex,
                        Idtienda = cb_tienda.SelectedIndex,
                        Contrasena = txt_contrasena.Text.Trim()
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

            MisOfertas.Negocio.Encargado_Tienda encargado = new MisOfertas.Negocio.Encargado_Tienda()
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
                txt_contrasena.Text = encargado.Contrasena;
                txt_conf_contrasena.Text = encargado.Contrasena;

                //MessageBox.Show("Encargado de Tienda Encontrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                await this.ShowMessageAsync("AVISO", "Encargado de Tienda Encontrado!");
            }
            else
            {
                MisOfertas.Negocio.Administrador admin = new MisOfertas.Negocio.Administrador()
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
                    txt_contrasena.Text = admin.Contrasena;
                    txt_conf_contrasena.Text = admin.Contrasena;

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
                        

                        MisOfertas.Negocio.Administrador admin = new MisOfertas.Negocio.Administrador()
                        {
                            Rut = txt_rut.Text,
                            Nombres = txt_nombres.Text,
                            Apellidos = txt_apellidos.Text,
                            Idsexo = cb_sexo.SelectedIndex,
                            Idtienda = cb_tienda.SelectedIndex,
                            Contrasena = txt_contrasena.Text.Trim()
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
                        

                        MisOfertas.Negocio.Encargado_Tienda encargado = new MisOfertas.Negocio.Encargado_Tienda()
                        {
                            Rut = txt_rut.Text,
                            Nombres = txt_nombres.Text,
                            Apellidos = txt_apellidos.Text,
                            Idsexo = cb_sexo.SelectedIndex,
                            Idtienda = cb_tienda.SelectedIndex,
                            Contrasena = txt_contrasena.Text.Trim()
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
                MisOfertas.Negocio.Encargado_Tienda encargado = new MisOfertas.Negocio.Encargado_Tienda()
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
                    MisOfertas.Negocio.Administrador admin = new MisOfertas.Negocio.Administrador()
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
        
        

        private void LboxProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var Producto = (MisOfertas.Datos.Producto)item.SelectedItem;
            

            try
            {
                txt_NomProduc.Text = Producto.Descripcion;
                txt_ValorProduc.Text = "Valor: " + Producto.Precio.ToString();
                txt_Stockproduc.Text = "Total Stock: " + Producto.Totalstock.ToString();
                Img_Produc.Source = ObtenerImagen(Producto.Fotoproducto);
                idpro = Producto.Idproducto;
                Precio = Producto.Precio;
                Fotoproducto = Producto.Fotoproducto;
                descrip = Producto.Descripcion;

            }
            catch (Exception)
            {
                txt_NomProduc.Text = null;
                txt_ValorProduc.Text = null;
                txt_Stockproduc.Text = null;
                Img_Produc.Source = null;
                idpro = 0;
                Precio = 0;
                Fotoproducto = null;
                descrip = null;
            }
        }

        private void Cb_rubro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MisOfertas.Negocio.Producto pro = new MisOfertas.Negocio.Producto();

            if (cb_rubro.SelectedIndex == 0)
            {
                lboxProductos.ItemsSource = pro.ListaProductos();
                lboxProductos.Items.Refresh();
            }
            else
            {
                lboxProductos.ItemsSource = pro.ListaFiltrada(cb_rubro.SelectedIndex);
                lboxProductos.Items.Refresh();
            }


        }
        public void LimpiarOferta()
        {
            txt_NomProduc.Text = null;
            txt_ValorProduc.Text = null;
            txt_Stockproduc.Text = null;
            txt_descuento.Text = null;
            Img_Produc.Source = null;
            dp_fhasta.SelectedDate = null;
            idpro = 0;
            cb_rubro.SelectedIndex = 0;
            lboxProductos.SelectedItem = null;
        }


        private async void Btn_confirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_NomProduc.Text != string.Empty)
            {
                

                MisOfertas.Negocio.Oferta ofer = new MisOfertas.Negocio.Oferta()
                {


                    Idproducto = idpro,
                    Descripcion = descrip,
                    Porc_dscto = Convert.ToDouble(txt_descuento.Text),
                    Fecha_desde = DateTime.Today,
                    Fecha_Hasta = (DateTime)dp_fhasta.SelectedDate,
                    Precio = Precio,
                    PrecioOferta = Precio / 100 * (100 - Convert.ToDouble(txt_descuento.Text)),
                    Fotoproducto = Fotoproducto,
                };
                if (ofer.validaNuevaOferta(idpro))
                {

                    if (ofer.Create())
                    {
                        await this.ShowMessageAsync("AVISO", "La Oferta Fue Creada Exitosamente");
                        LimpiarOferta();
                    }
                    else
                    {
                        await this.ShowMessageAsync("ERROR", "La Oferta No Pude ser Creada");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("ERROR", "El Producto ya tiene una Oferta Vigente");
                }

            }
            
            else
            {
                await this.ShowMessageAsync("ERROR", "Debes Seleccionar un Elemento de la lista para Continuar");
            }


        }



        private void Btn_todos_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new Producto();
            lboxProductosAdmi.ItemsSource = pro.ListaProductos();
            lboxProductosAdmi.Items.Refresh();

        }

        private void Btn_alimentos_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new Producto();
            lboxProductosAdmi.ItemsSource = pro.ListaFiltrada(1);
            lboxProductosAdmi.Items.Refresh();
        }

        private void Btn_electronica_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new Producto();
            lboxProductosAdmi.ItemsSource = pro.ListaFiltrada(2);
            lboxProductosAdmi.Items.Refresh();

        }

        private void Btn_blanca_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new Producto();
            lboxProductosAdmi.ItemsSource = pro.ListaFiltrada(3);
            lboxProductosAdmi.Items.Refresh();

        }

        private void Btn_ropa_Click(object sender, RoutedEventArgs e)
        {
            Producto pro = new Producto();
            lboxProductosAdmi.ItemsSource = pro.ListaFiltrada(4);
            lboxProductosAdmi.Items.Refresh();
        }

        private void Btn_todosOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasAdmi.ItemsSource = ofer.ListaOferta();
            lboxOfertasAdmi.Items.Refresh();
        }

        private void Btn_alimentosOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasAdmi.ItemsSource = ofer.ListaFiltrada(1);
            lboxOfertasAdmi.Items.Refresh();
        }

        private void Btn_electronicaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasAdmi.ItemsSource = ofer.ListaFiltrada(2);
            lboxOfertasAdmi.Items.Refresh();

        }

        private void Btn_blancaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasAdmi.ItemsSource = ofer.ListaFiltrada(3);
            lboxOfertasAdmi.Items.Refresh();
        }

        private void Btn_ropaOfer_Click(object sender, RoutedEventArgs e)
        {
            Oferta ofer = new MisOfertas.Negocio.Oferta();
            lboxOfertasAdmi.ItemsSource = ofer.ListaFiltrada(4);
            lboxOfertasAdmi.Items.Refresh();
        }
    }
}
