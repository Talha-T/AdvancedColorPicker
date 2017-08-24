using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AdvancedColorPicker.Models;
using AdvancedColorPicker.ViewModels;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;

namespace AdvancedColorPicker.Views
{
    /// <summary>
    /// ColorPickerView.xaml etkileşim mantığı
    /// </summary>
    public partial class ColorPickerView
    {
        public ColorPickerView()
        {
            InitializeComponent();
            ViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != "Zoom") return;
                var scale = (ScaleTransform)((TransformGroup)Image.RenderTransform).Children.First(tr => tr is ScaleTransform);
                scale.ScaleX = scale.ScaleY = ViewModel.Zoom / 100;
            };
        }

        private void Image_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var st = (ScaleTransform)((TransformGroup) Image.RenderTransform).Children.First(tr => tr is ScaleTransform);
            var zoom = e.Delta > 0 ? .2 : -.2;
            st.ScaleX += zoom;
            st.ScaleY += zoom;
            ViewModel.Zoom += (float) (zoom * 100);
            ViewModel.RaisePropertyChanged().Invoke(new PropertyChangedEventArgs("Zoom"));
        }

        private Point _start;
        private Point _origin;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image.CaptureMouse();
            var translateTransform = (TranslateTransform)((TransformGroup)Image.RenderTransform).Children.First(tr => tr is TranslateTransform);
            _start = e.GetPosition(Border);
            _origin = new Point(translateTransform.X, translateTransform.Y);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (Image.IsMouseCaptured)
            {
                var translateTransform = (TranslateTransform)((TransformGroup)Image.RenderTransform).Children.First(tr => tr is TranslateTransform);
                Vector v = _start - e.GetPosition(Border);
                translateTransform.X = _origin.X - v.X;
                translateTransform.Y = _origin.Y - v.Y;
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image.ReleaseMouseCapture();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox) sender;
            tb.Text = "  ";
            var translateTransform = (TranslateTransform)((TransformGroup)Image.RenderTransform).Children.First(tr => tr is TranslateTransform);
            translateTransform.X = translateTransform.Y = 0;
        }

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var bmp = (BitmapSource) Image.Source;

            //Do job..
            var x = Convert.ToInt32(e.GetPosition(Image).X * bmp.PixelWidth / Image.ActualWidth);
            var y = Convert.ToInt32(e.GetPosition(Image).Y * bmp.PixelHeight / Image.ActualHeight);

            int stride = bmp.PixelWidth * 4;
            int size = bmp.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bmp.CopyPixels(pixels, stride, 0);

            int index = y * stride + 4 * x;

            var b = pixels[index];
            var g = pixels[index + 1];
            var r = pixels[index + 2];
            var a = pixels[index + 3];

            ViewModel.Color = new Color {R = r, G = g, B = b, A = a};
            ColorHistoryViewModel.Instance.AddColorToHistory(new ColorEntry(ViewModel.Color));
            ViewModel.ColorSelected = true;
        }

        private void ScreenShotButton_OnClick(object sender, RoutedEventArgs e)
        {

            var screenLeft = SystemParameters.VirtualScreenLeft;
            var screenTop = SystemParameters.VirtualScreenTop;
            var screenWidth = SystemParameters.VirtualScreenWidth;
            var screenHeight = SystemParameters.VirtualScreenHeight;

            using (Bitmap bmp = new Bitmap((int) screenWidth, (int) screenHeight))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                MainWindow.Instance.Hide();
                Thread.Sleep(200);
                g.CopyFromScreen((int) screenLeft, (int) screenTop, 0, 0, bmp.Size);
                MainWindow.Instance.Show();
                Image.Source = bmp.BitmapToImageSource();
                ViewModel.ImageNotOpened = false;
            }

        }

        private void ColorText_LeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(ViewModel.Color.ToString());
            MainWindow.Instance.MainSnackbar.MessageQueue.Enqueue("Copied to the clipboard.");
        }
    }
}
