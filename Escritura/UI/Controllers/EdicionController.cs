using Escritura.Core;
using Escritura.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Escritura.UI.Controllers
{
    class EdicionController
    {

        public EdicionController(List<Capitulo> listaCapitulos, List<Personaje> listaPersonajes, Capitulo capActual, Seccion seccionActual)
        {

            capitulos = listaCapitulos;
            personajes = listaPersonajes;

            edicionView = new EdicionView(capActual);


            edicionView.tbEdicion.Text = seccionActual.Contenido;

            edicionView.btnGuardar.Click += (sender, args) => save(seccionActual );

            edicionView.btnCursiva.Click += (sender, args) => cursiveText(edicionView.tbEdicion.SelectionStart, edicionView.tbEdicion.SelectionLength);
            edicionView.btnNegrita.Click += (sender, args) => boldText(edicionView.tbEdicion.SelectionStart, edicionView.tbEdicion.SelectionLength);

            edicionView.btnNuevoCap.Click += (sender, args) => 
            { 
                capitulos.Add(AddCapitulo());
                edicionView.refreshView(capActual);
                //edicionView.Close();
                //edicionView = new EdicionView(capActual);
                //edicionView.Show();
            };

            edicionView.btnNuevaSec.Click += (sender, args) =>
            {
                if (!edicionView.tbEdicion.Text.Equals(seccionActual.Contenido))
                {
                    DialogResult result = MessageBox.Show("¿Desea guardar los cambios?", "Advertencia", MessageBoxButtons.YesNoCancel);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            this.save(seccionActual);
                            addSeccion(capActual);
                            break;
                        case DialogResult.No:
                            addSeccion(capActual);
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
                else
                {
                    addSeccion(capActual);
                };
            };

            edicionView.lvCapitulos.ItemActivate += (sender, args) => showNotas(edicionView.lvCapitulos, edicionView.lvCapitulos.SelectedItems[0].Text, capitulos);
            edicionView.lvSecciones.ItemActivate += (sender, args) => showNotas(edicionView.lvSecciones, edicionView.lvSecciones.SelectedItems[0].Text, capActual.Secciones);
            edicionView.lvPersonajes.ItemActivate += (sender, args) => showNotas(edicionView.lvPersonajes, edicionView.lvPersonajes.SelectedItems[0].Text, personajes);

        }

        Capitulo AddCapitulo()
        {
            NuevoCapituloView nuevoCapView = new NuevoCapituloView();

            string titulo = null;

            DialogResult result = nuevoCapView.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                nuevoCapView.Close();
            }
            else if (result == DialogResult.OK)
            {
                titulo = nuevoCapView.titulo.Text;
                nuevoCapView.Close();
            };

            return new Capitulo(titulo);
        }

        void addSeccion(Capitulo capActual)
        {
            edicionView.Hide();
            EdicionView ed = new EdicionController(capitulos, personajes, capActual, new Seccion()).edicionView;

            ed.Show();

            ed.FormClosed += (sender, args) => 
            {
                if (ed.Text.Length != 0)
                {
                    capActual.Secciones.Add(new Seccion(ed.Text));
                }

                edicionView.Close();
            };

        }

        private void save(Seccion seccionActual)
        {
            seccionActual.Contenido = edicionView.tbEdicion.Text;
            MessageBox.Show("Guardado correctamente","Guardado", MessageBoxButtons.OK);
        }

        private void showNotas(ListView listView, string text, List<Capitulo> listaCapitulos)
        {
            Capitulo cap = listaCapitulos[listView.FindItemWithText(text).Index];

            new NotasController().showNotas(cap.Notas, cap.Titulo);
        }

        private void showNotas(ListView listView, string text, List<Personaje> listaPersonaje)
        {
            Personaje pej = listaPersonaje[listView.FindItemWithText(text).Index];

            new NotasController().showNotas(pej.Notas, pej.Nombre);
        }

        private void showNotas(ListView listView, string text, List<Seccion> listaSecciones)
        {
            Seccion sec = listaSecciones[listView.FindItemWithText(text).Index];

            new NotasController().showNotas(sec.Notas, "Seccion " + listView.FindItemWithText(text).Index + 1 );
        }

        private void cursiveText(int index, int len)
        {
            edicionView.tbEdicion.Focus();

            edicionView.tbEdicion.Text = edicionView.tbEdicion.Text.Insert(index, "*");
            edicionView.tbEdicion.Text = edicionView.tbEdicion.Text.Insert(index + len + 1, "*");

            edicionView.tbEdicion.SelectionStart = index;
            edicionView.tbEdicion.SelectionLength = len+2;

            edicionView.tbEdicion.Update();

        }

        private void boldText(int index, int len)
        {
            edicionView.tbEdicion.Focus();

            edicionView.tbEdicion.Text = edicionView.tbEdicion.Text.Insert(index, "**");
            edicionView.tbEdicion.Text = edicionView.tbEdicion.Text.Insert(index + len + 2, "**");

            edicionView.tbEdicion.SelectionStart = index;
            edicionView.tbEdicion.SelectionLength = len+4;

            edicionView.tbEdicion.Update();
        }

        public EdicionView edicionView
        {
            get; private set;
        }

        public static List<Capitulo> capitulos
        {
            get; set;
        }

        public static List<Personaje> personajes
        {
            get; set;
        }
    }

}
