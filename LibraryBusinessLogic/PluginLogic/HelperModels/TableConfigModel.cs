using System.Collections.Generic;

namespace LibraryBusinessLogic.PluginLogic.HelperModels
{
    public class TableConfigModel
    {
        public IEnumerable<string[]> Data { get; set; }
        public IEnumerable<string> Headers { get; set; }
        public IEnumerable<double> ColumnWidth { get; set; }
        public int HeaderTextSize { get; set; } = 14;
        public int DataTextSize { get; set; } = 12;
        public double SpaceAfterCm { get; set; } = 1;
    }
}