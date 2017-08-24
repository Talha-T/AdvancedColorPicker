using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using AdvancedColorPicker.Models;
using LoLDuvarKağıtları.Models;

namespace AdvancedColorPicker
{
    /// <summary>
    /// ColorList.xaml etkileşim mantığı
    /// </summary>
    public partial class ColorList : INotifyPropertyChanged
    {
        public ColorList()
        {
            InitializeComponent();
        }
        
        public Theme ParentTheme
        {
            get => (Theme)GetValue(ParentThemeProperty);
            set => SetValue(ParentThemeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Parent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentThemeProperty =
            DependencyProperty.Register("ParentTheme", typeof(Theme), typeof(ColorList));

        public ColorHistoryCollection Colors
        {
            get => (ColorHistoryCollection)GetValue(ColorsProperty);
            set => SetValue(ColorsProperty, value);
        }

        // Using a DependencyProperty as the backing store for Colors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorsProperty =
            DependencyProperty.Register("Colors", typeof(ColorHistoryCollection), typeof(ColorList));

        

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var sourceRect = (Rectangle)sender;
            var colorEntry = (ColorEntry)sourceRect.DataContext;
            Clipboard.SetText(colorEntry.Color.ToString());
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue("Hex code copied to the clipboard.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand RemoveColorFromThemeCommand => new RelayCommand(x =>
        {
            ParentTheme.ColorEntries.Remove((ColorEntry) x);
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue($"Removed {x} from theme.");
        });
    }
}
