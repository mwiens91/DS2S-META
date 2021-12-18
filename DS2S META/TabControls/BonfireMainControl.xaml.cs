﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DS2S_META
{
    /// <summary>
    /// Interaction logic for BonfireMainControl.xaml
    /// </summary>
    public partial class BonfireMainControl : METAControl
    {
        public BonfireMainControl()
        {
            InitializeComponent();
            cmbBonfirHub.ItemsSource = DS2SBonfireHub.All;
            cmbBonfirHub.SelectedIndex = -1;
        }

        internal override void UpdateCtrl() 
        {

        }

        internal override void EnableCtrls(bool enable) 
        {
            IsEnabled = enable;
        }
        internal override void ReloadCtrl()
        {
            cmbBonfirHub.SelectedIndex = 0;
        }
        private void UnlockBonfires_Click(object sender, RoutedEventArgs e)
        {
            Hook.UnlockBonfires();
        }

        private void cmbBonfirHub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Hook == null)
                return;

            spBonfires.Children.Clear();
            var bonfireHub = cmbBonfirHub.SelectedItem as DS2SBonfireHub;
            if (bonfireHub == null)
                return;

            foreach (var bonfire in bonfireHub.Bonfires)
            {
                var bonfireControl = new BonfireControl();
                Binding binding = new Binding("Value")
                {
                    Source = Hook,
                    Path = new PropertyPath(bonfire.Replace(" ", "").Replace("'", ""))
                };
                bonfireControl.nudBonfireLevel.SetBinding(Xceed.Wpf.Toolkit.IntegerUpDown.ValueProperty, binding);
                bonfireControl.nudBonfireLevel.Minimum = 0;
                bonfireControl.nudBonfireLevel.Maximum = 255;
                bonfireControl.BonfireName = bonfire;
                spBonfires.Children.Add(bonfireControl);
            }
        }
    }
}
