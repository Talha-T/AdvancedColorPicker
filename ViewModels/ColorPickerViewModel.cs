using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AdvancedColorPicker.Models;
using LoLDuvarKağıtları.Models;
using Microsoft.Win32;

namespace AdvancedColorPicker.ViewModels
{
    public class ColorPickerViewModel : INotifyPropertyChanged
    {
        private float _zoom = 100;
        private Color _color;
        private bool _colorSelected;
        private bool _imageOpened = true;

        public RelayCommand PasteCommand => new RelayCommand(x => ((Image) x).Source = Clipboard.GetImage(), x => Clipboard.GetImage() != null);

        public RelayCommand OpenCommand => new RelayCommand(x =>
        {
            var d = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Multiselect = false
            };
            if (d.ShowDialog().GetValueOrDefault(false))
            {
                ((Image) x).Source = new BitmapImage(new Uri(d.FileName));
            }
            Zoom = 100;
            ImageNotOpened = false;
        });

        public RelayCommand AddToFavoritesCommand => new RelayCommand(x =>
        {
            try
            {
                var ind = ColorHistoryViewModel.Instance.ColorHistory.Select(e => e.Color).ToList().IndexOf((Color) x);
                var entry = ColorHistoryViewModel.Instance.ColorHistory[ind];
                if (!entry.IsFavorite)
                {
                    entry.IsFavorite = true;
                    MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue(
                        $"Added {entry.Color.ToString()} to favorite colors.");
                }
                else
                {
                    MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue(
                        $"{entry.Color} is already in favorites. But you are free to love that color more.");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue("Hey, did you remove the color from history? We are adding it back to history to mark as favorite.");
                ColorHistoryViewModel.Instance.AddColorToHistory(new ColorEntry((Color)x));
                AddToFavoritesCommand.Execute(x);
            }
        });

        public RelayCommand AddToThemesCommand => new RelayCommand(x =>
        {
            ThemesViewModel.Instance.AddColorToTheme((Theme) x, new ColorEntry(Color));
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue($"Added {Color} to theme.");
        }, x => x != null);

        public float Zoom
        {
            get => _zoom;
            set
            {
                if (value < 50f)
                    _zoom = 50f;
                else
                    _zoom = value > 1500f ? 1500f : value;
                RaisePropertyChanged()?.Invoke(new PropertyChangedEventArgs("Zoom"));
            }
        }


        public Color Color
        {
            get => _color;
            set => this.MutateVerbose(ref _color, value, RaisePropertyChanged());
        }

        public bool ColorSelected
        {
            get => _colorSelected;
            set => this.MutateVerbose(ref _colorSelected, value, RaisePropertyChanged());
        }

        public bool ImageNotOpened
        {
            get => _imageOpened;
            set => this.MutateVerbose(ref _imageOpened, value, RaisePropertyChanged());
        }


        public Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}