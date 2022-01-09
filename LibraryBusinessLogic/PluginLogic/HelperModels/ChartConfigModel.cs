using LibraryBusinessLogic.PluginLogic.Enums;
using System.Collections.Generic;

namespace LibraryBusinessLogic.PluginLogic.HelperModels
{
    public struct Series
    {
        public double[] YAxisValues { get; set; }
        public string Name { get; set; }
    }

    public class ChartConfigModel
    {
        public ChartType Type { get; set; } = ChartType.Line;
        public string Header { get; set; } = "Диаграмма";
        public double Width { get; set; } = 16;
        public double Height { get; set; } = 10;
        public string[] XAxisValues { get; set; }
        public List<Series> Series { get; set; }
        public double SpaceAfterCm { get; set; } = 1;
    }
}