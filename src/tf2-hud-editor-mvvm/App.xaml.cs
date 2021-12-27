using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using tf2_hud_editor_mvvm.Models;
using tf2_hud_editor_mvvm.ViewModels;

namespace tf2_hud_editor_mvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var hudList = JsonSerializer.Deserialize<HUD[]>(File.OpenRead("JSON/HUDList.json"));

            MainWindow = new MainWindow
            { 
                DataContext = new MainWindowViewModel("", hudList)
            };

            MainWindow.Show();
        }
    }
}
