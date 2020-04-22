using System.Linq;
using Library.Data;
using Library.Web.Models.Catalog;
using Library.Web.Models.CheckoutModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILibraryAssetService _assetsService;


        public CatalogController(ILibraryAssetService assetsService)
        {
            _assetsService = assetsService;
        }

        public IActionResult Index()
        {
            var assetModels = _assetsService.GetAll();

            var listingResult = assetModels
                .Select(a => new AssetIndexListingModel
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    Title = _assetsService.GetTitle(a.Id),
                    Type = _assetsService.GetType(a.Id),
                }).ToList();

            var model = new AssetIndexModel
            {
                Assets = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var asset = _assetsService.Get(id);

            var model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Type = _assetsService.GetType(id),
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
            };

            return View(model);
        }

        public IActionResult Kunde(int id)
        {
            var assetModels = _assetsService.GetAll();
            var listingResult = assetModels
                   .Select(a => new AssetIndexListingModel
                   {
                       Id = a.Id,
                       ImageUrl = a.ImageUrl,
                        Title = _assetsService.GetTitle(a.Id),
                       Type = _assetsService.GetType(a.Id),
                   }).ToList();

            var model = new AssetIndexModel
            {
                Assets = listingResult
            };
            return View(model);
        }

        public IActionResult Roller(int id)
        {
            var assetModels = _assetsService.GetAll();
            var listingResult = assetModels
                   .Select(a => new AssetIndexListingModel
                   {
                       Id = a.Id,
                       ImageUrl = a.ImageUrl,
                       Title = _assetsService.GetTitle(a.Id),
                       Type = _assetsService.GetType(a.Id),
                   }).ToList();

            var model = new AssetIndexModel
            {
                Assets = listingResult
            };
            return View(model);
        }
    }
}