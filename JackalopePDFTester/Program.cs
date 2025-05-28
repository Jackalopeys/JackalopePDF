using System;
using PdfSharp;
using PdfSharp.Drawing;
using JackalopePDF;
using JackalopePDF.Enum;
using System.IO;

namespace JackalopePDFTester
{
    class Program
    {
        static void Main(string[] args)
        {
            JackalopeHelper.GetReady();
            /*JackalopeHelper.RegisterFont(
                ("Fonts/arial.ttf", "Arial", XFontStyleEx.Regular),
                ("Fonts/arialbd.ttf", "Arial", XFontStyleEx.Bold),
                ("Fonts/ariali.ttf", "Arial", XFontStyleEx.Italic),
                ("Fonts/arialbi.ttf", "Arial", XFontStyleEx.BoldItalic)
            );*/
            var builder = new PDFBuilder();
            InvoiceItem invoiceItem = new InvoiceItem();
            var invoiceItemList = invoiceItem.GetSampleInvoiceItems();
            var invoiceItemTable = JackalopeHelper.ToDataTable(invoiceItemList);
            invoiceItemTable.Columns.RemoveAt(3);
            double sizeH1 = 30;
            double sizeH2 = 16;
            double sizeH3 = 14.5;
            double sizeH4 = 14;
            var opts = JackalopeHelper.SetTable(invoiceItemTable, opts =>
            {
                opts.MaxRowsPerPage = 15;
                opts.BreakPageWhenFull = true;
                opts.ColumnWidths = new double[] { 10, 30, 15, 20, 25 };
                opts.ColumnUnit = ColumnUnit.Percentage;
                opts.SummaryEachPage = true;
                opts.PageSummarySettings = new object[] { false, "Total", true, true, true };
                opts.ShowHeader = true;
                opts.HeaderHeight = 1;
                opts.HeaderBackgroundColor = XBrushes.DarkSlateBlue;
                opts.HeaderFontColor = XBrushes.White;
                opts.ColumnWidths = new double[] { 10, 30, 15, 20, 25 };
                opts.ColumnUnit = ColumnUnit.Percentage;
                opts.MaxRowsPerPage = 15;
                opts.EnableZebraStriping = true;
                opts.ZebraColor = XBrushes.Lavender;
                opts.BreakPageWhenFull = true;
                opts.SummaryEachPage = true;
                opts.IncludeGrandTotal = true;
                opts.GrandTotalSettings = new object[] { false, "Grand Total", true, true, true };
                opts.PageSummarySettings = new object[] { false, "Total", true, true, true };
                opts.HeaderNames = new string[] { "items", "Description", "Qry", "Unit Price", "Amount" };
                opts.ColumnFormatType = new FormatType[] { FormatType.Integer, FormatType.String, FormatType.Integer, FormatType.Float, FormatType.Float };
                opts.ColumnAlignment = new XStringAlignment[] { XStringAlignment.Center, XStringAlignment.Near, XStringAlignment.Center, XStringAlignment.Far, XStringAlignment.Far };
                opts.FooterFontStyle = XFontStyleEx.Bold;
                opts.HeaderFontStyle = XFontStyleEx.Bold;
                opts.RowHeight = 0.8;
                opts.ShowOuterBorder = true;
                opts.ShowFooterBottomBorder = true;
                opts.ShowFooterTopBorder = true;
                opts.ShowVerticalLines = false;
                opts.SummaryPageBackgroundColor = XBrushes.LightSteelBlue;
                opts.GrandTotalBackgroundColor = XBrushes.DarkSlateBlue;
                opts.GrandTotalFontColor = XBrushes.White;
                opts.FontSize = sizeH3;
            });

            var report = new PDFBuilder();
            report.SetPage(ops =>
            {
                ops.PageSize = PageSize.A4;
                ops.Margin = (0.5, 0.5, 0.5, 0.5);
                ops.ReportUnit = ReportUnit.Centimeter;
            });
            report.SetFont(14, XFontStyleEx.Bold, XBrushes.Black);

            double x1 = 1;
            double x2 = 12.5;
            double gap = 0.7;
            report.SetGlobalPageOverlay(new Action<PDFBuilder>((report) =>
            {
                //report.TestPrint(40, 40, 1);
                report.SetFontSize(sizeH1);
                report.SetFontStyle(XFontStyleEx.Bold);
                report.DrawText("INVOICE", report.getPageWidth() - 1.8, 1.5, XStringFormats.CenterRight); ;
                double y = 3;
                report.SetFontSize(sizeH2);
                report.SetFontStyle(XFontStyleEx.Bold);
                report.DrawText("Jackalope Co., Ltd.", x1, y); y += 1;
                report.SetFontSize(sizeH4);
                report.SetFontStyle(XFontStyleEx.Regular);
                report.DrawMultilineText(
                    x1, y, gap,
                    "99 Gold Junction",
                    "Bangkok, 10119",
                    "Tel. 02-173-4567",
                    "website , jackalope.ys@gumroad"
                    );

                y = 5.5;
                report.SetFontSize(sizeH2);
                report.SetFontStyle(XFontStyleEx.Bold);
                report.DrawText("BILL TO", x2, y); y += gap;
                report.SetFontSize(sizeH4);
                report.SetFontStyle(XFontStyleEx.Regular);
                report.DrawMultilineText(x2, y, gap,
                    "Mr.Customer God",
                    "Olympus Studio",
                    "88 Vogue Alley",
                    "Somewhere in the world"
                    );

                y = 7.6;
                report.SetFontStyle(XFontStyleEx.Bold);
                report.DrawText("INVOICE #", x1, y);
                report.DrawText("INVOICE DATE", x1 + 6, y);
                report.SetFontStyle(XFontStyleEx.Regular); y += gap;
                report.DrawText("NV-20240327-001", x1, y);
                report.DrawText("May 27, 2025", x1 + 6, y);
            }));
            report.AddPage();
            // Draw Table
            double y = report.DrawTable(invoiceItemTable, 1, 10); y += 1.5;
            string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "jackalope.png");
            report.DrawImage(imagePath, 14.7, 21.5, 5, 5);
            report.SetFontStyle(XFontStyleEx.Bold);
            report.SetFontSize(sizeH4);
            report.DrawText("Please make payment by the due date.", 1, y); y += 1;
            report.SetFontStyle(XFontStyleEx.Regular);
            y = report.DrawMultilineText(x1, y, gap,
                "Bank trandfer to JACKALOPE Co. Ltd",
                "Commercial Bank, Account(Number 123-456-7890)"
               );
            y += gap;
            report.SetFontStyle(XFontStyleEx.Bold);
            report.DrawText("Thank you for your bisuness", report.getPageWidth() - 1.8, y, XStringFormats.CenterRight); ;
            // Save
            report.ExportToPDF("JackalopeReport.pdf");
            Console.WriteLine("Report generated: test-report.pdf" + JackalopeHelper.GetVersion());
        }
    }
}
