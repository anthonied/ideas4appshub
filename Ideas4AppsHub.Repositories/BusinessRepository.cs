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
        public List<Business> GetAllBusiness()
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var domainBusinesses = (from bus in entityModel.businesses
                                        select new Business()
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
                                        }).ToList();
                return domainBusinesses;
            }
        }
        public Business GetBusinessById(int id)
        {
            using (var entityModel = new ideas4appsEntities())
            {
                var domainBusiness = (from bus in entityModel.businesses
                                      where bus.id == id
                                      select new Business()
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
                                      }).FirstOrDefault();
                return domainBusiness;
            }
        }
    }
}
