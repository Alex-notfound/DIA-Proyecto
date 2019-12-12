using System;
using System.Collections.Generic;

namespace ParserHTML
{
    public static class ParserHTML
    {
        public static string CastToHTML(string texto)
        {
            Boolean abrirNegrita = true;
            Boolean abrirCursiva = true;
            Boolean abrirParrafo = true;
            Boolean lastEtiquetaWasNegrita = false;
            //Metodo suprimible al integrar
            string html = generateHeader();

            for (int i = 0; i < texto.Length; i++)
            {
                String caracter = texto.Substring(i, 1);
                if (abrirParrafo)
                {
                    html += "\r\n\t\t<p>";
                    abrirParrafo = false;
                }
                if (caracter.CompareTo("\n")==0){
                    html +="</p>";
                    abrirParrafo = true;
                    continue;
                }
                else if (caracter.CompareTo("*")==0)
                {
                    if (i+1<texto.Length && texto.Substring(i + 1, 1).CompareTo("*") == 0)
                    { 
                        i++;
                        if(i + 1 < texto.Length && texto.Substring(i + 1, 1).CompareTo("*") == 0 && lastEtiquetaWasNegrita)
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
            html += generateEnding();
            Console.WriteLine(html);
            return html;
        }

        private static string generateHeader()
        {
            return "<html>\r\n<head>\r\n</head>\r\n<body>\r\n\t<section>";
        }
        private static string generateEnding()
        {
            return "\r\n\t</section>\r\n</body>\r\n</html>";
        }

        internal static void ParseTextBox()
        {
            throw new NotImplementedException();
        }

        public static void ParseLibro(List<Capitulo> capitulos)
        {
            string html = "<html>\n<head>\n</head>\n<body>";
            foreach (Capitulo cap in capitulos){
                html += "\n\t<h1>" + cap.Titulo + "</h1>\n";
                foreach (Seccion sec in cap.Secciones)
                {
                    html += "\n\t<section>";
                    html += CastToHTML(sec.Texto);
                    html += "\n\t</section>";
                }
                html += "\n";
            }
            html += "</body>\n</html>";
            Console.WriteLine(html);
        }
    }
}
