# JackalopePDF

**JackalopePDF** is a lightweight and extensible PDF generation library designed for dynamic report building in .NET projects. Built with precision layout logic and table formatting controls, JackalopePDF supports full table rendering, custom font registration, multi-page output, and developer-friendly helper functions. It is distributed as a compiled `.dll` library.

---

## 🔧 Requirements

* .NET Standard 2.0 or later
* PDFsharp 6.2.0 (included via reference)
* Embedded font files (THSarabunNew family, included)

---

Works with
* Console Apps (.NET 6+)
* Web APIs (ASP.NET Core)
* Background Services / Workers
* Azure Functions & AWS Lambda
* Linux / Windows / Docker Runtime
* No UI, No Designer, No Browser required

Built with pure .NET and PdfSharp, no external dependencies

---

## 🚀 Quick Start

```csharp
// Required namespaces
using PdfSharp;
using PdfSharp.Drawing;
using JackalopePDF;
using JackalopePDF.Enum;

class Program
{
    static void Main()
    {
      var builder = new PDFBuilder();
      JackalopeHelper.GetReady(); // Required for default fonts

      builder.SetPage(pg =>
      {
          pg.PageSize = PageSize.A4;
          pg.Margin = (0.5, 0.5, 0.5, 0.5);
          pg.ReportUnit = ReportUnit.Centimeter;
      });
      
      builder.AddPage();
      builder.DrawText("Hello PDF World", 3, 3);
      
      builder.ExportToPDF("./output.pdf");
     }
}
```

---

## 💡 Features

* ✅ Fluent API for layout configuration
* ✅ Dynamic table rendering with page-aware summary rows
* ✅ Page overlays for watermarking or header/footer
* ✅ Font registration with custom font resolver
* ✅ String truncation based on width + font metrics
* ✅ Integrated helper for currency, numeric formatting
* ✅ Table and column-level styling via attached settings

---

## 📘 API Reference

### JackalopeHelper

* `GetReady()` — Registers default fonts (THSarabunNew all styles). Required if not registering manually.
* `FormatIntComma(string)` — Converts "10000" → "10,000".
* `FormatCurrencyString(object)` — Converts "10000" → "10,000.00".
* `convertToDouble(object)` — Parses strings like "1,500" into 1500.0.
* `TruncateSmart(...)` — Truncates text by max width with suffix.
* `ConvertToUnit(...)` / `ConvertFromPoint(...)` — Converts values between units and PDF points.
* `ToDataTable<T>(List<T>)` — Converts generic list to DataTable.
* `RegisterFont(...)` — Registers custom fonts with name/style.
* `GetVersion()` — Returns version string (e.g. "JackalopePDF DEMO v1.0.0").
* `SetTable(...)` — Attaches table-level layout settings to DataTable.
* `SetColumn(...)` — Attaches column-level layout settings to DataColumn.

---

### PDFBuilder — Public Methods

#### Page & Layout

* `SetGlobalPageOverlay()` — Sets watermark or overlay for all pages.
* `SetPage(Action<PageSetting>)` — Sets page size/margin settings.
* `AddPage()` — Creates a new page (must call once before drawing).
* `getPageWidth()` / `getPageHeight()` — Returns current page dimensions.
* `goToPage(index)` — Switch drawing context to a different page.

#### Fonts

* `SetFont(name, size, style, color)` — Sets font with full spec.
* `SetFontFamily(name)` / `SetFontSize(size)` / `SetFontColor(color)` / `SetFontStyle(style)` — Adjust font components.

#### Drawing

* `DrawText(text, x, y)` — Draws text at location.
* `DrawMultilineText(...)` — Draws text wrapped within a width.
* `DrawTextCenter(text, y)` — Centers text horizontally.
* `DrawLine(...)` / `DrawRectangle(...)` / `FillRectangle(...)` — Basic shape drawing.

#### Tables & Images

* `DrawImage(path, x, y, w, h)` — Draws image.
* `DrawTable(table, x, y)` — Draws DataTable using attached layout rules.

#### Export

* `ExportToPDF(path)` — Finalizes and saves PDF.
* `TestPrint(...)` — Debug function to inspect grid positions.

---

## 🧪 Example Output

Want to see what it looks like?
👉 [Click here to view the sample PDF with watermark](JackalopeReport.pdf)

---

## ❓ FAQ

* **Why don’t my fonts appear correctly?**
  → You must call `JackalopeHelper.GetReady()` before generating PDFs.

* **Why are some columns missing summary values?**
  → Set `PageSummarySettings` or override with `SetColumn(...)` for manual configuration.

* **Does it support Excel export?**
  → Not currently. Excel rendering is not supported in this version.

---

## 🪪 Licensing

JackalopePDF is distributed as a compiled `.dll` file under a commercial license.

* One-time purchase
* No subscription required
* No runtime watermark or restrictions

Contact the developer for licensing inquiries or enterprise use.

---

## Pricing & License

🧪 This library runs in demo mode by default.  
All exported PDFs will contain a small, elegant watermark.

To unlock the full version (no watermark):
🎯 **One-time purchase: $29**

✅ Commercial use allowed  
✅ Lifetime access  
✅ No DRM  
✅ Instant download

👉 Purchase now at: [https://jackalopeys.gumroad.com/l/jackalopepdf](https://jackalopeys.gumroad.com/l/jackalopePDF)

#ExportPDF แบบโคตรง่าย
#ExportPDF Very Easy
