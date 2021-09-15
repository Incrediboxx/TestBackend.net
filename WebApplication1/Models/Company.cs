
namespace WebApplication1.Models
{
    /// <summary>
    /// Класс компании
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Идентификатор страны
        /// </summary>
        public long countryID { get; set; }

        /// <summary>
        /// Идентификатор отрасли
        /// </summary>
        public long industryID { get; set; }
    }

    public class CompanyToShow
    {
        /// <summary>
        /// Название
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Идентификатор страны
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// Идентификатор отрасли
        /// </summary>
        public string industry { get; set; }
    }
}
