using Avalonia.Controls.Platform;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactofing.Models.DataTypes.Newer_ones;
using WordTemplates_refactoring.Models;

namespace WordTemplates_refactoring.ViewModels
{
    public partial class AppendixDViewModel: ViewModelBase
    {
        public DAppndixOption options;
        AppendixDViewModel(DAppndixOption options)
        {
            this.options = options;
        }

        [RelayCommand]
        private void Show()
        {

        }

        [RelayCommand]
        private void setOptions()
        {
            
        }

    }
}
