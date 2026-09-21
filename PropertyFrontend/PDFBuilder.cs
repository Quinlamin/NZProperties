using QuestPDF;
using NZPropertyScraper;
using System.Security.Cryptography;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
namespace PropertyFrontend
{
    public static class PDFBuilder
    {

        public static byte[] Build(string address)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            string secureHex = RandomNumberGenerator.GetHexString(32, lowercase: true);
            WaipaDCScrape scrape = new WaipaDCScrape("DRIVERS");
            Property p = scrape.PropertyAndRatesWaipa(address);
            byte[] rv = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header().Text(address).SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);
                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(x =>
                    {
                        x.Spacing(20);
                        x.Item().Text($"Land Val: ${p.landVal}\nCap Val: ${p.capVal}\nRates: ${p.rates}");
                        x.Item().Image(Convert.FromBase64String(p.base64satellite));
                    });
                });
            }).GeneratePdf();
            return rv;
        }
    }
}
