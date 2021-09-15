using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppsContext : DbContext
    {
        public AppsContext(DbContextOptions<AppsContext> options)
            : base(options)
        {
            InitDB();
        }


        public void InitDB()
        {
            // Страны
            countryItems.Add(new Country { Id = 1, name = "Россия" });
            countryItems.Add(new Country { Id = 2, name = "США" });

            // Отрасли
            industryItems.Add(new Industry { Id = 1, name = "IT" });
            industryItems.Add(new Industry { Id = 2, name = "Технологии" });
            industryItems.Add(new Industry { Id = 3, name = "Финансы" });
            industryItems.Add(new Industry { Id = 4, name = "Добыча ископаемых" });
            industryItems.Add(new Industry { Id = 5, name = "Нефть и газ" });
            industryItems.Add(new Industry { Id = 6, name = "Телекомуникации" });

            // Биржи
            rialtoItems.Add(new Rialto { Id = 1, сode = "MOEX", name = "Московская биржа" });

            // Эмитенты
            companyItems.Add(new Company { Id = 1, name = "Сбербанк России", countryID = 1, industryID = 3 });
            companyItems.Add(new Company { Id = 2, name = "МТС", countryID = 1, industryID = 6 });
            companyItems.Add(new Company { Id = 3, name = "Сургутнефтегаз", countryID = 1, industryID = 5 });
            companyItems.Add(new Company { Id = 4, name = "Алроса", countryID = 1, industryID = 4 });
            companyItems.Add(new Company { Id = 5, name = "Apple", countryID = 2, industryID = 2 });
            companyItems.Add(new Company { Id = 6, name = "Яндекс", countryID = 1, industryID = 1 });

            // Активы
            assetItems.Add(
                new Asset
                {
                    Id = 1,
                    assetClass = AssetClass.Share.ToString(),
                    assetType = AssetType.Simple.ToString(),
                    ticket = "SBER",
                    isin = "RU0009029540",
                    companyID = 1,
                    rialtoID = 1,
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2007, 7, 20) },
                    сurrency = "RUB"
                }
            );
            assetItems.Add(
                new Asset
                {
                    Id = 2,
                    assetClass = AssetClass.Share.ToString(),
                    assetType = AssetType.Privileged.ToString(),
                    ticket = "SBERP",
                    isin = "RU0009029557",
                    companyID = 1,
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2007, 7, 16) },
                    сurrency = "RUB"
                }
            );
            assetItems.Add(
                new Asset
                {
                    Id = 3,
                    assetClass = AssetClass.Share.ToString(),
                    assetType = AssetType.Simple.ToString(),
                    ticket = "MTSS",
                    isin = "RU0007775219",
                    companyID = 2,
                    rialtoID = 1,
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2004, 2, 11) },
                    сurrency = "RUB"
                }
            );
            assetItems.Add(
                new Asset
                {
                    Id = 4,
                    assetClass = AssetClass.Share.ToString(),
                    assetType = AssetType.Simple.ToString(),
                    ticket = "SNGS",
                    isin = "RU0008926258",
                    companyID = 3,
                    rialtoID = 1,
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2005, 1, 11) },
                    сurrency = "RUB"
                }
            );
            assetItems.Add(
                new Asset
                {
                    Id = 5,
                    assetClass = AssetClass.Share.ToString(),
                    assetType = AssetType.Simple.ToString(),
                    ticket = "ALRS",
                    isin = "RU0007252813",
                    companyID = 4,
                    rialtoID = 1,
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2005, 11, 29) },
                    сurrency = "RUB"
                }
            );
            assetItems.Add(
                new Asset
                {
                    Id = 6,
                    assetClass = AssetClass.Share.ToString(),
                    assetType = AssetType.Simple.ToString(),
                    ticket = "AAPL-RM",
                    isin = "US0378331005",
                    companyID = 5,
                    rialtoID = 1,
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2020, 09, 08) },
                    сurrency = "USD"
                }
            );
            assetItems.Add(
                new Asset
                {
                    Id = 7,
                    assetClass = AssetClass.Share.ToString(),
                    assetType = AssetType.Simple.ToString(),
                    ticket = "YNDX",
                    isin = "NL0009805522",
                    companyID = 6,
                    rialtoID = 1,
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2014, 06, 04) },
                    сurrency = "USD"
                }
            );

            //Облигации 
            assetItems.Add(
                new Asset
                {
                    Id = 8,
                    assetClass = AssetClass.Bond.ToString(),
                    assetType = AssetType.Сorporate.ToString(),
                    ticket = "RU000A101C89",
                    isin = "RU000A101C89",
                    name = "Sber 001P-SBER15",
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2020, 01, 20) },
                    сurrency = "RUB"
                }
            );
            assetItems.Add(
                new Asset
                {
                    Id = 9,
                    assetClass = AssetClass.Bond.ToString(),
                    assetType = AssetType.Сorporate.ToString(),
                    ticket = "RU000A1013J4",
                    isin = "RU000A1013J4",
                    name = "SberIOS 001P-177R GMKN 100",
                    circulationPeriod = new DatePeriod { dateB = new System.DateTime(2019, 06, 19) },
                    сurrency = "RUB"
                }
            );

            SaveChangesAsync();
        }

        public DbSet<Asset> assetItems { get; set; }
        public DbSet<Company> companyItems { get; set; }
        public DbSet<Country> countryItems { get; set; }
        public DbSet<Industry> industryItems { get; set; }
        public DbSet<Rialto> rialtoItems { get; set; }
    }
}
