using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelasAPP.Core.Personajes
{
    class Personaje
    {
        public Personaje(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public string Nombre
        {
            get; private set;
        }

        public string Descripcion
        {
            get; private set;
        }

        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            toret.AppendLine("PERSONAJE");
            toret.AppendLine("Nombre: " + Nombre);
            toret.AppendLine("Descripcion: " + Descripcion);

            return toret.ToString();

        }
    }
}
