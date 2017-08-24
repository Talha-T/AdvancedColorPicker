namespace AdvancedColorPicker.Models
{
    public class Theme
    {


        public string Name { get; set; } = "New Theme";

        public ColorHistoryCollection ColorEntries { get; set; } = new ColorHistoryCollection();

        public override string ToString()
        {
            return Name;
        }
    }
}