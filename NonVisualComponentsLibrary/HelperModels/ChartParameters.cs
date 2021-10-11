using NonVisualComponentsLibrary.Enums;

namespace NonVisualComponentsLibrary.HelperModels
{
    public class ChartParameters
    {

        public string Path { get; set; }
        public string Title { get; set; }
        public string ChartName { get; set; }
        public ChartLegendLocation ChartLegendLocation { get; set; }
        public double[] Series { get; set; }
        public string[] XSeries { get; set; }
    }
}