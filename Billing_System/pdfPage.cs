using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

namespace Billing_System
{
    public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
    {
        protected PdfTemplate template;
        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

        //public override void OnEndPage(PdfWriter writer, Document document)
        //{
        //    PdfContentByte cb = writer.DirectContent;
        //    template = cb.CreateTemplate(50, 50);

        //    int pageN = writer.PageNumber;
        //    String text = "Page " + pageN;
        //    float len = bf.GetWidthPoint(text, 6);

        //    Rectangle pageSize = document.PageSize;
        //    cb.SetRGBColorFill(100, 100, 100);

        //    cb.BeginText();
        //    cb.SetFontAndSize(bf, 6);
        //    cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(30));
        //    cb.ShowText(text);
        //    cb.EndText();

        //    cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));

        //    cb.BeginText();
        //    cb.SetFontAndSize(bf, 6);
            
        //    cb.EndText();

        //    cb.BeginText();
        //    cb.SetFontAndSize(bf, 6);
            
        //    cb.EndText();

         
        //}
       
    }
}