using System.Linq;
using System.Windows.Controls;
using AdvancedColorPicker.Views;
using LoLDuvarKağıtları.Models;
using MenuItem = AdvancedColorPicker.Models.MenuItem;

namespace AdvancedColorPicker.ViewModels
{
    public class MainWindowViewModel
    {

        public MenuItem[] MenuItems { get; }

        public MainWindowViewModel()
        {
            MenuItems = new[]
            {
                new MenuItem("Color Picker", new ColorPickerView()),
                new MenuItem("Color History", new ColorHistoryView()),
                new MenuItem("My Themes", new ThemesView()) 
            };
        }

        public RelayCommand ClearColorHistoryCommand => new RelayCommand(x =>
        {
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue($"Cleared {ColorHistoryViewModel.Instance.ColorHistory.Count} entries.");
            ColorHistoryViewModel.Instance.ColorHistory.Clear();
        }, x => ColorHistoryViewModel.Instance.ColorHistory.Any());

        public RelayCommand ClearNonFavoritesCommand => new RelayCommand(x =>
        {
            int count = 0;
            ColorHistoryViewModel.Instance.ColorHistory.ToList()
                .ForEach(entry =>
                {
                    if (entry.IsFavorite) return;
                    ColorHistoryViewModel.Instance.ColorHistory.Remove(entry);
                    count++;
                });
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue($"Cleared {count} entries.");
        }, x => ColorHistoryViewModel.Instance.ColorHistory.Any());

    }
}