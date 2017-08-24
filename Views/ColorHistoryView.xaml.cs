using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using AdvancedColorPicker.Models;
using AdvancedColorPicker.ViewModels;
using MaterialDesignThemes.Wpf;

namespace AdvancedColorPicker.Views
{
    /// <summary>
    /// ColorHistoryView.xaml etkileşim mantığı
    /// </summary>
    public partial class ColorHistoryView
    {
        public ColorHistoryView()
        {
            InitializeComponent();
            DataContext = new ColorHistoryViewModel();
        }


        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var sourceRect = (Rectangle) sender; 
            var colorEntry = (ColorEntry)sourceRect.DataContext;
            Clipboard.SetText(colorEntry.Color.ToString());
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue("Hex code copied to the clipboard.");
        }

        private void Favorite_Click(object sender, MouseButtonEventArgs e)
        {
            var btn = (Button) sender;
            var icon = (PackIcon) btn.Content;
            var fore = icon.Foreground;
            var stroke = icon.BorderBrush;
            icon.Foreground = stroke;
            icon.BorderBrush = fore;
            var isStarred = Equals(Foreground, new SolidColorBrush(Colors.Gold));
        }

        private void ItemTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            var icon = (PackIcon) sender;
            var entry = (ColorEntry)icon.DataContext;
            if (entry.IsFavorite)
            {
                icon.Foreground = new SolidColorBrush(Colors.Gold);
                icon.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }

        }
    }
}
