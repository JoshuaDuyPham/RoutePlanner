using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI.HtmlControls;

namespace RoutePlanner
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //When the print button is pressed, 
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            
            HtmlGenericControl ul_myLst = (HtmlGenericControl)this.Page.FindControl("DestinationList");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(ul_myLst.InnerHtml);

            List<string> result = doc.DocumentNode.SelectNodes("li").Select(x => x.InnerText).ToList();
            
            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            
            foreach (string listItem in result)
            {
                pdfDocument.Add(new Paragraph(listItem));
            }
            
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=Employees.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}