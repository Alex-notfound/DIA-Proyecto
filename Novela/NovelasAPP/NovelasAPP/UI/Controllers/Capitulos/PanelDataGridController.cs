using System.Net.Mime;
using System.Runtime.Loader;

using WFrms = System.Windows.Forms;

namespace NovelasAPP.UI.Controllers
{
    using NovelasAPP.Core.Capitulos;
    using NovelasAPP.UI.Graficos;
    using NovelasAPP.UI.Views;
    using System;
    
    public class PanelDataGridController
    {
        public PanelDataGridController()
        {
            rc = RegistroCapitulos.RecuperaXml();
            this.View = new PanelDataGridView(rc);
            
            this.View.editBtn.Click += (sender, e) =>
                EditarCapitulo(rc, this.View.dataGrid.SelectedRows[0].Cells[0].Value.ToString());
            
            this.View.addBtn.Click += (sender, e) =>
                AddCapitulo(rc);

            //this.View.listBtn.Click += (sender, e) =>
            //    ListarCapitulos();

            this.View.listBtn.Click += (sender, e) =>
                new GraficosController(rc.capitulos).View.Show(); ;

            this.View.seccionBtn.Click += (sender, e) =>
                AddSeccion(rc, this.View.dataGrid.SelectedRows[0].Cells[0].Value.ToString());

            this.View.dataGrid.CellDoubleClick += (sender, e) =>
                AbrirSecciones(e.RowIndex);
            
            this.View.FormClosing += (sender, e) => this.Guardar();

        }

        public PanelDataGridView View
        {
            get; private set;
        }

        public void EditarCapitulo(RegistroCapitulos rc, string cap)
        {
            new EditCapController(rc, cap);
            Actualiza(rc);
        }
        
        public void AddCapitulo(RegistroCapitulos rc)
        {
            new AddCapController(rc);
            this.View.dataGrid.Rows.Add();
            Actualiza(rc);
        }
        
        public void AddSeccion(RegistroCapitulos rc, string capitulo)
        {
            new AddSeccionController(rc, capitulo);
            //this.View.dataGrid.Rows.Add();
            //Actualiza(rc);
        }

        public void ListarCapitulos()
        {
            WFrms.MessageBox.Show(rc.ToString());
        }

        public void Actualiza(RegistroCapitulos rc)
        {
            var caps = rc.capitulos;
            int i = 0;
            
            foreach (var cap in caps)
            {
                this.View.dataGrid.Rows[i].Cells[0].Value = cap.titulo;
                this.View.dataGrid.Rows[i].Cells[1].Value = cap.notas;
                i++;
            }

            this.rc = rc;
        }

        public void AbrirSecciones(int row)
        {
            //WFrms.MessageBox.Show("doble");
            new SeccionesDataGridController(rc, this.View.dataGrid.Rows[row].Cells[0].Value.ToString());
        }
        
        public void Guardar()
        {
            rc.GuardaXml();
        }

        public void AddCap(string a)
        {
            WFrms.MessageBox.Show(a);
        }

        private RegistroCapitulos rc;
    }
}