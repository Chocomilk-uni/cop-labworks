namespace LibraryBusinessLogic.PluginLogic.HelperModels
{
    public class ParagraphConfigModel
    {
        public string Text { get; set; }
        public int TextSize { get; set; } = 12;
        public bool Bold { get; set; } = false;
        public bool Italic { get; set; } = false;
        public bool Underline { get; set; } = false;
        public double SpaceAfterCm { get; set; } = 1;
    }
}