using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tf2_hud_editor_mvvm.Commands;
using tf2_hud_editor_mvvm.Models;

namespace tf2_hud_editor_mvvm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MainWindowViewModel mainWindowViewModel;

        private ObservableCollection<HUDButtonViewModel> _hudList;
        public IEnumerable<HUDButtonViewModel> HUDList => _hudList;

        public ICommand HighlightHUDCommand { get; }

        private ViewModelBase info = new AppInfoViewModel();
        public ViewModelBase Info
        {
            get => info;
            set
            {
                info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        public MainViewModel(IEnumerable<HUD> hudList, MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            this._hudList = new ObservableCollection<HUDButtonViewModel>(hudList.Select((hud, i) => new HUDButtonViewModel(hud, i % 2, i / 2)));
            HighlightHUDCommand = new HighlightHUDCommand(this.mainWindowViewModel);
        }
    }
}
