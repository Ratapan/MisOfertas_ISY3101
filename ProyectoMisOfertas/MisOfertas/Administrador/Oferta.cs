using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MisOfertas.Datos;

namespace MisOfertas.Negocio
{
    public class Oferta
    {
        public int Idoferta { get; set; }
        public int Idproducto { get; set; }
        public string Descripcion { get; set; }
        public double Porc_dscto { get; set; }
        public DateTime Fecha_desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public double Precio { get; set; }
        public double PrecioOferta { get; set; }
        public Byte[] Fotoproducto { get; set; }



        public Oferta()
        {

            this.Init();
        }


        private void Init()
        {
            Idoferta = 0;

            Idproducto = 0;
            Descripcion = string.Empty;
            Porc_dscto = 0;
            Fecha_desde = DateTime.Today;
            Fecha_Hasta = DateTime.Today;
            Precio = 0;
            PrecioOferta = 0;
            Fotoproducto = new Byte[10];



        }

        //public BitmapImage ObtenerImagen(byte[] codeFoto)
        //{
        //    Stream stream = new MemoryStream(codeFoto);

        //    BitmapImage image = new BitmapImage();
        //    stream.Position = 0;
        //    image.BeginInit();
        //    image.CacheOption = BitmapCacheOption.OnLoad;
        //    image.StreamSource = stream;
        //    image.EndInit();
        //    image.Freeze();

        //    return image;

        //}

        public bool Create()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            MisOfertas.Datos.Oferta ofer = new Datos.Oferta();

            try
            {
                CommonBC.Syncronize(this, ofer);
                bd.Oferta.Add(ofer);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bd.Oferta.Remove(ofer);
                return false;
            }


        }

        public bool validaNuevaOferta(int id)
        {
            MisOfertasEntities bd = new MisOfertasEntities();

            var result = from d in bd.Oferta
                         where d.Fecha_Hasta < DateTime.Today && d.Idproducto == id
                         select d;

            if (result.Count() < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<MisOfertas.Datos.Oferta> ListaOferta()
        {


            MisOfertasEntities bd = new MisOfertasEntities();
            var ListaP = from d in bd.Oferta
                         select d;



            return ListaP.ToList();
        }

        public List<MisOfertas.Datos.Oferta> ListaFiltrada(int rubro)
        {


            MisOfertasEntities bd = new MisOfertasEntities();
            var filtro = from a in bd.Oferta
                                join b in bd.Producto on a.Idproducto equals b.Idproducto
                                where b.Idrubro == rubro
                                select a;



            return filtro.ToList();
        }
    }
}
