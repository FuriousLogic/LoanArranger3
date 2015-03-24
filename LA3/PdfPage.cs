using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LA3
{
    public class PdfPage : PdfPageEventHelper
    {
        private static Font Footer
        {
            get { return FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK); }
        }

        public override void OnStartPage(PdfWriter writer, Document doc)
        {
            //I use a PdfPtable with 1 column to position my header where I want it
            var headerTbl = new PdfPTable(2) { TotalWidth = doc.PageSize.Width };

            //create instance of a table cell to contain the timestamp
            var cell = new PdfPCell(new Phrase("Loan Arranger III")) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 20 };
            headerTbl.AddCell(cell);

            //create instance of a table cell to contain the timestamp
            cell = new PdfPCell(new Phrase(string.Format("Printed {0}", DateTime.Now.ToString("dd MMMM yyyy HH:mm")))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingRight = 20 };
            headerTbl.AddCell(cell);

            //write the rows out to the PDF output stream. I use the height of the document to position the table. Positioning seems quite strange in iTextSharp and caused me the biggest headache.. It almost seems like it starts from the bottom of the page and works up to the top, so you may ned to play around with this.
            headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height - 10), writer.DirectContent);
        }

        //override the OnPageEnd event handler to add our footer
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            //I use a PdfPtable with 2 columns to position my footer where I want it
            var footerTbl = new PdfPTable(2)
            {
                TotalWidth = doc.PageSize.Width,
                HorizontalAlignment = Element.ALIGN_CENTER
            };

            //Create a paragraph that contains the footer text
            var para = new Paragraph("Some footer text", Footer) { Environment.NewLine, "Some more footer text" };

            //create a cell instance to hold the text
            var cell = new PdfPCell(para) { Border = 0, PaddingLeft = 10 };

            //add cell to table
            footerTbl.AddCell(cell);

            //create new instance of Paragraph for 2nd cell text
            para = new Paragraph("Some text for the second cell", Footer);

            //create new instance of cell to hold the text
            cell = new PdfPCell(para) { HorizontalAlignment = Element.ALIGN_RIGHT, Border = 0, PaddingRight = 10 };

            //add the cell to the table
            footerTbl.AddCell(cell);

            //write the rows out to the PDF output stream.
            footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 10), writer.DirectContent);
        }
    }
}
