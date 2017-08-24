using System.ComponentModel;
using System.Linq;
using AdvancedColorPicker.Models;
using AdvancedColorPicker.Properties;
using LoLDuvarKağıtları.Models;

namespace AdvancedColorPicker.ViewModels
{
    public class ThemesViewModel : INotifyPropertyChanged
    {
        public ThemesViewModel()
        {
            Instance = this;
            Themes.CollectionChanged += delegate
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoThemes"));
            };
        }

        public void AddColorToTheme(Theme theme, ColorEntry entry)
        {
            Themes[Themes.IndexOf(theme)].ColorEntries.Add(entry);
        }

        public static ThemesViewModel Instance;

        public ThemeCollection Themes => Settings.Default.Themes;

        public RelayCommand DeleteCommand => new RelayCommand(x =>
        {
            Themes.Remove((Theme) x);
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue($"Removed {((Theme)x).Name} from themes.");
        });

        public RelayCommand NewThemeCommand => new RelayCommand(x =>
        {
            Themes.Add(new Theme());
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue("Created new theme.");
        });

        public RelayCommand ClearThemesCommand => new RelayCommand(x =>
        {
            var count = Themes.Count;
            Themes.Clear();
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue($"Cleared {count} themes");
        }, x => Themes.Any());

        public bool NoThemes => !Themes.Any();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}