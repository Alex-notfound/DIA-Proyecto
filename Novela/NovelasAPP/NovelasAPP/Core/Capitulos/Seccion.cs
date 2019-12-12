namespace NovelasAPP.Core.Capitulos
{
    public class Seccion
    {
        public Seccion(string notas, string texto)
        {
            this.Notas = notas;
            this.Texto = texto;
        }

        public string Notas
        {
            get; set;
        }

        public string Texto
        {
            get; set;
        }

        public override string ToString()
        {
            return Texto + "\n";
        }
    }
}