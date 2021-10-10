using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using NonVisualComponentsLibrary.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonVisualComponentsLibrary
{
    public partial class TableComponent : Component
    {
        private Dictionary<string, int> propertyInfos;

        [Category("Пользовательская категория"), Description("Содержание ошибки")]
        public string ErrorMessage { get; set; }

        public TableComponent()
        {
            InitializeComponent();
        }

        public TableComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private bool CheckInputParams<T>(string Path, string Title, List<T> Data, List<CellPdfTable> CellsFirstColumn, List<CellPdfTable> CellsSecondColumn)
        {
            if (string.IsNullOrEmpty(Path))
            {
                ErrorMessage = "Не указан путь";
                return false;
            }

            if (string.IsNullOrEmpty(Title))
            {
                ErrorMessage = "Не указан заголовок";
                return false;
            }

            if (Data == null)
            {
                ErrorMessage = "Не указаны данные для заполнения таблицы";
                return false;
            }

            if (CellsFirstColumn == null || CellsSecondColumn == null)
            {
                ErrorMessage = "Не указаны параметры шапки";
                return false;
            }
            return true;
        }

        private void CreateTextStyle(Document document)
        {
            var styleTitle = document.Styles["Normal"];
            styleTitle.Font.Name = "Times New Roman";
            styleTitle.Font.Size = 14;
            styleTitle.Font.Color = Colors.Black;
            styleTitle.Font.Bold = true;
            document.Styles.AddStyle("NormalTitle", "Normal");

            var styleContent = document.Styles["Normal"];
            styleContent.Font.Name = "Times New Roman";
            styleContent.Font.Size = 12;
            styleContent.Font.Color = Colors.Black;
            document.Styles.AddStyle("NormalContent", "Normal");
        }

        private bool CreateTableHeader(Table table, List<CellPdfTable> firstColumn, List<CellPdfTable> secondColumn)
        {
            var countRowsTop = 0;
            var countMergeRows = 0;

            foreach (var cell in firstColumn)
            {
                countRowsTop += cell.CountCells;
                countMergeRows = cell.CountCells > 1 ? countMergeRows += cell.CountCells : countMergeRows;
            }

            if (countMergeRows != secondColumn.Count)
            {
                _errorMessage = ErrorTablePdfMessage.Неправильно_указаны_ячейки_шапки;
                return false;
            }

            foreach (var cell in firstColumn)
            {
                for (var i = 0; i < cell.CountCells; i++)
                {
                    table.AddColumn(cell.ColumnWidth);
                }
            }

            _propertyInfos = new Dictionary<string, int>();
            table.AddRow();

            var currentIndex = 0;
            foreach (var cell in firstColumn)
            {
                var currentCell = table.Rows[0].Cells[currentIndex];
                if (string.IsNullOrEmpty(cell.Name))
                {
                    _errorMessage = ErrorTablePdfMessage.Не_указано_название_для_колонки;
                    return false;
                }
                currentCell.AddParagraph(cell.Name);
                currentCell.Format.Alignment = ParagraphAlignment.Center;
                if (cell.CountCells > 1)
                {
                    currentCell.MergeRight = cell.CountCells - 1;
                    currentIndex += cell.CountCells;
                }
                else
                {
                    if (string.IsNullOrEmpty(cell.PropertyName))
                    {
                        _errorMessage = ErrorTablePdfMessage.Не_указано_название_свойства_для_колонки;
                        return false;
                    }
                    _propertyInfos.Add(cell.PropertyName, currentIndex);
                    currentIndex++;
                }
            }

            table.AddRow();

            var countMerged = 0;
            currentIndex = 0;
            for (var i = 0; i < countRowsTop; i++)
            {
                var highCurrentCell = table.Rows[0].Cells[i];
                var currentCell = table.Rows[1].Cells[i];

                countMerged = highCurrentCell.MergeRight > 0 ? highCurrentCell.MergeRight + 1 : countMerged;
                if (countMerged != 0)
                {
                    if (string.IsNullOrEmpty(secondColumn[currentIndex].Name))
                    {
                        _errorMessage = ErrorTablePdfMessage.Не_указано_название_для_колонки;
                        return false;
                    }
                    currentCell.AddParagraph(secondColumn[currentIndex].Name);
                    if (string.IsNullOrEmpty(secondColumn[currentIndex].PropertyName))
                    {
                        _errorMessage = ErrorTablePdfMessage.Не_указано_название_свойства_для_колонки;
                        return false;
                    }
                    _propertyInfos.Add(secondColumn[currentIndex].PropertyName, i);
                    currentCell.Format.Alignment = ParagraphAlignment.Center;
                    currentIndex++;
                    countMerged--;
                }
                else
                {
                    highCurrentCell.MergeDown = 1;
                }
            }
            return true;
        }

        public bool CreateDocument<T>(TablePdfParameters<T> tablePdfParameters) where T : class
        {

            if (!InputValidation(tablePdfParameters))
            {
                return false;
            }

            var document = new Document();
            CreateTextStyle(document);
            var section = document.AddSection();

            var paragraph = section.AddParagraph(tablePdfParameters.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            var borders = new Borders { Width = 1 };

            var table = document.LastSection.AddTable();
            table.Borders = borders;
            table.Rows.VerticalAlignment = VerticalAlignment.Center;

            if (!CreateHeadInTable(table, tablePdfParameters.CellsFirstRow, tablePdfParameters.CellsSecondRow))
            {
                return false;
            }

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var data in tablePdfParameters.DataList)
            {
                var newRow = table.AddRow();
                foreach (var property in props)
                {
                    var prop = data.GetType().GetProperty(property.Name);
                    if (prop == null)
                    {
                        _errorMessage = ErrorTablePdfMessage.Неверно_указано_название_свойства_для_колонки;
                        return false;
                    }
                    var columnIndex = _propertyInfos[prop.Name];
                    newRow.Cells[columnIndex].AddParagraph(prop.GetValue(data, null)?.ToString());
                }
            }

            var renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(tablePdfParameters.Path);
            return true;
        }
    }
}
