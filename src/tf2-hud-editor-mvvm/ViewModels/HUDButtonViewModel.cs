using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tf2_hud_editor_mvvm.Models;

namespace tf2_hud_editor_mvvm.ViewModels
{
    public class HUDButtonViewModel
    {
        public HUD Hud { get; }

        public string Name => Hud.Name;
        public string Description => Hud.Description;  
        public  string Thumbnail => Hud.Thumbnail;

        public int Column { get; }
        public int Row { get; }

        public HUDButtonViewModel(HUD hud, int column, int row)
        {
            Hud = hud;
            Column = column;
            Column = row;
        }
    }
}
