using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideas4AppsHub.Data;
using Ideas4AppsHub.Domain;

namespace Ideas4AppsHub.Repositories
{
    public class BusinessRepository
    {
        private Business CreateDomainBusiness(business bus)
        {
            var business = new Business()
                {
                    Active = bus.active,
                    BusinessHours = bus.business_hours,
                    Category = bus.category,
                    Description = bus.description,
                    Id = bus.id,
                    LastUpdate = bus.last_update,
                    Name = bus.name,
                    Photo = new Photo()
                    {
                        //bus.photo,
                    },
                    Status = (Status)Enum.Parse(typeof(Status), bus.status),
                    Tags = bus.tags,
                    TelephoneNumber = bus.telephone_number,
                    WebUrl = bus.weburl,
                    Address = new Address()
                    {
                        Address1 = bus.address1,
                        Address2 = bus.address2,
                        Address3 = bus.address3,
                        PostalCode = bus.postal_code
                    },
                    GPS = new GPS()
                };
            business.GPS.ConvertToLongitudeAndLatitude(bus.gps);
            return business;
        }
        public List<Business> GetAllBusiness()
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var dataBusinesses = (from bus in entityModel.businesses
                                        select bus).ToList();
                var domainBusinesses = new List<Business>();
                foreach (var dataBusiness in dataBusinesses)
                    domainBusinesses.Add(CreateDomainBusiness(dataBusiness));
                return domainBusinesses;
            }
        }
        public Business GetBusinessById(int id)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var dataBusiness = (from bus in entityModel.businesses
                                    where bus.id == id
                                    select bus).FirstOrDefault();
                return CreateDomainBusiness(dataBusiness);
            }
        }

        public int AddOrUpdateBusiness(Business business)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var existingBusinessCount = entityModel.businesses.Count(bus => bus.id == business.Id);
                if (existingBusinessCount > 0)
                    return UpdateBusiness(business);
                else
                    return AddBusiness(business);
            }
        }

        public int AddBusiness(Business business)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var dataBusiness = new Ideas4AppsHub.Data.business()
                {
                    active = business.Active,
                    business_hours = business.BusinessHours,
                    category = business.Category.ToString(),
                    description = business.Description,
                    last_update = DateTime.Now,
                    name = business.Name,
                    //photo = business.Photo,
                    status = business.Status.ToString(),
                    tags = business.Tags,
                    telephone_number = business.TelephoneNumber,
                    weburl = business.WebUrl,
                    address1 = business.Address.Address1,
                    address2 = business.Address.Address2,
                    address3 = business.Address.Address3,
                    postal_code = business.Address.PostalCode,
                    gps = business.GPS.Value

                };
                entityModel.businesses.Add(dataBusiness);

                if (entityModel.SaveChanges() > 0)
                    return dataBusiness.id;
                return 0;
            }
        }

        public int UpdateBusiness(Business business)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var currentBusiness = (from bus in entityModel.businesses
                                       where bus.id == business.Id
                                       select bus).FirstOrDefault();
                currentBusiness.active = business.Active;
                currentBusiness.business_hours = business.BusinessHours;
                currentBusiness.category = business.Category.ToString();
                currentBusiness.description = business.Description;
                currentBusiness.id = business.Id;
                currentBusiness.last_update = DateTime.Now;
                currentBusiness.name = business.Name;
                //currentBusiness.photo = business.Photo;
                currentBusiness.status = business.Status.ToString();
                currentBusiness.address1 = business.Address.Address1;
                currentBusiness.address2 = business.Address.Address2;
                currentBusiness.address3 = business.Address.Address3;
                currentBusiness.postal_code = business.Address.PostalCode;
                currentBusiness.tags = business.Tags;
                currentBusiness.telephone_number = business.TelephoneNumber;
                currentBusiness.weburl = business.WebUrl;
                currentBusiness.gps = business.GPS.Value;
                if (entityModel.SaveChanges() > 0)
                    return currentBusiness.id;
                return -1;
            }
        }

        public bool RemoveBusiness(Business business)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var dataBusiness = (from bus in entityModel.businesses
                                    where bus.id == business.Id
                                    select bus).FirstOrDefault();
                if (dataBusiness == null)
                    return false;
                entityModel.businesses.Remove(dataBusiness);
                if (entityModel.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
    }
}
