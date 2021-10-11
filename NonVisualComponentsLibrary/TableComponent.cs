using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using NonVisualComponentsLibrary.HelperModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace NonVisualComponentsLibrary
{
    public partial class TableComponent : Component
    {
        private Dictionary<string, int> propertyInfo;
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

        private bool CheckInput<T>(TableParameters<T> parameters)
        {
            if (parameters == null)
            {
                ErrorMessage = "Не указаны параметры таблицы";
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Path))
            {
                ErrorMessage = "Не указан путь";
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Title))
            {
                ErrorMessage = "Не указан заголовок";
                return false;
            }

            if (parameters.DataList == null)
            {
                ErrorMessage = "Не указаны данные";
                return false;
            }

            if (parameters.CellsFirstColumn == null || parameters.CellsSecondColumn == null)
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
            styleContent.Font.Size = 10;
            styleContent.Font.Bold = false;
            styleContent.Font.Color = Colors.Black;
            document.Styles.AddStyle("NormalContent", "Normal");
        }

        private bool CreateTableHeader(Table table, List<TableCell> firstColumn, List<TableCell> secondColumn, int dataCount)
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
                ErrorMessage = "Неправильно указаны ячейки шапки";
                return false;
            }

            for (var i = 0; i < dataCount; i++)
            {
                table.AddColumn();
            }

            propertyInfo = new Dictionary<string, int>();

            foreach (var cell in firstColumn)
            {
                for (var i = 0; i < cell.CountCells; i++)
                {
                    var row = table.AddRow();
                    row.HeightRule = RowHeightRule.Exactly;
                    row.Height = cell.RowHeight;
                }
            }

            var currentIndex = 0;
            foreach (var cell in firstColumn)
            {
                var currentCell = table.Rows[currentIndex].Cells[0];

                if (string.IsNullOrEmpty(cell.Name))
                {
                    ErrorMessage = "Не указано название для строки";
                    return false;
                }

                currentCell.AddParagraph(cell.Name);
                currentCell.Format.Alignment = ParagraphAlignment.Center;

                if (cell.CountCells > 1)
                {
                    currentCell.MergeDown = cell.CountCells - 1;
                    currentIndex += cell.CountCells;
                }
                else
                {
                    if (string.IsNullOrEmpty(cell.PropertyName))
                    {
                        ErrorMessage = "Не указано название свойства для строки";
                        return false;
                    }
                    propertyInfo.Add(cell.PropertyName, currentIndex);
                    currentIndex++;
                }
            }

            var countMerged = 0;
            currentIndex = 0;
            for (var i = 0; i < countRowsTop; i++)
            {
                var leftCurrentCell = table.Rows[i].Cells[0];
                var currentCell = table.Rows[i].Cells[1];

                countMerged = leftCurrentCell.MergeDown > 0 ? leftCurrentCell.MergeDown + 1 : countMerged;

                if (countMerged != 0)
                {
                    if (string.IsNullOrEmpty(secondColumn[currentIndex].Name))
                    {
                        ErrorMessage = "Не указано название для строки";
                        return false;
                    }
                    currentCell.AddParagraph(secondColumn[currentIndex].Name);

                    if (string.IsNullOrEmpty(secondColumn[currentIndex].PropertyName))
                    {
                        ErrorMessage = "Не указано название свойства для строки";
                        return false;
                    }
                    propertyInfo.Add(secondColumn[currentIndex].PropertyName, i);
                    currentCell.Format.Alignment = ParagraphAlignment.Center;
                    currentIndex++;
                    countMerged--;
                }
                else
                {
                    leftCurrentCell.MergeRight = 1;
                }
            }
            return true;
        }

        public bool CreateDocument<T>(TableParameters<T> parameters) where T : class
        {

            if (!CheckInput(parameters))
            {
                return false;
            }

            var document = new Document();
            CreateTextStyle(document);
            var section = document.AddSection();

            var paragraph = section.AddParagraph(parameters.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            var borders = new Borders { Width = 1 };

            var table = document.LastSection.AddTable();
            table.Borders = borders;
            table.Rows.VerticalAlignment = VerticalAlignment.Center;

            if (!CreateTableHeader(table, parameters.CellsFirstColumn, parameters.CellsSecondColumn, parameters.DataList.Count + 2))
            {
                return false;
            }

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < parameters.DataList.Count; i++)
            {
                var data = parameters.DataList.ElementAt(i);

                foreach (var property in props)
                {
                    var prop = data.GetType().GetProperty(property.Name);
                    if (prop == null)
                    {
                        ErrorMessage = "Неверно указано название свойства для строки";
                        return false;
                    }
                    var rowIndex = propertyInfo[prop.Name];
                    table.Rows[rowIndex].Cells[i + 2].AddParagraph(prop.GetValue(data, null)?.ToString());
                }
            }

            var renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(parameters.Path);
            return true;
        }
    }
}