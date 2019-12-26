using System;

namespace ParserHTML
{
    public class Seccion
    {
        public Seccion(string texto, string notas)
        {
            Texto = texto;
            Notas = notas;
        }

        public string Texto { get; set; }
        public string Notas { get; set; }

    }
}