namespace NovelasAPP.Core.Capitulos
{
    public class Seccion
    {
        public Seccion(string notas, string texto)
        {
            this.notas = notas;
            this.texto = texto;
        }

        public string notas
        {
            get; set;
        }

        public string texto
        {
            get; set;
        }

        public override string ToString()
        {
            return texto + "\n";
        }
    }
}