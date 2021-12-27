using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tf2_hud_editor_mvvm.Models;
using tf2_hud_editor_mvvm.ViewModels;

namespace tf2_hud_editor_mvvm.Commands
{
    public class InstallHUDCommand : CommandBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        public InstallHUDCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            mainWindowViewModel.PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        private void MainWindowViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainWindowViewModel.HighlightedHUD))
            {
                this.OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _mainWindowViewModel.HighlightedHUD != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            ((HUD)parameter).InstallHUD();
        }
    }
}
