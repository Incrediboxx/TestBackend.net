using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : Controller
    {
        private readonly AppsContext _context;
        public AssetController(AppsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// получение полной информации об активе по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byID")]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssetsByID(long id)
        {
            var assets = _context.assetItems.Where(c => c.Id == id);

            return assets.ToList();
        }

        /// <summary>
        /// получение полной информации об активе по isin-коду
        /// </summary>
        /// <param name="isin"></param>
        /// <returns></returns>
        [HttpGet("byIsin")]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssetsByIsin(string isin)
        {

            var assets = _context.assetItems.Where(c => c.isin == isin);

            return assets.ToList();
        }

        /// <summary>
        /// поиск активов
        /// </summary>
        /// <param name="namePart"></param>
        /// <param name="ticketPart"></param>
        /// <param name="isinPart"></param>
        /// <param name="assetClass"></param>
        /// <returns></returns>
        [HttpGet("byPart")]
        public async Task<ActionResult<IEnumerable<SimpleAsset>>> GetAssetsByPart(string namePart = null, string ticketPart = null, string isinPart = null, string assetClass = null)
        {
            List<SimpleAsset> cList = new List<SimpleAsset>();
            //Если все обязательныe параметы пустые, либо короче 3 символов
            if ((string.IsNullOrEmpty(namePart) || namePart.Length < 3) && (string.IsNullOrEmpty(ticketPart) || ticketPart.Length < 3) && (string.IsNullOrEmpty(isinPart) || isinPart.Length < 3))
                return BadRequest();

            var assets = _context.assetItems
                        .Where(c => !string.IsNullOrEmpty(namePart) && c.name.Contains(namePart)
                                    || !string.IsNullOrEmpty(ticketPart) && c.ticket.Contains(ticketPart)
                                    || !string.IsNullOrEmpty(isinPart) && c.isin.Contains(isinPart)
                                    || !string.IsNullOrEmpty(assetClass) && c.assetClass.Contains(assetClass));

            /* К сожалению реализовать группировку у меня так и не получилось*/

            foreach (Asset asset in assets)
            {
                cList.Add(AssetToSimple(asset));
            }

            return cList;
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
