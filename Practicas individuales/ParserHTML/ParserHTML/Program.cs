using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserHTML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var form = new MainWindow();

            try
            {
                form.Show();
                Application.Run(form);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unexpected: " + exc.Message, "ParserHTML",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modeConsole()
        {
            var S1 = new Seccion("Je**su**c*r*i**s*t*o**", "");
            var S2 = new Seccion("Je***s*u**c*r*i**s*t*o**", "");
            var S3 = new Seccion("Jesu**cr*i***s*t***o**", "");
            var S4 = new Seccion("Jes\nus\nHola", "");

            var secciones = new List<Seccion>
            {
                S1,
                S2,
                S3,
                S4
            };

            var Cap1 = new Capitulo("Capitulo 1", secciones);
            var Cap2 = new Capitulo("Capitulo 2", secciones);
            var capitulos = new List<Capitulo>();
            capitulos.Add(Cap1);
            capitulos.Add(Cap2);

            ParserHTML.ParseLibro(capitulos);
        }
    }
}
