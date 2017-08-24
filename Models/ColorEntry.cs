using System;
using System.Windows.Media;

namespace AdvancedColorPicker.Models
{
    public class ColorEntry
    {

        public ColorEntry() { }

        public ColorEntry(Color color, string name = null)
        {
            Color = color;
            ColorPickDate = DateTime.Now;
            Name = name ?? color.ToString();
        }

        public bool IsFavorite { get; set; }

        public string Name { get; set; }

        public DateTime ColorPickDate { get; set; }

        public Color Color { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}