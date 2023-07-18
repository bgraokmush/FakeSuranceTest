using FakeSurance.Business.Abstract;
using FakeSurance.Entities.Concrete;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text;

namespace FakeSurance.Business.Concrete
{
    public class PdfManager : IPdfService
    {
        public byte[] GeneratePdfFromTable(Order order)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // PDF belgesini oluştur
            PdfDocument document = new PdfDocument();
            document.Options.FlateEncodeMode = PdfFlateEncodeMode.BestCompression;

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Tablo başlığı
            int yPosition = 10;

            gfx.DrawString($" {order.Id} Id sahip Order", new XFont("Arrial", 14, XFontStyle.Bold), XBrushes.Black, new XRect(10, yPosition, page.Width, page.Height), XStringFormats.TopLeft);
            yPosition += 20;

            // Başlığın yazılması
            gfx.DrawString(order.Title, new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, new XRect(10, yPosition, page.Width, page.Height), XStringFormats.TopLeft);
            yPosition += 15;

            // Açıklamanın yazılması
            gfx.DrawString(order.Description, new XFont("Arial", 12, XFontStyle.Regular), XBrushes.Azure, new XRect(10, yPosition, page.Width, page.Height), XStringFormats.TopLeft);
            yPosition += 20;

            // PDF'i byte dizisine dönüştür
            byte[] pdfBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream, false);
                pdfBytes = stream.ToArray();
            }

            return pdfBytes;
        }
    }
}
