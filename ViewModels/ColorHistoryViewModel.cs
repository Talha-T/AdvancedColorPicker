using System;
using System.ComponentModel;
using System.Linq;
using AdvancedColorPicker.Models;
using AdvancedColorPicker.Properties;
using LoLDuvarKağıtları.Models;

namespace AdvancedColorPicker.ViewModels
{
    public class ColorHistoryViewModel : INotifyPropertyChanged
    {

        public ColorHistoryViewModel()
        {
            Instance = this;
            ColorHistory.CollectionChanged += delegate
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoColors"));
            };

        }
        
        public void AddColorToHistory(ColorEntry entry)
        {
            ColorHistory.Add(entry);
        }
        public static ColorHistoryViewModel Instance;

        public ColorHistoryCollection ColorHistory => Settings.Default.ColorHistory;

        public bool NoColors => !ColorHistory.Any();

        public RelayCommand DeleteCommand => new RelayCommand(x =>
        {
            ColorHistory.Remove((ColorEntry) x);
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue($"Removed {((ColorEntry)x).Name} from colors.");
        });

        public RelayCommand FavoriteCommand => new RelayCommand(x =>
        {
            var entry = (ColorEntry) x;
            entry.IsFavorite = !entry.IsFavorite;
        });

        public Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}