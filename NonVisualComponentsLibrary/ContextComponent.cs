using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.ComponentModel;
using System.Drawing;

namespace NonVisualComponentsLibrary
{
    public partial class ContextComponent : Component
    {
        [Category("Пользовательская категория"), Description("Содержание ошибки")]

        public string errorMessage;

        public ContextComponent()
        {
            InitializeComponent();
        }

        public ContextComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CreateDocument(string Path, string Title, Image[] ImagesFileNames)
        {

            if (string.IsNullOrEmpty(Path))
            {
                errorMessage = "Не указан путь";
                return false;
            }

            if (string.IsNullOrEmpty(Title))
            {
                errorMessage = "Не указан заголовок";
                return false;
            }

            if (ImagesFileNames == null)
            {
                errorMessage = "Не указан массив изображений";
                return false;
            }

            var document = new Document();

            var styleTitle = document.Styles["Normal"];
            styleTitle.Font.Name = "Times New Roman";
            styleTitle.Font.Size = 14;
            styleTitle.Font.Color = Colors.Black;
            styleTitle.Font.Bold = true;
            document.Styles.AddStyle("NormalTitle", "Normal");

            var section = document.AddSection();

            var paragraphTitle = section.AddParagraph(Title);
            paragraphTitle.Format.SpaceAfter = "1cm";
            paragraphTitle.Format.Alignment = ParagraphAlignment.Center;
            paragraphTitle.Style = "NormalTitle";

            foreach (var image in ImagesFileNames)
            {
                var paragraphContent = section.AddParagraph();

                paragraphContent.AddImage(image);
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(Path);
            return true;
        }
    }
}