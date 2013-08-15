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
                Status = Status.New,
                Active = true
            };

            Assert.That(business, Is.Not.Null);          
        }

        [Test]
        public void Can_convert_longitute_and_latitude_to_Value()
        {
            var business = new Business
            {
                GPS = new GPS
                {
                    Longitude = "18.580971",
                    Latitude = "4.602733"
                }
            };

            Assert.That(business.GPS.Value, Is.EqualTo("18.580971,4.602733"));
        }

        [Test]
        public void Can_convert_GPSValue_to_longitute_and_latitute()
        {
            var business = new Business()
            {
                GPS = new GPS()
            };

            business.GPS.ConvertToLongitudeAndLatitude("18.580971,4.602733");

            Assert.That(business.GPS.Longitude, Is.EqualTo("18.580971"));

        }




    }
}
