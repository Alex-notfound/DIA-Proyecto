using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace CapitulosDIA.Core
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
            this.capitulos = new List<Capitulo>();
        }

        public RegistroCapitulos(IEnumerable<Capitulo> capitulos)
            : this()
        {
            this.capitulos.AddRange(capitulos);
        }

        public void Add(Capitulo c)
        {
            this.capitulos.Add(c);
        }


        public bool Remove(Capitulo c)
        {
            return this.capitulos.Remove(c);
        }

        public void AddSeccion(String titulo, String notas, String texto)
        {
            Capitulo c = this.GetCapitulo(titulo);
            c.addSeccion(notas, texto);
            //capitulos[capitulos.IndexOf(c)].addSeccion(notas,texto);
            //this.Actualiza(c);
        }
        public void Actualiza(Capitulo c)
        {
            capitulos.RemoveAll(x => x.titulo == c.titulo);
            capitulos.Add(c);
        }


		public void RemoveAt(int i)
        {
            this.capitulos.RemoveAt(i);
        }


        public void AddRange(IEnumerable<Capitulo> rs)
        {
            this.capitulos.AddRange(rs);
        }

        public int Count
        {
            get { return this.capitulos.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }


        public void Clear()
        {
            this.capitulos.Clear();
        }

        public bool Contains(Capitulo c)
        {
            return this.capitulos.Contains(c);
        }


        public void CopyTo(Capitulo[] c, int i)
        {
            this.capitulos.CopyTo(c, i);
        }

        IEnumerator<Capitulo> IEnumerable<Capitulo>.GetEnumerator()
        {
            foreach (var c in this.capitulos)
            {
                yield return c;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var c in this.capitulos)
            {
                yield return c;
            }
        }

        public Capitulo GetCapitulo(string titulo)
        {
            foreach (var capitulo in capitulos)
            {
                if (capitulo.titulo == titulo) return capitulo;
            }
            return null;
        }

        public Capitulo this[int i]
        {
            get { return this.capitulos[i]; }
            set { this.capitulos[i] = value; }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Capitulo c in this.capitulos)
            {
                toret.AppendLine(c.ToString());
            }

            return toret.ToString();
        }


        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }


        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqCapitulos);

            foreach (Capitulo capitulo in this.capitulos)
            {
                var secciones = capitulo.secciones;
                XElement cap = new XElement(EtqCapitulo, 
                    new XAttribute(EtqTitulo, capitulo.titulo),
                    new XAttribute(EtqNotas, capitulo.notas)
                );
                
                
                foreach (var seccion in secciones)
                {
                    cap.Add(new XElement(EtqSeccion,
                        new XAttribute(EtqNotas, seccion.notas),
                        new XAttribute(EtqTexto, seccion.texto)
                    ));

                }
                
                root.Add(cap);
            }

            doc.Add(root);
            doc.Save(nf);
        }


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
                        Capitulo c = new Capitulo((string) capituloXml.Attribute(EtqTitulo), (string) capituloXml.Attribute(EtqNotas));

                        var seccionesXML = capituloXml.Elements();
                        foreach (var seccion in seccionesXML)
                        {
                            c.addSeccion(
                                (string) seccion.Attribute(EtqNotas),
                                (string) seccion.Attribute(EtqTexto)
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

        public List<Capitulo> capitulos { get; set; }
        public static RegistroCapitulos RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }

    }
}