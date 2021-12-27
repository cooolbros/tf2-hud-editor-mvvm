using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace tf2_hud_editor_mvvm.Models
{
    public class HUD
    {
         public string Name { get; init; }
         public string Author { get; init; }
         public string Description { get; init; } 
         public string Thumbnail { get; init; }
         public string[] Screenshots { get; init; }

         public Grid GetControls()
         {
            Grid g = new Grid();

            StackPanel sp = new StackPanel();
            sp.HorizontalAlignment = HorizontalAlignment.Center;
            sp.VerticalAlignment = VerticalAlignment.Center;

            Label title = new Label();
            title.Content = $"You are editing {this.Name}";
            title.FontSize = 50;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            sp.Children.Add(title);

            Label description = new Label();
            description.Content = $"This view was generated in Models/HUD.cs";
            description.FontSize = 32;
            description.HorizontalAlignment = HorizontalAlignment.Center;
            sp.Children.Add(description);

            g.Children.Add(sp);
            
            return g;
         }

         public void InstallHUD()
         {
            MessageBox.Show($"Installed {this.Name}\r\n\r\nThis method is HUD.InstallHUD() in Models/HUD.cs");
         }
    }
}
