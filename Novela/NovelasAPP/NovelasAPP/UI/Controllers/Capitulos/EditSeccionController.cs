using NovelasAPP.Core.Capitulos;
using NovelasAPP.UI.Views;
using System.Windows.Forms;
using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Controllers
{
    public class EditSeccionController
    {
        public EditSeccionController(RegistroCapitulos rc, Capitulo cap, string seccion)
        {
            this.View = new EditSeccionView(cap,seccion);
            //this.View.btnEditSec.Click +=
            //    (sender, e) => this.EditSeccion(rc,cap,seccion);
            //this.View.ShowDialog();

            this.View.btnEditSec.Click += (sender, args) =>
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los cambios?", "Advertencia", MessageBoxButtons.YesNoCancel);
                //new EdicionController(rc.capitulos, null,cap, new Seccion("", seccion)).edicionView.Show();
            };
            this.View.ShowDialog();
        }
        
        public EditSeccionView View
        {
            get; private set;
        }

        public void EditSeccion(RegistroCapitulos rc, Capitulo capitulo, string seccion)
        {
            
            rc.capitulos[rc.capitulos.IndexOf(capitulo)].editarSeccion(seccion, this.View.txtTitulo.Text,
                this.View.txtNotas.Text);
            this.View.Close();
        }
        
    }
}