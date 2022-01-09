using LibraryBusinessLogic.PluginLogic.HelperModels;

namespace LibraryBusinessLogic.PluginLogic.Interfaces
{
    public interface IReportBuilder
    {
        string PluginType { get; }

        bool SaveDocument(string filepath);
        bool AddParagraph(ParagraphConfigModel config);
        bool AddImage(ImageConfigModel config);
        bool AddTable(TableConfigModel config);
        bool AddChart(ChartConfigModel config);
    }
}