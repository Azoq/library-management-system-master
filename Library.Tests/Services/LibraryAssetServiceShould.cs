using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Library.Data;
using Library.Data.Models;
using Library.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Library.Tests.Services
{
    [TestFixture]
    public class LibraryAssetServiceShould
    {
        private static IEnumerable<ProfilingAsset> GetAssets()
        {
            return new List<ProfilingAsset>
            {
                new Profiling
                {
                    Id = 1223,
                    Title = "Infinite Jest",
                    Author = "DFW",
                    DeweyIndex = "WAL111"
                },

                new Profiling
                {
                    Id = -903,
                    Title = "Beyond the Bedroom Wall",
                    Location = new LibraryBranch {Id = 200},
                },
            };
        }

        private Mock<DbSet<ProfilingAsset>> BuildMock()
        {
            var assets = GetAssets().AsQueryable();
            var mockSet = new Mock<DbSet<ProfilingAsset>>();
            mockSet.As<IQueryable<ProfilingAsset>>().Setup(b => b.Provider).Returns(assets.Provider);
            mockSet.As<IQueryable<ProfilingAsset>>().Setup(b => b.Expression).Returns(assets.Expression);
            mockSet.As<IQueryable<ProfilingAsset>>().Setup(b => b.ElementType).Returns(assets.ElementType);
            mockSet.As<IQueryable<ProfilingAsset>>().Setup(b => b.GetEnumerator()).Returns(assets.GetEnumerator());
            return mockSet;
        }

        [Test]
        public void Add_New_Asset()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase("Add_asset_writes_to_database")
                .Options;

            using (var context = new LibraryDbContext(options))
            {
                var service = new LibraryAssetService(context);

                service.Add(new Profiling
                {
                    Id = -27
                });

                Assert.AreEqual(-27, context.LibraryAssets.Single().Id);
            }
        }

        [Test]
        public void Get_All_Assets()
        {
            var mockSet = BuildMock();
            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.LibraryAssets).Returns(mockSet.Object);

            var sut = new LibraryAssetService(mockCtx.Object);
            var queryResult = sut.GetAll().ToList();

            queryResult.Should().AllBeAssignableTo(typeof(ProfilingAsset));
            queryResult.Should().HaveCount(3);
            queryResult.Should().Contain(a => a.Title == "Infinite Jest");
        }

        [Test]
        public void Get_Asset_Title()
        {
            var mockSet = BuildMock();

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.LibraryAssets).Returns(mockSet.Object);

            var sut = new LibraryAssetService(mockCtx.Object);
            var queryResult = sut.GetTitle(234);
            queryResult.Should().Be("The Matrix");
        }
    
        // Add in functionality for other tasks as Get rest of Questions into the feed.
    
 
    }
}