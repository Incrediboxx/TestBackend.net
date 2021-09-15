using System;

namespace WebApplication1.Models
{
    /// <summary>
    /// Краткая информация об активе
    /// </summary>
    public class SimpleAsset
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Класс актива
        /// </summary>
        public string assetClass { get; set; }

        /// <summary>
        /// Буквенный идентификатор актива
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// Международный код ISO-6166
        /// </summary>
        /// 
        public string isin { get; set; }

        /// <summary>
        /// Код биржи
        /// </summary>
        public string rialtoCode { get; set; }

        /// <summary>
        /// Название эмитента
        /// </summary>
        public string companyName { get; set; }
    }

    /// <summary>
    /// Класс актива
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Класс актива
        /// </summary>
        public string assetClass { get; set; }

        /// <summary>
        /// Буквенный идентификатор актива
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// Международный код ISO-6166
        /// </summary>
        /// 
        public string isin { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Идентификатор компании эммитента
        /// </summary>
        public long companyID { get; set; }

        /// <summary>
        /// Идентификатор биржи
        /// </summary>
        public long rialtoID { get; set;}

        /// <summary>
        /// период обращения
        /// </summary>
        public DatePeriod circulationPeriod { get; set; }

        /// <summary>
        /// Базовая валюта
        /// </summary>
        public string сurrency { get; set; }

        /// <summary>
        /// Размер лота
        /// </summary>
        public int lotSize { get; set; }

        /// <summary>
        /// Тип актива
        /// </summary>
        public string assetType { get; set; }
    }

    /// <summary>
    /// Период дат
    /// </summary>
    public struct DatePeriod
    {
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime dateB { get; set; }

        /// <summary>
        /// Дата конца
        /// </summary>
        public DateTime dateE { get; set; }
    }

    public enum AssetType
    {
        /// <summary>
        /// Акция, обычная
        /// </summary>
        Simple,

        /// <summary>
        /// Акция, привелигированная
        /// </summary>
        Privileged,

        /// <summary>
        /// Облигация, государсвенная
        /// </summary>
        State,

        /// <summary>
        /// Облигация, муниципальная
        /// </summary>
        Municipal,

        /// <summary>
        /// Облигация, корпоративная
        /// </summary>
        Сorporate
    }

    public enum AssetClass
    {
        /// <summary>
        /// Акция
        /// </summary>
        Share,

        /// <summary>
        /// Облигация
        /// </summary>
        Bond
    }


}
