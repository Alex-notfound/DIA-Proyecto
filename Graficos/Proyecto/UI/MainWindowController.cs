using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Graficos.UI;
using Graficos.Core;


namespace Graficos.UI
{
    using WFrms = System.Windows.Forms;

    public partial class MainWindowController : Form
    {
        public MainWindowController(List<Capitulo> ListaCapitulos) 
        {
            this.View = new MainWindowView();

            
            this.View.btnGenerarCapitulos.Click += (sender, args) => new GraficoWindow(ListaPorCapitulos(ListaCapitulos)).Show(); 
            this.View.btnGenerarCapitulos.Click += (sender, args) => new GraficoWindow(ListaPorCapitulosCar(ListaCapitulos)).Show();
            this.View.btnGenerarSecciones.Click += (sender, args) => new GraficoWindow(ListaPorSecciones(ListaCapitulos)).Show(); 
            this.View.btnGenerarSecciones.Click += (sender, args) => new GraficoWindow(ListaPorSeccionesCar(ListaCapitulos)).Show();
        }

        //Cuenta el numero de palabras por capitulo y lo añade a una lista
        public List<int> ListaPorCapitulos(List<Capitulo> capitulos)
        {
            List<int> palabrasPorCapitulo = new List<int>();

            foreach(Capitulo c in capitulos)
            {
                palabrasPorCapitulo.Add(PalabrasCapitulo(c.secciones));

            }

            return palabrasPorCapitulo;
        }

        //Cuenta el numero de palabras por capitulo y lo añade a una lista
        public List<int> ListaPorCapitulosCar(List<Capitulo> capitulos)
        {
            List<int> carPorCapitulo = new List<int>();

            foreach (Capitulo c in capitulos)
            {
                carPorCapitulo.Add(CaracteresCapitulo(c.secciones));

            }

            return carPorCapitulo;
        }

        //Cuenta el numero de palabras por seccion y lo añade a una lista
        public List<int> ListaPorSecciones(List<Capitulo> capitulos)
        {
            List<int> palabrasPorSeccion = new List<int>();

            foreach (Capitulo c in capitulos)
            {
                //Pendiente bucle recorra las secciones
                foreach (Seccion s in c.secciones)
                {
                    palabrasPorSeccion.Add(ContarPalabrasSeccion(s.texto));

                }
            }
            return palabrasPorSeccion;
        }

        //Cuenta el numero de caracteres por seccion y lo añade a una lista
        public List<int> ListaPorSeccionesCar(List<Capitulo> capitulos)
        {
            List<int> carPorSeccion = new List<int>();

            foreach (Capitulo c in capitulos)
            {
                //Pendiente bucle recorra las secciones
                foreach (Seccion s in c.secciones)
                {
                    carPorSeccion.Add(ContarCaracteresSeccion(s.texto));

                }
            }
            return carPorSeccion;
        }

        //Cuenta el numero de palabras en el capitulo pasado
        public int PalabrasCapitulo(List<Seccion> capitulo)
        {
            int palabrasTotales = 0;

            foreach(Seccion s in capitulo)
            {
                palabrasTotales += ContarPalabrasSeccion(s.texto);
            }

            return palabrasTotales;
        }

        //Cuenta el numero de caracteres en el capitulo pasado
        public int CaracteresCapitulo(List<Seccion> capitulo)
        {
            int caracteresTotales = 0;

            foreach (Seccion s in capitulo)
            {
                caracteresTotales += ContarCaracteresSeccion(s.texto);
            }

            return caracteresTotales;
        }

        //Cuenta el numero de palabras en la seccion pasada
        public int ContarPalabrasSeccion(string seccion)
        {
            int numPalabras = 0;

            for(int i = 0; i < seccion.Length; i++)
            {
                if (seccion[i] == ' ' || seccion[i] == '.' || seccion[i] == '\n')
                {
                    numPalabras++;
                }
            }

            return numPalabras;
        }

        //Cuenta el numero de caracteres en la seccion pasada
        public int ContarCaracteresSeccion(string seccion)
        {
            int numPalabras = 0;
            int numCaracteres;

            for (int i = 0; i < seccion.Length; i++)
            {
                if (seccion[i] == ' ' || seccion[i] == '.' || seccion[i] == '\n')
                {
                    numPalabras++;
                }
            }

            numCaracteres = seccion.Length - numPalabras;

            return numCaracteres;
        }


        List<Capitulo> ListaCapitulos
        {
            get;
        }

        public MainWindowView View
        {
            get; private set;
        }
    }
}
