using System;
using System.Windows;
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;

namespace AdvancedColorPicker.Dialogs
{
    /// <summary>
    /// ProgressDialog.xaml etkileşim mantığı
    /// </summary>
    public partial class ProgressDialog
    {
        public ProgressDialog()
        {
            InitializeComponent(); 
        }

        public event Action Closed;

        public ProgressDialog(TimeSpan span, bool noOkButton = true) : this()
        {
            if (noOkButton)
                OkButton.Visibility = Visibility.Collapsed;
            ProgressBar.IsIndeterminate = false;
            ProgressBar.Maximum = span.TotalMilliseconds;
            DispatcherTimer timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(1)};
            timer.Tick += delegate
            {
                if (ProgressBar.Value >= ProgressBar.Maximum)
                {
                    timer.Stop();
                    OnClosed();
                }
                ProgressBar.Value += 10;
            };
            timer.Start();
            
        }

        protected virtual void OnClosed()
        {
            DialogHost.CloseDialogCommand.Execute(null, null);
            Closed?.Invoke();
        }
    }
}
