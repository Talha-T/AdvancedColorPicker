using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AdvancedColorPicker.Models
{
    public class ColorHistoryCollection : ObservableCollection<ColorEntry>
    {
        public ColorHistoryCollection(List<ColorEntry> list) : base(list)
        {
        }

        public ColorHistoryCollection() { }
    }
}
