using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tf2_hud_editor_mvvm.Models;
using tf2_hud_editor_mvvm.ViewModels;

namespace tf2_hud_editor_mvvm.Commands
{
    public class HighlightHUDCommand : CommandBase
    {
        MainWindowViewModel MainWindowViewModel;

        public HighlightHUDCommand(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            MainWindowViewModel.HighlightedHUD = (HUD)parameter;
        }
    }
}
