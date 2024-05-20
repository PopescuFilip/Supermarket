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

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for CreateSupplierView.xaml
    /// </summary>
    public partial class CreateSupplierView : UserControl
    {
        public CreateSupplierView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((TextBox)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}