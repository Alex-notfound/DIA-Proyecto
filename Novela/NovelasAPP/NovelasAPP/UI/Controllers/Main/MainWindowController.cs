﻿using NovelasAPP.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovelasAPP.UI.Controllers
{
    class MainWindowController
    {
        public MainWindowController()
        {
            this.Build();
        }

        void Build()
        {
            MainView = new MainWindowView();
            MainView.BtnPersonajes.Click += (sender, args) =>
            {
                this.BuildPersonajes(new PersonajesController());
                MainView.Hide();
            };
            MainView.BtnCapitulos.Click += (sender, args) =>
            {
                this.BuildCapitulos(new PanelDataGridController());
                MainView.Hide();
            };
        }

        void BuildCapitulos(PanelDataGridController pdg)
        {
            PanelDataGridView view = pdg.View;
            view.Show();
            view.FormClosed += (sender, args) => MainView.Show();
        }

        void BuildPersonajes(PersonajesController pj)
        {
            PersonajesView view = pj.View;
            view.Show();
            view.FormClosed += (sender, args) => MainView.Show();
        }

        public MainWindowView MainView
        {
            get; set;
        }
    }

}
