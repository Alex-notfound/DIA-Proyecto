using System;
using System.Collections.Generic;
using System.Text;

namespace Escritura.Core
{
    public class Capitulo
    {

        public Capitulo(string titulo)
        {
            this.Titulo = titulo;
            this.Secciones = new List<Seccion>();
            this.Notas = new List<string>();
        }

        public string Titulo
        {
            get; private set;
        }

        public List<Seccion> Secciones
        {
            get; set;
        }

        public List<String> Notas
        {
            get; set;
        }
    }
}
