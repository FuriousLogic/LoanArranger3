using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LA3.Reports
{
    public static class ReportHelper
    {
        private static string _filenamePrefix;

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
            //Delete old report files
            var di = new DirectoryInfo(Path.GetTempPath());
            if(di==null)
                throw new Exception("Error getting Temp Path!");

            _filenamePrefix = "LA3_";
            foreach (var fi in di.GetFiles())
            {
                if (!fi.Name.StartsWith(_filenamePrefix)) continue;
                if (fi.Name.EndsWith(".pdf"))
                {
                    if (fi.CreationTime.AddDays(1) < DateTime.Now)
                        fi.Delete();
                }
            }

            //Setup folder & filename
            var filename = _filenamePrefix + Guid.NewGuid() + ".pdf";
            var pdfPath = Path.GetTempPath();
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
            return string.Format("{0:c}", d);
        }
    }
}
