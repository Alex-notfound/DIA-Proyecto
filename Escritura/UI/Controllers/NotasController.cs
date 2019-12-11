using Escritura.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Escritura.UI.Controllers
{
    public class NotasController
    {
        public void showNotas(List<string> notas, string titulo)
        {
            List<Label> lblNotas = new List<Label>();


            int i = 1;
            foreach (string nota in notas)
            {
                lblNotas.Add(ListaNotasView.BuildNotas(i.ToString(), nota));
                i++;
            }

            ListaNotasView notasList = new ListaNotasView(titulo, lblNotas);

            DialogResult result = notasList.ShowDialog();

            if (result == DialogResult.OK)
            {
                notasList.Close();
            };
        }

}
}
