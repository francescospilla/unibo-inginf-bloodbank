﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BloodBank.View.Views {
    /// <summary>
    /// Interaction logic for IndaginiView.xaml
    /// </summary>
    public partial class IndaginiView : UserControl {
        public IndaginiView() {
            InitializeComponent();

        }

        private void Grid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridTextColumn column = (DataGridTextColumn) e.Column;
            if (column != null)
                column.ElementStyle = Resources["WrappedTextBlockStyle"] as Style;
        }

        private void DataGrid_OnAddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            Console.WriteLine("aggiunto nuovo elemento, sarcazzoville: " + e.NewItem);
        }
    }
}