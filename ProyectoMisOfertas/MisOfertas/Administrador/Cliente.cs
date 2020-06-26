using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio
{
    public class Cliente
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Idsexo { get; set; }
        public int Idciudad { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Email { get; set; }
        public int Puntos { get; set; }
        public string Contrasena { get; set; }

        public Cliente()
        {

            this.Init();
        }


        private void Init()
        {
            Rut = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Idsexo = 0;
            Idciudad = 0;
            Nacimiento = DateTime.Today;
            Email = string.Empty;
            Puntos = 0;
            Contrasena = string.Empty;

        }

        public bool ValidacionCli(string usuario, string contrasena)
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            IEnumerable<Datos.Cliente> result = from d in bd.Cliente
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

        public bool UpdatePass(string id, string actual, string nueva)
        {
            MisOfertas.Datos.MisOfertasEntities bd = new MisOfertas.Datos.MisOfertasEntities();


            var result = (from d in bd.Cliente
                          where d.Rut == id && d.Contrasena == actual
                          select d);
            if (result.Count() > 0)
            {
                var result1 = (from d in bd.Cliente
                               where d.Rut == id && d.Contrasena == actual
                               select d).FirstOrDefault();

                result1.Contrasena = nueva;
                bd.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateData(string id, string nombres, string apellidos, int sexo, int ciudad, DateTime nacimiento, string email)
        {
            MisOfertas.Datos.MisOfertasEntities bd = new MisOfertas.Datos.MisOfertasEntities();

            var result = (from d in bd.Cliente
                          where d.Rut == id 
                          select d);
            if (result.Count() > 0)
            {
                var result1 = (from d in bd.Cliente
                               where d.Rut == id
                               select d).FirstOrDefault();

                result1.Nombres = nombres;
                result1.Apellidos = apellidos;
                result1.Idsexo = sexo;
                result1.Idciudad = ciudad;
                result1.Nacimiento = nacimiento;
                result1.Email = email;
                bd.SaveChanges();
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

            MisOfertas.Datos.Cliente cli = new Datos.Cliente();

            try
            {
                CommonBC.Syncronize(this, cli);
                bd.Cliente.Add(cli);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                bd.Cliente.Remove(cli);
                return false;
            }


        }

        public bool Read()
        {
            MisOfertas.Datos.MisOfertasEntities bd = new Datos.MisOfertasEntities();

            try
            {
                MisOfertas.Datos.Cliente cli = bd.Cliente.First(e => e.Rut == Rut);
                CommonBC.Syncronize(cli, this);
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
                MisOfertas.Datos.Cliente cli = bd.Cliente.First(e => e.Rut == Rut);
                bd.Cliente.Remove(cli);
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
