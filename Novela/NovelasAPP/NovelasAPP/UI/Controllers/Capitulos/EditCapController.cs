using NovelasAPP.Core.Capitulos;
using NovelasAPP.UI.Views;
using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Controllers
{
    public class EditCapController
    {
        public EditCapController(RegistroCapitulos rc, string cap)
        {
            Capitulo c = rc.GetCapitulo(cap);
            this.View = new EditCapView(c);
            this.View.btnAddCap.Click +=
                (sender, e) => this.EditCap(rc,c);
            this.View.ShowDialog();
        }
        
        public EditCapView View
        {
            get; private set;
        }

        public void EditCap(RegistroCapitulos rc, Capitulo capituloPrevio)
        {
            
            rc.capitulos[rc.capitulos.IndexOf(capituloPrevio)].titulo = this.View.txtTitulo.Text;
            rc.capitulos[rc.capitulos.IndexOf(capituloPrevio)].notas = this.View.txtNotas.Text;
            this.View.Close();
        }
    }
}