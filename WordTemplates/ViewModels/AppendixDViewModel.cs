using Avalonia.Controls.Platform;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring.Models;

namespace WordTemplates_refactoring.ViewModels
{
    public partial class AppendixDViewModel: ViewModelBase
    {
        public int? variant;
        AppendixDViewModel(int? variant)
        {
            this.variant = variant;
        }

        [RelayCommand]
        private void Show()
        {

        }
 

    }
}
