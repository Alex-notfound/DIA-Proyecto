using System;
using System.Collections.Generic;

namespace ParserHTML
{
    public class Capitulo
    {
        public Capitulo(string titulo, List<Seccion> secciones)
        {
            Titulo = titulo;
            Secciones = secciones;
        }

        public string Titulo { get; set; }
        public List<Seccion> Secciones { get; set; }
    }
}