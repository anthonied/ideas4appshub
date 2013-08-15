using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ideas4AppsHub.Domain;
using Ideas4AppsHub.Repositories;
using NUnit.Framework;

namespace Ideas4AppsHub.Test
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void BusinessesCanBeRetrievedFromDB()
        {
            var businesses = new BusinessRepository().GetAllBusiness();
            Assert.That(businesses.Count, Is.GreaterThan(0));
        }
        [Test]
        public void SingleBusinessCanBeRetrievedFromDB(int id = 1)
        {
            var business = new BusinessRepository().GetBusinessById(id);
            Assert.That(business, Is.Not.Null);
        }
        [Test]
        public void CanAddBusinessToDB()
        {
            var business = new Business()
            {
                Active = true,
                Address = new Address(),
                BusinessHours = "Someoaeu",
                Category = new Category(),
                Description = "aoeuaoeu",
                GPS = new GPS(),
                LastUpdate = DateTime.Now,
                Photo = new Photo(),
                Status = Domain.Status.New,
                Tags = "aoeu",
                TelephoneNumber = "aoeu",
                WebUrl = "oaeu",
                Name = "Johnny Crashy",
            };
            var idAdded = new BusinessRepository().AddOrUpdateBusiness(business);
            Assert.That(idAdded, Is.Not.EqualTo(-1));
        }
        [Test]
        public void CanUpdateBusinessFromDB()
        {
            var business = new Business()
            {
                Active = true,
                Address = new Address(),
                BusinessHours = "Someoaeu",
                Category = new Category(),
                Description = "aoeuaoeu",
                GPS = new GPS(),
                LastUpdate = DateTime.Now,
                Photo = new Photo(),
                Status = Domain.Status.New,
                Tags = "aoeu",
                TelephoneNumber = "aoeu",
                WebUrl = "oaeu",
                Name = "Johnny Crashy 2",
            };
            var idAdded = new BusinessRepository().AddOrUpdateBusiness(business);
            business = new Business()
            {
                Id  = 2,
                Active = true,
                Address = new Address(),
                BusinessHours = "Someoaeu",
                Category = new Category(),
                Description = "aoeuaoeu",
                GPS = new GPS(),
                LastUpdate = DateTime.Now,
                Photo = new Photo(),
                Status = Domain.Status.New,
                Tags = "aoeu",
                TelephoneNumber = "aoeu",
                WebUrl = "oaeu",
                Name = "Johnny Crashy 3",
            };
            var idUpdated = new BusinessRepository().AddOrUpdateBusiness(business);
            Assert.That(idUpdated, Is.Not.EqualTo(-1));
        }
        [Test]
        public void CanRemoveBusinessFromDB()
        {
            var business = new Business()
            {
                Active = true,
                Address = new Address(),
                BusinessHours = "Someoaeu",
                Category = new Category(),
                Description = "aoeuaoeu",
                GPS = new GPS(),
                LastUpdate = DateTime.Now,
                Photo = new Photo(),
                Status = Domain.Status.New,
                Tags = "aoeu",
                TelephoneNumber = "aoeu",
                WebUrl = "oaeu",
                Name = "Johnny Crashy 3",
            };
            bool removed = new BusinessRepository().RemoveBusiness(business);
            Assert.That(removed, Is.True);
        }
    }
}
