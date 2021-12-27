using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tf2_hud_editor_mvvm.Commands;
using tf2_hud_editor_mvvm.Models;

namespace tf2_hud_editor_mvvm.ViewModels
{
    public class HUDInfoViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;
        private readonly HUD _hud;

        public HUD HUD => _hud;

        public string Name => _hud.Name;
        public string Author => _hud.Author;
        public IEnumerable<string> Screenshots => _hud.Screenshots;

        public SelectHUDCommand SelectHUDCommand { get; }

        public HUDInfoViewModel(MainWindowViewModel mainWindowViewModel, HUD hud)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            _hud = hud;
            this.SelectHUDCommand = new SelectHUDCommand(mainWindowViewModel);
        }
    }
}
