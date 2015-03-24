using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LA3.Reports
{
    public static class ReportHelper
    {
        public static void AddCell(PdfPTable tbl, string text, int rowSpan, int alignment, Font font, int cellBorder, int leading)
        {
            AddCell(tbl, text, rowSpan, alignment, font, cellBorder, 1, leading);
        }
        public static void AddCell(PdfPTable tbl, string text, int rowSpan, int alignment, Font font, int cellBorder, int colspan, int leading)
        {
            var cell = new PdfPCell(new Phrase(leading, new Chunk(text, font)))
                {
                    Colspan = colspan,
                    Rowspan = rowSpan,
                    Border = cellBorder,
                    HorizontalAlignment = alignment
                };

            tbl.AddCell(cell);
        }

        public static void AddLine(Document document, Font fontHeader, string line)
        {
            document.Add(new Paragraph(new Chunk(line, fontHeader)));
        }
        public static string CreateDoc(ref Document document)
        {
            return CreateDoc(ref document, true);
        }
        public static string CreateDoc(ref Document document, bool headersAndFooters)
        {
            //Delete old report files
            var di = new DirectoryInfo(Path.GetTempPath());
            foreach (FileInfo fi in di.GetFiles())
            {
                if (!fi.Name.StartsWith("LA3_")) continue;
                if (fi.Name.EndsWith(".pdf"))
                {
                    if (fi.CreationTime.AddDays(1) < DateTime.Now)
                        fi.Delete();
                }
            }

            //Setup folder & filename
            string filename = "LA3_" + Guid.NewGuid().ToString() + ".pdf";
            string pdfPath = Path.GetTempPath();
            pdfPath = Path.Combine(pdfPath, filename);

            //Creates a Writer that listens to this document and writes the document to the Stream of your choice:
            var pdfWriter = PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
            var page = new PdfPage();
            pdfWriter.PageEvent = page;

            document.Open();
            return pdfPath;
        }
        public static string ShowCurrency(double d)
        {
            return String.Format("{0:c}", d);
        }
    }
}
