using Escritura.Core;
using Escritura.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritura
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Datos de prueba
            List<Capitulo> listaCapitulos = new List<Capitulo>();
            List<Personaje> listaPersonajes = new List<Personaje>();

            List<string> notas = new List<string>();

            notas.Add("Esto es una nota de prueba 1");
            notas.Add("Esto es una nota de prueba 2");
            notas.Add("Esto es una nota de prueba 3");

            Seccion sec1 = new Seccion("Este es el contenido 1 de prueba para una seccion.");
            Seccion sec2 = new Seccion("Este es el contenido 2 de prueba para una seccion.");
            Seccion sec3 = new Seccion("Este es el contenido 3 de prueba para una seccion.");


            List<Seccion> secciones = new List<Seccion>();

            secciones.Add(sec1);
            secciones.Add(sec2);
            secciones.Add(sec3);

            Capitulo cap1 = new Capitulo("Capitulo 1");
            Capitulo cap2 = new Capitulo("Capitulo 2");
            Capitulo cap3 = new Capitulo("Capitulo 3");

            Personaje pej1 = new Personaje("Personaje 1");
            Personaje pej2 = new Personaje("Personaje 2");
            Personaje pej3 = new Personaje("Personaje 3");

            cap1.Secciones = secciones;
            cap1.Notas = notas;

            sec2.Notas = notas;
            sec3.Notas = notas;
            cap2.Secciones = secciones;

            cap3.Secciones = secciones;
            cap3.Notas = notas;

            listaCapitulos.Add(cap1);
            listaCapitulos.Add(cap2);
            listaCapitulos.Add(cap3);

            pej1.Notas = notas;

            pej2.Descripcion = "Esto es la descripcion del personaje 2";

            pej3.Notas = notas;
            pej3.Descripcion = "Esto es la descripcion del personaje 3";

            listaPersonajes.Add(pej1);
            listaPersonajes.Add(pej2);
            listaPersonajes.Add(pej3);

            Application.Run(new AuxiliarController(listaCapitulos, listaPersonajes, cap1).vistaAuxiliar);
        }
    }
}
