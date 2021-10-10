namespace NonVisualComponentsLibrary.HelperModels
{
    public class CellPdfTable
    {
        public string Name { get; set; }
        public string PropertyName { get; set; }
        public string ColumnWidth { get; set; } = "2cm";
        public int CountCells { get; set; } = 1;
    }
}