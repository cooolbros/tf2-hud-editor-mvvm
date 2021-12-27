using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tf2_hud_editor_mvvm.ViewModels;

namespace tf2_hud_editor_mvvm.Commands
{
    public class ViewMainMenuCommand : CommandBase
    {
        MainWindowViewModel mainWindowViewModel;

        public ViewMainMenuCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            mainWindowViewModel.PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        private void MainWindowViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainWindowViewModel.SelectedHUD))
            {
                this.OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return mainWindowViewModel.SelectedHUD != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            this.mainWindowViewModel.SelectedHUD = null;
            this.mainWindowViewModel.HighlightedHUD = null;
        }
    }
}
