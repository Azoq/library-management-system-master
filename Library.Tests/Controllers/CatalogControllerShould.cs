using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Library.Data;
using Library.Data.Models;
using Library.Web.Controllers;
using Library.Web.Models.Catalog;
using Library.Web.Models.CheckoutModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Library.Tests.Controllers
{
    [TestFixture]
    public class CatalogControllerShould
    {
        private static IEnumerable<ProfilingAsset> GetAllAssets()
        {
            return new List<ProfilingAsset>
            {
                new Profiling
                {
                    Title = "Orlando",
                    Author = "Virginia Woolf",
                    ImageUrl = "foo",
                },
            };
        }
    }
}