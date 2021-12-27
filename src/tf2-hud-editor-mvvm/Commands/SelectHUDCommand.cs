using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tf2_hud_editor_mvvm.Models;
using tf2_hud_editor_mvvm.ViewModels;

namespace tf2_hud_editor_mvvm.Commands
{
    public class SelectHUDCommand : CommandBase
    {
        private MainWindowViewModel mainWindowViewModel;

        public SelectHUDCommand(MainWindowViewModel mainWindowViewModel)
        {
          this.mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            this.mainWindowViewModel.SelectedHUD = (HUD)parameter;
        }
    }
}
