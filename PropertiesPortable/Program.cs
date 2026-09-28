using NZPropertyScraper;

using System.Security.Cryptography;
using QuestPDF;
using QuestPDF.Fluent;

using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
namespace PropertiesPortable
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PropertiesPortable());
        }
        public static byte[] Build(string address)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            string secureHex = RandomNumberGenerator.GetHexString(32, lowercase: true);
            WaipaDCScrape scrape = new WaipaDCScrape("DRIVERS");
            Property p = scrape.PropertyAndRatesWaipa(address);
            if (p == null)
            {
                throw new Exception("Address Not Found");
            }
            byte[] rv = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Text("PROPERTY APPRAISAL CHECK LIST").SemiBold().FontSize(20).FontColor(Colors.Black);
                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(x =>
                    {
                        x.Spacing(20);
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(40);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(40);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(40);
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Date: ");
                                header.Cell().Padding(0).BorderBottom(1).Text("            /            /            ");
                                header.Cell().Padding(0).Text("Vendor: ");
                                header.Cell().Padding(0).BorderBottom(1);
                                header.Cell().Padding(0).Text("Phone: ");
                                header.Cell().Padding(0).BorderBottom(1);
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(100);
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Property Address:   ");
                                header.Cell().Padding(0).BorderBottom(1).Text(p.address);
                            });

                        });

                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(100);
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Legal Description:");
                                header.Cell().Padding(0).BorderBottom(1).Text(p.legalDescription);
                            });

                        });

                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text($"Area:");
                                header.Cell().Padding(0).BorderBottom(1).Text($"{p.rateableArea.ToString("N2")}m2");
                                header.Cell().Padding(0).Text($" CV:");
                                header.Cell().Padding(0).BorderBottom(1).Text($"{p.capVal.ToString("C")}");
                                header.Cell().Padding(0).Text($" LV:");
                                header.Cell().Padding(0).BorderBottom(1).Text($"{p.landVal.ToString("C")}");
                                header.Cell().Padding(0).Text($" Rates:");
                                header.Cell().Padding(0).BorderBottom(1).Text($"{p.rates.ToString("C")}");
                            });
                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                                collumns.ConstantColumn(50);
                                collumns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text($"Age:");
                                header.Cell().Padding(0).BorderBottom(1);
                                header.Cell().Padding(0).Text($" Cladding:");
                                header.Cell().Padding(0).BorderBottom(1);
                                header.Cell().Padding(0).Text($" Roof:");
                                header.Cell().Padding(0).BorderBottom(1);
                                header.Cell().Padding(0).Text($" Joinery:");
                                header.Cell().Padding(0).BorderBottom(1);
                            });
                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(60);
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Kitchen:");
                                header.Cell().Padding(0).Text("Pantry");
                                header.Cell().Padding(0).Text("Stove");
                                header.Cell().Padding(0).Text("R/Hood");
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Oven");
                                header.Cell().Padding(0).Text("Dishwasher");
                                header.Cell().Padding(0).Text("Hob");
                                header.Cell().Padding(0).Text("Wastemaster");
                            });
                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(60);
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Living:");
                                header.Cell().Padding(0).Text("O/Plan");
                                header.Cell().Padding(0).Text("Sep Lounge");
                                header.Cell().Padding(0).Text("Family Room");
                                header.Cell().Padding(0).Text("Dining Room");
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(60);
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Bathroom:");
                                header.Cell().Padding(0).Text("Vanity");
                                header.Cell().Padding(0).Text("Shower");
                                header.Cell().Padding(0).Text("Sep");
                                header.Cell().Padding(0).Text("O/Bath");
                                header.Cell().Padding(0).Text("Toilet's");
                                header.Cell().Padding(0).Text("Heated Towel Rail");
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(60);
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Bedrooms:");
                                header.Cell().Padding(0).Text("Double");
                                header.Cell().Padding(0).Text("Single");
                                header.Cell().Padding(0).Text("Ensuite");
                                header.Cell().Padding(0).Text("WIR");

                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collums =>
                            {
                                collums.ConstantColumn(100);
                                collums.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Window Covering:s");
                                header.Cell().Padding(0).BorderBottom(1);
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collums =>
                            {
                                collums.ConstantColumn(60);
                                collums.RelativeColumn();
                                collums.ConstantColumn(80);
                                collums.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Heating:");
                                header.Cell().Padding(0).BorderBottom(1);
                                header.Cell().Padding(0).Text("Heat Transfer:");
                                header.Cell().Padding(0).BorderBottom(1);
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collums =>
                            {
                                collums.ConstantColumn(60);
                                collums.RelativeColumn();
                                collums.ConstantColumn(80);
                                collums.RelativeColumn();
                                collums.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Insulation:");
                                header.Cell().Padding(0).BorderBottom(1);
                                header.Cell().Padding(0).Text("Hot Water:");
                                header.Cell().Padding(0).Text("Gas");
                                header.Cell().Padding(0).Text("Electric");
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(80);
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Floor Covering:");
                                header.Cell().Padding(0).Text("Mixed");
                                header.Cell().Padding(0).Text("One Run");
                                header.Cell().Padding(0).Text("Vinyl");
                                header.Cell().Padding(0).Text("Tile");
                                header.Cell().Padding(0).Text("Wood");
                                header.Cell().Padding(0).Text("Other");
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(60);
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("O/D Living:");
                                header.Cell().Padding(0).Text("Decks");
                                header.Cell().Padding(0).Text("BBQ Area");
                                header.Cell().Padding(0).Text("Pool");
                                header.Cell().Padding(0).Text("Other");
                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(60);
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Garaging:");
                                header.Cell().Padding(0).Text("Dble");
                                header.Cell().Padding(0).Text("Sgle");
                                header.Cell().Padding(0).Text("Carport");
                                header.Cell().Padding(0).Text("Atchd");
                                header.Cell().Padding(0).Text("Sep");

                            });

                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {
                                collumns.ConstantColumn(60);
                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {
                                header.Cell().Padding(0).Text("Comments:");
                                header.Cell().Padding(0).BorderBottom(1);
                            });
                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {

                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {

                                header.Cell().Padding(0).BorderBottom(1);
                            });
                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {

                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {

                                header.Cell().Padding(0).BorderBottom(1);
                            });
                        });
                        x.Item().Table(table =>
                        {
                            table.ColumnsDefinition(collumns =>
                            {

                                collumns.RelativeColumn();
                            });
                            table.Header(header =>
                            {

                                header.Cell().Padding(0).BorderBottom(1);
                            });
                        });
                        //x.Item().Image(Convert.FromBase64String(p.base64satellite));

                    });
                });
            }).GeneratePdf();
            return rv;
        }
    }
}