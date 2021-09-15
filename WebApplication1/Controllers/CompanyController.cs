using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly AppsContext _context;
        public CompanyController(AppsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Все эмитенты
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyToShow>>> GetCompanys()
        {
            List<CompanyToShow> cList = new List<CompanyToShow>();

            foreach (Company c in _context.companyItems)
            {
                cList.Add(CompanyToShow(c));
            }

            return cList;
        }

        /// <summary>
        /// Все актимы имитента по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId")]
        public async Task<ActionResult<IEnumerable<SimpleAsset>>> GetCompanysAssets(long id)
        {
            List<SimpleAsset> cList = new List<SimpleAsset>();

            var assets = _context.assetItems
                                    .Where(c => c.companyID == id)
                                    .Where(c => c.circulationPeriod.dateE == DateTime.MinValue)
                                    .OrderBy(c => c.circulationPeriod.dateB);

            foreach (Asset asset in assets)
            {
                cList.Add(AssetToSimple(asset));
            }

            return cList;
        }

        public CompanyToShow CompanyToShow(Company company)
        {
            return new CompanyToShow
            {
                name = company.name,
                country = _context.countryItems.Find(company.countryID) is null ? null : _context.countryItems.Find(company.countryID).name,
                industry = _context.industryItems.Find(company.industryID) is null ? null : _context.industryItems.Find(company.industryID).name
            };
        }

        public SimpleAsset AssetToSimple(Asset asset)
        {
            return new SimpleAsset
            {
                id = asset.Id,
                name = asset.name,
                assetClass = asset.assetClass.ToString(),
                isin = asset.isin,
                ticket = asset.ticket,
                rialtoCode = _context.rialtoItems.Find(asset.rialtoID) is null ? null : _context.rialtoItems.Find(asset.rialtoID).сode,
                companyName = _context.companyItems.Find(asset.companyID) is null ? null : _context.companyItems.Find(asset.companyID).name
            };
        }

    }
}
