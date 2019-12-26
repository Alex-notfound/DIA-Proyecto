using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Graficos.UI;
using Graficos.Core;
using WFrms = System.Windows.Forms;


namespace Graficos
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Capitulo capitulo = new Capitulo("Capitulo 1", "Hola buenas");
            Capitulo capitulo2 = new Capitulo("Capitulo 2", "Hola buenas");

            Seccion s1 = new Seccion("Notas 1", "Este es el texto. De ejemplo.");
            Seccion s2 = new Seccion("Notas 2", "Ejemplo 2.");
            Seccion s3 = new Seccion("Notas 2", "Ejemplo 3.");

            capitulo.secciones.Add(s1);
            capitulo2.secciones.Add(s2);
            capitulo2.secciones.Add(s3);

            List<Capitulo> capitulos = new List<Capitulo>();

            capitulos.Add(capitulo);
            capitulos.Add(capitulo2);

            WFrms.Application.Run(new MainWindowController(capitulos).View);
        }
    }
}
