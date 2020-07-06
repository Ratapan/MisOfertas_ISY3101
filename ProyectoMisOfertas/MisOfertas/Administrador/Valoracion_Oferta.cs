using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisOfertas.Datos;

namespace MisOfertas.Negocio
{
    public class Valoracion_Oferta
    {
        public Byte[] Fotooferta { get; set; }
        public int Idoferta { get; set; }
        public string Rut { get; set; }
        public int Idnotaoferta { get; set; }
        

        public Valoracion_Oferta()
        {

            this.Init();
        }

        private void Init()
        {
            Fotooferta = new Byte[10];
            Idoferta = 0;
            Rut = string.Empty;
            Idnotaoferta = 0;
        }

        public bool Create()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            MisOfertas.Datos.Valoracion_Oferta validar = new Datos.Valoracion_Oferta();

            try
            {
                CommonBC.Syncronize(this, validar);
                bd.Valoracion_Oferta.Add(validar);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bd.Valoracion_Oferta.Remove(validar);
                return false;
            }
        }

    }


}
