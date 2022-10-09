﻿using DS2S_META.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Primitives;

namespace DS2S_META.ViewModels.Commands
{
    public class SetWeaponCommand : ICommand
    {
        private DmgCalcViewModel _dcvm;
        public DmgCalcViewModel DCVM
        {
            get => _dcvm;
            private set => _dcvm = value;
        }
        public SetWeaponCommand(DmgCalcViewModel dcvm)
        {
            _dcvm = dcvm;
        }
        
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        // Do the actual stuff?
        public void Execute(object? parameter)
        {

            ////var inf = cmbInfusion.SelectedItem as DS2SInfusion;
            ////if (item == null) return;
            //var inf = DS2SInfusion.Infusions[0]; // todo

            var upgr = DCVM.UpgradeVal;
            DCVM.UpgradeVal = 3;

            DCVM.WepStore = ParamMan.GetWeaponFromID(DCVM.SelectedItem?.itemID);
            int debug = 1;
        }
    }
}
