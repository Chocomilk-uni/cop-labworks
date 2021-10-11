using System.Collections.Generic;

namespace NonVisualComponentsLibrary.HelperModels
{
    public class TableParameters<T>
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public List<T> DataList { get; set; }
        public List<TableCell> CellsFirstColumn { get; set; }
        public List<TableCell> CellsSecondColumn { get; set; }
    }
}