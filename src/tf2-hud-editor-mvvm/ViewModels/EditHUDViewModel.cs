using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using tf2_hud_editor_mvvm.Models;

namespace tf2_hud_editor_mvvm.ViewModels
{
    public class EditHUDViewModel : ViewModelBase
    {
        public HUD HUD { get; }
        public Grid Content => HUD.GetControls();

        public EditHUDViewModel(HUD hud)
        {
            HUD = hud;
        }
    }
}
