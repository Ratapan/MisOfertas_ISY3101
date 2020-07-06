using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio
{
    public class Administrador
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Idsexo { get; set; }
        public int Idtienda { get; set; }
        public string Contrasena { get; set; }


        public Administrador()
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


        public bool ValidacionAdmin(string usuario,string contrasena)
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            IEnumerable<Datos.Administrador> result = from d in bd.Administrador
                         where d.Rut == usuario
                         && d.Contrasena == contrasena
                         select d;

            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Create()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            MisOfertas.Datos.Administrador admin = new Datos.Administrador();

            try
            {
                CommonBC.Syncronize(this, admin);
                bd.Administrador.Add(admin);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bd.Administrador.Remove(admin);
                return false;
            }
        }

        public bool Read()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            try
            {
                MisOfertas.Datos.Administrador admin = bd.Administrador.First(e => e.Rut == Rut);
                CommonBC.Syncronize(admin, this);
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
                MisOfertas.Datos.Administrador admin = bd.Administrador.First(e => e.Rut == Rut);
                CommonBC.Syncronize(this, admin);
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
                MisOfertas.Datos.Administrador admin = bd.Administrador.First(e => e.Rut == Rut);
                bd.Administrador.Remove(admin);
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

