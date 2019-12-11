using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoCapitulos.Core
{
    public class Capitulo
    {
        public Capitulo(string titulo, string notas)
        {
            this.titulo = titulo;
            this.notas = notas;
            this.secciones = new List<Seccion>();
        }

        public string titulo
        {
            get; set;
        }
        
        public string notas
        {
            get; set;
        }

        public List<Seccion> secciones
        {
            get; set;
        }

        public void addSeccion(string notasSeccion, string textoSeccion)
        {
            secciones.Add(new Seccion(notasSeccion, textoSeccion));
        }

        public string printSecciones()
        {
            StringBuilder toret = new StringBuilder();
            foreach (var seccion in secciones)
            {
                toret.Append(seccion);
            }

            return toret.ToString();
        }

        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.Append(this.titulo + '\n');
            toret.Append(this.notas + '\n');
            toret.Append(this.printSecciones());

            return toret.ToString();
        }
    }
}