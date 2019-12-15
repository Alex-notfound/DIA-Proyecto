using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NovelasAPP.Core.Personajes
{
    class RegistroPersonajes
    {

        public const string ArchivoXml = "personajes.xml";
        public const string EtqPersonajes = "personajes";
        public const string EtqPersonaje = "personaje";
        public const string EtqNombre = "nombre";
        public const string EtqDescripcion = "descripcion";


        public RegistroPersonajes()
        {

            this.Personajes = new List<Personaje>();

        }

        public List<Personaje> Personajes
        {
            get; private set;
        }

        public void addPersonaje(Personaje per)
        {
            Personajes.Add(per);
        }

        public int countPersonajes()
        {
            return Personajes.Count();
        }

        public void delete(string nom)
        {
            Personajes.RemoveAll(per => nom.Equals(per.Nombre));
        }


        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            
            foreach(Personaje per in Personajes)
            {
                toret.Append(per.ToString());
                toret.Append("\n");
            }
            return toret.ToString();
        }


        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }



        public void GuardaXml(string nf)
        {

            RegistroPersonajes registro = RecuperaXml();

            var doc = new XDocument();
            var root = new XElement(EtqPersonajes);


            foreach (Personaje per in this.Personajes)
            {
                root.Add(
            new XElement(EtqPersonaje,
                    new XAttribute(EtqNombre, per.Nombre),
                    new XAttribute(EtqDescripcion, per.Descripcion)));
            }

            doc.Add(root);
            doc.Save(nf);
        }

        public RegistroPersonajes RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }



        public static RegistroPersonajes RecuperaXml(string f)
        {

            var toret = new RegistroPersonajes();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqPersonajes) { 
                    var pers = doc.Root.Elements(EtqPersonaje);

                    foreach (XElement personajexml in pers)
                    {
                        toret.addPersonaje(new Personaje(
                            (string)personajexml.Attribute(EtqNombre),
                            (string)personajexml.Attribute(EtqDescripcion)));
                        }
                    }

                }
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                //toret.Clear();
            }


            return toret;

        }


        public void Clear()
        {

            this.Personajes.Clear();

            var doc = XDocument.Load(ArchivoXml);
            var pers = doc.Root.Elements(EtqPersonaje);

            foreach (XElement personajexml in pers)
            {
                personajexml.Remove();

            }

            GuardaXml();

        }


    }
}
