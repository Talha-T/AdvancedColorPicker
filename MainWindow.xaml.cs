using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using AdvancedColorPicker.Models;
using AdvancedColorPicker.Properties;
using AdvancedColorPicker.ViewModels;

namespace AdvancedColorPicker
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow
    {

        public static MainWindow Instance;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Instance = this;
            if (Settings.Default.ColorHistory == null)
                Settings.Default.ColorHistory = new ColorHistoryCollection();
            if (Settings.Default.Themes == null)
                Settings.Default.Themes =
                    new ThemeCollection();
            
            Closing += delegate
            {
                Settings.Default.Save();
            };

        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }
    }
}
