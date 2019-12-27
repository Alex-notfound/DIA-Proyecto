using NovelasAPP.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NovelasAPP.UI.Controllers
{
    public class NotasController
    {
        public void showNotas(string notas, string titulo)
        {
            List<Label> lblNotas = new List<Label>();


                lblNotas.Add(ListaNotasView.BuildNotas(notas));

            ListaNotasView notasList = new ListaNotasView(titulo, lblNotas);

            DialogResult result = notasList.ShowDialog();

            if (result == DialogResult.OK)
            {
                notasList.Close();
            };
        }

}
}
