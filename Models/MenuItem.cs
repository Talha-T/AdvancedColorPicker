using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using LoLDuvarKağıtları.Models;

namespace AdvancedColorPicker.Models
{
    public class MenuItem : INotifyPropertyChanged
    {
        private string _name;
        private object _content;
        private ScrollBarVisibility _horizontalScrollBarVisibilityRequirement;
        private ScrollBarVisibility _verticalScrollBarVisibilityRequirement;
        private Thickness _marginRequirement = new Thickness(0);

        public MenuItem(string name, object content)
        {
            _name = name;
            Content = content;
        }

        public string Name
        {
            get => _name;
            set => this.MutateVerbose(ref _name, value, RaisePropertyChanged());
        }

        public object Content
        {
            get => _content;
            set => this.MutateVerbose(ref _content, value, RaisePropertyChanged());
        }

        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement
        {
            get => _horizontalScrollBarVisibilityRequirement;
            set => this.MutateVerbose(ref _horizontalScrollBarVisibilityRequirement, value, RaisePropertyChanged());
        }

        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement
        {
            get => _verticalScrollBarVisibilityRequirement;
            set => this.MutateVerbose(ref _verticalScrollBarVisibilityRequirement, value, RaisePropertyChanged());
        }

        public Thickness MarginRequirement
        {
            get => _marginRequirement;
            set => this.MutateVerbose(ref _marginRequirement, value, RaisePropertyChanged());
        }

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}