using System;
using System.Collections.Generic;
using System.Text;

namespace Escritura.Core
{
    public class Personaje
    {
        public Personaje()
        {
            this.Notas = new List<string>();
        }

        public Personaje(string nombre)
        {
            this.Nombre = nombre;
            this.Notas = new List<string>();
        }

        public string Nombre
        {
            get; set;
        }

        public string Descripcion
        {
            get; set;
        }

        public List<string> Notas
        {
            get; set;
        }

    }
}
