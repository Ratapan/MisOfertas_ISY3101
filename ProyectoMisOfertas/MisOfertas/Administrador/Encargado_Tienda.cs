using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio
{
    public class Encargado_Tienda
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Idsexo { get; set; }
        public int Idtienda { get; set; }
        public string Contrasena { get; set; }


        public Encargado_Tienda()
        {

            this.Init();
        }


        private void Init()
        {
            Rut = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Idsexo = 0;
            Idtienda = 0;
            Contrasena = string.Empty;

        }

        public bool Create()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            MisOfertas.Datos.Encargado_Tienda encargado = new Datos.Encargado_Tienda();

            try
            {
                CommonBC.Syncronize(this, encargado);
                bd.Encargado_Tienda.Add(encargado);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bd.Encargado_Tienda.Remove(encargado);
                return false;
            }
        }

        public bool Read()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            try
            {
                MisOfertas.Datos.Encargado_Tienda encargado = bd.Encargado_Tienda.First(e => e.Rut == Rut);
                CommonBC.Syncronize(encargado, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            try
            {
                MisOfertas.Datos.Encargado_Tienda encargado = bd.Encargado_Tienda.First(e => e.Rut == Rut);
                CommonBC.Syncronize(this, encargado);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            try
            {
                MisOfertas.Datos.Encargado_Tienda encargado = bd.Encargado_Tienda.First(e => e.Rut == Rut);
                bd.Encargado_Tienda.Remove(encargado);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }


}
