using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using tf2_hud_editor_mvvm.Commands;
using tf2_hud_editor_mvvm.Models;

namespace tf2_hud_editor_mvvm.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private HUD _highlightedHud;
		public HUD HighlightedHUD
		{
			get => _highlightedHud;
			set
			{
				_highlightedHud = value;
				OnPropertyChanged(nameof(HighlightedHUD));

				// Dispose of previous MainWindowViewModel.Info here
				// Infinitely creating new viewmodels without disposing causes a memory leak

				if (_highlightedHud != null)
				{
					((MainViewModel)this.Page).Info = new HUDInfoViewModel(this, _highlightedHud);
				}
			}
		}

		private HUD _selectedHUD;
		public HUD SelectedHUD
		{
			get => _selectedHUD;
			set
			{
				_selectedHUD = value;

				// Dispose of previous MainWindowViewModel.Page here
				// Infinitely creating new viewmodels without disposing causes a memory leak
				this.Page = _selectedHUD == null ? new MainViewModel(this.HUDList, this) : new EditHUDViewModel(_selectedHUD);

				OnPropertyChanged(nameof(SelectedHUD));
			}
		}

		private ViewModelBase _page;
		public ViewModelBase Page
		{
			get => _page;
			private set
			{
				_page = value;
				OnPropertyChanged(nameof(Page));
			}
		}

		private SelectHUDCommand _selectHUDCommand;
		public CommandBase SelectHUDCommand => _selectHUDCommand;

		public IEnumerable<HUD> HUDList;

		public InstallHUDCommand InstallHUDCommand { get; }
		public ViewMainMenuCommand ViewMainMenuCommand { get; }

		public MainWindowViewModel(string selectedHUD, IEnumerable<HUD> hudList)
		{
			this.HUDList = hudList;

			_selectHUDCommand = new SelectHUDCommand(this);
			_page = selectedHUD != "" ? new EditHUDViewModel(hudList.First(h => h.Name == selectedHUD)) : new MainViewModel(this.HUDList, this);

			// Footer
			this.InstallHUDCommand = new InstallHUDCommand(this);
			this.ViewMainMenuCommand = new ViewMainMenuCommand(this);
		}
	}
}
