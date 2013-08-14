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
            return new Business()
                {
                    Active = bus.active,
                    BusinessHours = bus.business_hours,
                    Category = new Category()
                    {
                        //bus.category
                    },
                    Description = bus.description,
                    Id = bus.id,
                    LastUpdate = bus.last_update,
                    Name = bus.name,
                    Photo = new Photo()
                    {
                        //bus.photo,
                    },
                    Status = new Status()
                    {
                        //bus.status,
                    },
                    Tags = bus.tags,
                    TelephoneNumber = bus.telephone_number,
                    WebUrl = bus.weburl
                };
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

        public bool AddOrUpdateBusiness(Business business)
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

        public bool AddBusiness(Business business)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var dataBusiness = new Ideas4AppsHub.Data.business()
                {
                    active = business.Active,
                    business_hours = business.BusinessHours,
                    //category = business.Category,
                    description = business.Description,
                    last_update = business.LastUpdate,
                    name = business.Name,
                    //photo = business.Photo,
                    //status = business.Status,
                    tags = business.Tags,
                    telephone_number = business.TelephoneNumber,
                    weburl = business.WebUrl
                };
                entityModel.businesses.Add(dataBusiness);
                if (entityModel.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public bool UpdateBusiness(Business business)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var currentBusiness = (from bus in entityModel.businesses
                                       where bus.id == business.Id
                                       select bus).FirstOrDefault();
                currentBusiness.active = business.Active;
                currentBusiness.business_hours = business.BusinessHours;
                //currentBusiness.category = business.Category;
                currentBusiness.description = business.Description;
                currentBusiness.id = business.Id;
                currentBusiness.last_update = business.LastUpdate;
                currentBusiness.name = business.Name;
                //currentBusiness.photo = business.Photo;
                currentBusiness.status = business.Status.ToString();
                currentBusiness.tags = business.Tags;
                currentBusiness.telephone_number = business.TelephoneNumber;
                currentBusiness.weburl = business.WebUrl;
                if (entityModel.SaveChanges() > 0)
                    return true;
                return false;
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
