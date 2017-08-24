using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using AdvancedColorPicker.Models;
using MaterialDesignThemes.Wpf;

namespace AdvancedColorPicker.Views
{
    /// <summary>
    /// ThemesView.xaml etkileşim mantığı
    /// </summary>
    public partial class ThemesView
    {
        public ThemesView()
        {
            InitializeComponent();
        }

        private void ItemTemplate_Loaded(object sender, RoutedEventArgs e)
        {
            var icon = (PackIcon)sender;
            /*var entry = (ColorEntry)icon.DataContext;
            if (entry.IsFavorite)
            {
                icon.Foreground = new SolidColorBrush(Colors.Gold);
                icon.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }*/

        }
    }
}
