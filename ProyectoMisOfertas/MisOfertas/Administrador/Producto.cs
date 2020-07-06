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
    public class Producto
    {
        public int Idproducto { get; set; }
        public string Descripcion { get; set; }
        public int Idrubro { get; set; }
        public double Precio { get; set; }
        public int Totalstock { get; set; }
        public Byte[] Fotoproducto { get; set; }


        public Producto()
        {

            this.Init();
        }

        private void Init()
        {

            Idproducto = 0;
            Descripcion = string.Empty;
            Idrubro = 0;
            Precio = 0;
            Totalstock = 0;
            Fotoproducto = new Byte[10];

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

        public List<MisOfertas.Datos.Producto> ListaProductos()
        {
            

            MisOfertasEntities bd = new MisOfertasEntities();
            var ListaP = from d in bd.Producto
                         select d;

            

            return ListaP.ToList();
        }

        public List<MisOfertas.Datos.Producto> ListaFiltrada(int rubro)
        {


            MisOfertasEntities bd = new MisOfertasEntities();
            var filtro = from d in bd.Producto
                         where d.Idrubro == rubro
                         select d;



            return filtro.ToList();
        }

        //public List<MisOfertas.Datos.Producto> x()
        //{


        //    MisOfertasEntities bd = new MisOfertasEntities();
        //    var filtro = from a in bd.Producto
        //                 join b in bd.Oferta on a.Idproducto equals b.Idproducto
        //                 where a.Idproducto != b.Idproducto
        //                 select a;



        //    return filtro.ToList();
        //}


    }
}
