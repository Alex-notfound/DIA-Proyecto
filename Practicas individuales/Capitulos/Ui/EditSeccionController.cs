using CapitulosDIA.Core;

using WFrms = System.Windows.Forms;

namespace CapitulosDIA
{
    public class EditSeccionController
    {
        public EditSeccionController(RegistroCapitulos rc, Capitulo cap, string seccion)
        {
            this.View = new EditSeccionView(cap,seccion);
            this.View.btnEditSec.Click +=
                (sender, e) => this.EditSeccion(rc,cap,seccion);
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