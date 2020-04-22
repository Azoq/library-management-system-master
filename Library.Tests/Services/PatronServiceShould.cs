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
    public class PatronServiceShould
    {
        private static IEnumerable<Patron> GetPatrons()
        {
            return new List<Patron>
            {
                new Patron
                {
                    Id = 1,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Telephone = "1234",
                    Address = "1 Main St",
                    DateOfBirth = new DateTime(1972, 01, 23)
                },

                new Patron
                {
                    Id = 2,
                    FirstName = "Jack",
                    LastName = "Smith",
                    Telephone = "233-4411",
                    Address = "Oak Drive",
                    DateOfBirth = new DateTime(1983, 07, 3)
                }
            };
        }

        [Test]
        public void Add_New_Patron()
        {
            var mockSet = new Mock<DbSet<Patron>>();
            var mockCtx = new Mock<LibraryDbContext>();

            mockCtx.Setup(c => c.Patrons).Returns(mockSet.Object);
            var sut = new PatronService(mockCtx.Object);

            sut.Add(new Patron());

            mockCtx.Verify(s => s.Add(It.IsAny<Patron>()), Times.Once());
            mockCtx.Verify(c => c.SaveChanges(), Times.Once());
        }

        [Test]
        public void Get_All_Patrons()
        {
            var patrons = GetPatrons().AsQueryable();

            var mockSet = new Mock<DbSet<Patron>>();
            mockSet.As<IQueryable<Patron>>().Setup(b => b.Provider).Returns(patrons.Provider);
            mockSet.As<IQueryable<Patron>>().Setup(b => b.Expression).Returns(patrons.Expression);
            mockSet.As<IQueryable<Patron>>().Setup(b => b.ElementType).Returns(patrons.ElementType);
            mockSet.As<IQueryable<Patron>>().Setup(b => b.GetEnumerator()).Returns(patrons.GetEnumerator);

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.Patrons).Returns(mockSet.Object);

            var sut = new PatronService(mockCtx.Object);
            var queryResult = sut.GetAll().ToList();

            queryResult.Should().AllBeOfType(typeof(Patron));
            queryResult.Should().HaveCount(2);
            queryResult.Should().Contain(a => a.FirstName == "Jane");
            queryResult.Should().Contain(a => a.FirstName == "Jack");
        }

        [Test]
        public void Get_Patron_By_Id()
        {
            var patrons = GetPatrons().AsQueryable();

            var mockSet = new Mock<DbSet<Patron>>();
            mockSet.As<IQueryable<Patron>>().Setup(b => b.Provider).Returns(patrons.Provider);
            mockSet.As<IQueryable<Patron>>().Setup(b => b.Expression).Returns(patrons.Expression);
            mockSet.As<IQueryable<Patron>>().Setup(b => b.ElementType).Returns(patrons.ElementType);
            mockSet.As<IQueryable<Patron>>().Setup(b => b.GetEnumerator()).Returns(patrons.GetEnumerator);

            var mockCtx = new Mock<LibraryDbContext>();
            mockCtx.Setup(c => c.Patrons).Returns(mockSet.Object);

            var sut = new PatronService(mockCtx.Object);
            var branch = sut.Get(1);

            branch.FirstName.Should().Be("Jane");
        }
    }
}