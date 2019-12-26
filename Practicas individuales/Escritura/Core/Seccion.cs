using System;
using System.Collections.Generic;
using System.Text;

namespace Escritura.Core
{
    public class Seccion
    {
        public Seccion()
        {
            this.Notas = new List<string>();
        }

        public Seccion(string contenido)
        {
            this.Notas = new List<string>();
            this.Contenido = contenido;
        }

        public string Contenido
        {
            get; set;
        }

        public List<String> Notas
        {
            get; set;
        }
    }
}
