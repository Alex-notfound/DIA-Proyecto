
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Xml.Linq;

namespace NovelasAPP.Core.Capitulos
{
    public class RegistroCapitulos : ICollection<Capitulo>
    {
        public const string ArchivoXml = "capitulos.xml";
        public const string EtqCapitulos = "capitulos";
        public const string EtqCapitulo = "capitulo";
        public const string EtqSeccion = "seccion";
        public const string EtqNotas = "nota";
        public const string EtqTexto = "texto";
        public const string EtqTitulo = "titulo";

        public RegistroCapitulos()
        {
            Capitulos = new List<Capitulo>();
        }

        public RegistroCapitulos(IEnumerable<Capitulo> capitulos)
            : this()
        {
            this.Capitulos.AddRange(capitulos);
        }

        public void Add(Capitulo c)
        {
            Capitulos.Add(c);
        }


        public bool Remove(Capitulo c)
        {
            return Capitulos.Remove(c);
        }

        /// <summary>
        /// Elimina un viaje en la pos. i.
        /// </summary>
        /// <param name="i">La pos. a eliminar</param>
		public void RemoveAt(int i)
        {
            Capitulos.RemoveAt(i);
        }


        public void AddRange(IEnumerable<Capitulo> rs)
        {
            Capitulos.AddRange(rs);
        }

        public int Count
        {
            get { return Capitulos.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }


        public void Clear()
        {
            Capitulos.Clear();
        }

        public bool Contains(Capitulo c)
        {
            return Capitulos.Contains(c);
        }


        public void CopyTo(Capitulo[] c, int i)
        {
            Capitulos.CopyTo(c, i);
        }

        IEnumerator<Capitulo> IEnumerable<Capitulo>.GetEnumerator()
        {
            foreach (var c in Capitulos)
            {
                yield return c;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var c in Capitulos)
            {
                yield return c;
            }
        }

        public Capitulo GetCapitulo(string titulo)
        {
            foreach (var capitulo in Capitulos)
            {
                if (capitulo.Titulo == titulo) return capitulo;
            }
            return null;
        }

        public Capitulo this[int i]
        {
            get { return Capitulos[i]; }
            set { Capitulos[i] = value; }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Capitulo c in Capitulos)
            {
                toret.Append("Capitulo");
                toret.AppendLine(c.ToString());
            }

            return toret.ToString();
        }

        /// <summary>
        /// Guarda la lista de viajes como xml.
        /// </summary>
        public void GuardaXml()
        {
            GuardaXml(ArchivoXml);
        }

        /// <summary>
        /// Guarda la lista de viajes como XML.
        /// <param name="nf">El nombre del archivo.</param>
        /// </summary>
        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqCapitulos);

            foreach (Capitulo capitulo in Capitulos)
            {
                var secciones = capitulo.Secciones;
                foreach (var seccion in secciones)
                {
                    root.Add(new XElement(EtqCapitulo,
                                            new XAttribute(EtqTitulo, capitulo.Titulo),
                                            new XAttribute(EtqNotas, capitulo.Notas),
                                            new XElement(EtqSeccion,
                                                new XAttribute(EtqNotas, seccion.Notas),
                                                new XAttribute(EtqTexto, seccion.Texto)
                                            )
                                          )
                    );
                }
            }

            doc.Add(root);
            doc.Save(nf);
        }

        /// <summary>
        /// Recupera los viajes desde un archivo XML.
        /// </summary>
        /// <returns>Un <see cref="RegistroViajes"/> con los
        /// <see cref="Viaje"/>'s.</returns>
        /// <param name="f">El nombre del archivo.</param>
		public static RegistroCapitulos RecuperaXml(string f)
        {
            var toret = new RegistroCapitulos();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                    && doc.Root.Name == EtqCapitulos)
                {
                    var capitulos = doc.Root.Elements();

                    foreach (XElement capituloXml in capitulos)
                    {
                        Capitulo c = new Capitulo((string)capituloXml.Attribute(EtqTitulo), (string)capituloXml.Attribute(EtqNotas));

                        var seccionesXML = capituloXml.Elements();
                        foreach (var seccion in seccionesXML)
                        {
                            c.AddSeccion(
                                (string)seccion.Attribute(EtqNotas),
                                (string)seccion.Attribute(EtqTexto)
                            );
                        }
                        toret.Add(c);
                    }
                }
            }
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                toret.Clear();
            }

            return toret;
        }

        public List<Capitulo> Capitulos { get; set; }

        /// <summary>
        /// Crea un registro de viajes con la lista de viajes recuperada
        /// del archivo por defecto.
        /// </summary>
        /// <returns>Un <see cref="RegistroViajes"/>.</returns>
		public static RegistroCapitulos RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }

    }
}
