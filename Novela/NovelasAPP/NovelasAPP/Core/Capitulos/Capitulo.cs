using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NovelasAPP.Core.Capitulos
{
    public class Capitulo
    {
        public Capitulo(string titulo, string notas)
        {
            this.Titulo = titulo;
            this.Notas = notas;
            Secciones = new List<Seccion>();
        }

        public string Titulo
        {
            get; set;
        }

        public string Notas
        {
            get; set;
        }

        public List<Seccion> Secciones
        {
            get; set;
        }

        public void AddSeccion(string notasSeccion, string textoSeccion)
        {
            Secciones.Add(new Seccion(notasSeccion, textoSeccion));
        }

        public string PrintSecciones()
        {
            StringBuilder toret = new StringBuilder();
            foreach (var seccion in Secciones)
            {
                toret.Append(seccion);
            }

            return toret.ToString();
        }

        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.Append(Titulo + '\n');
            toret.Append(Notas + '\n');
            toret.Append(PrintSecciones());
            return toret.ToString();
        }
    }
}