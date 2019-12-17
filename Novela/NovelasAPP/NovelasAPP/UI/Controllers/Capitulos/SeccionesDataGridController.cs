using System.Net.Mime;
using System.Runtime.Loader;
using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Controllers
{
    using NovelasAPP.Core.Capitulos;
    using NovelasAPP.Core.Personajes;
    using NovelasAPP.UI.Views;
    using System;
    
    public class SeccionesDataGridController
    {
        public SeccionesDataGridController(RegistroCapitulos rc, string cap)
        {
            this.rc = rc;
            
            Capitulo capitulo = rc.GetCapitulo(cap);
            this.View = new SeccionesDataGridView(rc, capitulo);
            
            this.View.dataGrid.CellDoubleClick += (sender, e) =>
                EditSeccion(rc, capitulo, e.RowIndex);

            this.View.dataGrid.UserDeletedRow += (sender, e) =>
                BorrarSeccion(rc, capitulo, e.Row.Cells[0].Value.ToString());
            
            this.View.ShowDialog();
            capitulo = rc.GetCapitulo(cap);
            //WFrms.MessageBox.Show(capitulo.ToString());
            

        }

        public SeccionesDataGridView View
        {
            get; private set;
        }
        

        public void Actualiza(Capitulo capitulo)
        {
            int i = 0;
            
            foreach (var seccion in capitulo.secciones)
            {
                //WFrms.MessageBox.Show(seccion.texto);
                this.View.dataGrid.Rows[i].Cells[0].Value = seccion.texto;
                this.View.dataGrid.Rows[i].Cells[1].Value = seccion.notas;
                i++;
            }

            this.rc = rc;
        }

        public void EditSeccion(RegistroCapitulos rc,Capitulo c,int row)
        {
            var seccion = this.View.dataGrid.Rows[row].Cells[0].Value.ToString(); 
            //new EditSeccionController(rc, c, seccion);
            EdicionView editView = new EdicionController(rc, new RegistroPersonajes().RecuperaXml(), c, c.recuperarSeccion(seccion), "Seccion " + (row+1)).edicionView;
            editView.Show();
            editView.FormClosed += (sender, args) => this.Actualiza(c); 
            /*this.Actualiza(c);*/
        }

        public void BorrarSeccion(RegistroCapitulos rc, Capitulo cap, string seccion)
        {
            cap.eliminarSeccion(seccion);
            this.Actualiza(cap);
        }
        
        
        public void Guardar()
        {
            rc.GuardaXml();
        }
        

        private RegistroCapitulos rc;
    }
}