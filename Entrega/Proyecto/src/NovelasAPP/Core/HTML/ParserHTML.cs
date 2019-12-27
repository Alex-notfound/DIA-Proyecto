using Microsoft.Win32;
using NovelasAPP.Core.Capitulos;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NovelasAPP.Core.HTML
{
    public static class ParserHTML
    {
        public static string CastToHTML(string texto)
        {
            bool abrirNegrita = true;
            bool abrirCursiva = true;
            bool abrirParrafo = true;
            bool lastEtiquetaWasNegrita = false;
            //Metodo suprimible al integrar
            string html = GenerateHeader();

            for (int i = 0; i < texto.Length; i++)
            {
                string caracter = texto.Substring(i, 1);
                if (abrirParrafo)
                {
                    html += "\r\n\t\t<p>";
                    abrirParrafo = false;
                }
                if (caracter.CompareTo("\n") == 0)
                {
                    html += "</p>";
                    abrirParrafo = true;
                    continue;
                }
                else if (caracter.CompareTo("*") == 0)
                {
                    if (i + 1 < texto.Length && texto.Substring(i + 1, 1).CompareTo("*") == 0)
                    {
                        i++;
                        if (i + 1 < texto.Length && texto.Substring(i + 1, 1).CompareTo("*") == 0 && lastEtiquetaWasNegrita)
                        {
                            i++;
                            html += "</b>";
                            abrirNegrita = true;
                        }
                        if (abrirCursiva)
                        {
                            html += "<i>";
                            abrirCursiva = false;
                            lastEtiquetaWasNegrita = false;
                        }
                        else
                        {
                            html += "</i>";
                            abrirCursiva = true;
                        }
                    }
                    else
                    {
                        if (abrirNegrita)
                        {
                            html += "<b>";
                            abrirNegrita = false;
                            lastEtiquetaWasNegrita = true;
                        }
                        else
                        {
                            html += "</b>";
                            abrirNegrita = true;
                        }
                    }
                }
                else
                {
                    html += caracter;
                }
            }
            if (!abrirParrafo)
            {
                html += "</p>";
            }
            //Metodo suprimible al integrar
            html += GenerateEnding();
            Console.WriteLine(html);
            return html;
        }

        private static string GenerateHeader()
        {
            return "<html>\r\n<head>\r\n</head>\r\n<body>\r\n\t<section>";
        }
        private static string GenerateEnding()
        {
            return "\r\n\t</section>\r\n</body>\r\n</html>";
        }

        internal static void ParseTextBox()
        {
            throw new NotImplementedException();
        }

        public static void ParseLibro(List<Capitulo> capitulos)
        {
            var html = "<html>\r\n<head>\r\n</head>\r\n<body>";

            foreach (Capitulo cap in capitulos)
            {
                html += "\n\t<h1>" + cap.titulo + "</h1>\n";
                foreach (Seccion sec in cap.secciones)
                {
                    html += "\r\n\t<section>" + CastToHTML(sec.texto) + "\n\t</section>";
                }
                html += "\n";
            }
            html += "</body>\n</html>";
            
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("libroHTML.html")){
                writer.WriteLine(html);
            }

            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = @"libroHTML.html";
                process.Start();
            }

        }

    }
}
