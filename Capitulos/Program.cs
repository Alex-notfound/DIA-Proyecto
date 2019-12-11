using System;
using System.Security.Cryptography;
using ProyectoCapitulos.Core;
namespace ProyectoCapitulos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RegistroCapitulos r = new RegistroCapitulos();
            Capitulo c1 = new Capitulo("capitulo1", "nota1");
            c1.addSeccion("seccion1", "esta es la seccion1");
            r.Add(c1);
            
            Capitulo c2 = new Capitulo("capitulo2", "nota2");
            c1.addSeccion("seccion2", "esta es la seccion2");
            r.Add(c2);
            
            r.GuardaXml();
            
            //RegistroCapitulos r = RegistroCapitulos.RecuperaXml();
            //Console.WriteLine(r.ToString());
        }
    }
}