using Ideas4AppsHub.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas4AppsHub.Test
{
    [TestFixture]

    public class Tests
    {
        [Test]
        public void Can_create_appEntity()
        {
            var appEntity = new AppEntity()
            {
                Id = 1,
                TelephoneNumber = "018 932783 89",
                Name = "Apps4Everyone",
                Description = "First App",
                LastUpdate = DateTime.Now,
                Status = new Status()
            };

            Assert.That(appEntity, Is.Not.Null);
        }

        [Test]
        public void Can_create_businessAppEntity()
        {
            var business = new Business()
            {
                BusinessHours = "08:00 - 17:00",
                Name = "KFC",
                Tags = "Chicken|Fast Foods|Drive Thru",
                WebUrl = "http://www.kfc.co.za",
                Address = new Address(),
                Photo = new Photo(),
                GPS = new GPS(),
                Category = new Category(),
                Status = Status.New,
                Active = true
            };

            Assert.That(business, Is.Not.Null);        
            

        }





    }
}
