using LibraryBusinessLogic.PluginLogic.HelperModels;
using LibraryBusinessLogic.PluginLogic.Interfaces;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PdfPluginImplementation
{
    public class PdfReportBuilder : IReportBuilder
    {
        public string PluginType => "Pdf";

        private readonly Document document;

        public PdfReportBuilder()
        {
            document = new Document();
            document.AddSection();
        }

        public bool SaveDocument(string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) return false;
            if (!filepath.EndsWith(".pdf")) filepath += ".pdf";
            var renderer = new PdfDocumentRenderer(true,
                    PdfSharp.Pdf.PdfFontEmbedding.Always)
            { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(filepath);
            return true;
        }

        public bool AddParagraph(ParagraphConfigModel config)
        {
            if (config is null || string.IsNullOrEmpty(config.Text)) return false;
            var paragraph = new Paragraph();
            paragraph.AddText(config.Text);
            var textFormat = CreateTextFormat(config.TextSize, config.Bold, config.Italic, config.Underline);
            paragraph.Format = textFormat;
            paragraph.Format.SpaceAfter = Unit.FromCentimeter(config.SpaceAfterCm);
            document.LastSection.Add(paragraph);
            return true;
        }

        public bool AddImage(ImageConfigModel config)
        {
            if (config is null || string.IsNullOrEmpty(config.ImagePath)) return false;
            if (!new FileInfo(config.ImagePath).Exists) return false;
            var image = new Image();
            image.Name = config.ImagePath;
            image.Width = Unit.FromCentimeter(config.Width);
            image.Height = Unit.FromCentimeter(config.Height);
            document.LastSection.Add(image);
            document.LastSection.AddParagraph().Format.SpaceAfter = Unit.FromCentimeter(config.SpaceAfterCm);
            return true;
        }

        public bool AddTable(TableConfigModel config)
        {
            if (config is null ||
                config.Data is null ||
                config.Headers is null ||
                config.ColumnWidth is null ||
                config.ColumnWidth.Count() != config.Headers.Count()) return false;

            var borders = new Borders { Width = 1 };
            var table = new Table();
            table.Borders = borders;
            table.Rows.VerticalAlignment = VerticalAlignment.Center;

            foreach (var column in config.ColumnWidth)
            {
                table.AddColumn(Unit.FromCentimeter(column));
            }

            var headerFormat = CreateTextFormat(config.HeaderTextSize, bold: true);
            var dataFormat = CreateTextFormat(config.DataTextSize);

            var headerRow = CreateRow(config.Headers, headerFormat);
            table.Rows.Add(headerRow);

            foreach (var line in config.Data)
            {
                int length = line.Length;
                if (length > config.Headers.Count()) return false;
                var row = CreateRow(line, dataFormat);
                table.Rows.Add(row);
            }

            table.Rows.Alignment = RowAlignment.Center;
            table.Format.SpaceAfter = Unit.FromCentimeter(config.SpaceAfterCm);

            if (table is null) return false;
            document.LastSection.Add(table);
            return true;
        }

        public bool AddChart(ChartConfigModel config)
        {
            if (config is null ||
                config.Series is null ||
                config.XAxisValues is null ||
                config.XAxisValues.Length < 1
            ) return false;

            var chart = new Chart();
            var chartType = (ChartType)Enum.Parse(typeof(ChartType), config.Type.ToString());
            chart.Type = chartType;
            chart.Width = Unit.FromCentimeter(config.Width);
            chart.Height = Unit.FromCentimeter(config.Height);
            chart.HeaderArea.AddParagraph(config.Header);
            chart.RightArea.AddLegend();

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            foreach (var data in config.Series)
            {
                if (data.YAxisValues.Length < 1) return false;
                var series = chart.SeriesCollection.AddSeries();
                series.Name = data.Name;
                series.Add(data.YAxisValues);
            }

            var xseries = chart.XValues.AddXSeries();
            xseries.Add(config.XAxisValues);

            document.LastSection.Add(chart);
            document.LastSection.AddParagraph().Format.SpaceAfter = Unit.FromCentimeter(config.SpaceAfterCm);
            return true;
        }

        public ParagraphFormat CreateTextFormat(int size, bool bold = false, bool italic = false, bool underline = false)
        {
            var font = new Font()
            {
                Bold = bold,
                Italic = italic,
                Underline = underline ? Underline.Single : Underline.None,
                Size = size
            };
            var format = new ParagraphFormat
            {
                Font = font
            };
            return format;
        }

        private Row CreateRow(IEnumerable<string> line, ParagraphFormat format)
        {
            var row = new Row();
            var i = 0;
            foreach (var cell in line)
            {
                var newParagraph = row.Cells[i].AddParagraph(cell);
                newParagraph.Format = format.Clone();
                i++;
            }

            return row;
        }
    }
}
