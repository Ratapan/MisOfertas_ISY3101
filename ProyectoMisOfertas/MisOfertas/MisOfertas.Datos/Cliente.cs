//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MisOfertas.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Idsexo { get; set; }
        public int Idciudad { get; set; }
        public System.DateTime Nacimiento { get; set; }
        public string Email { get; set; }
        public int Puntos { get; set; }
        public string Contrasena { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        public virtual Sexo Sexo { get; set; }
    }
}
