using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ideas4AppsHub.Data;
using Ideas4AppsHub.Domain;

namespace Ideas4AppsHub.Repositories
{
    public class BusinessRepository
    {
        public void CreateBusiness(string name)
        {
            using (var model = new ideas4appsEntities())
            {
                var newBusiness = new Ideas4AppsHub.Data.business()
                {
                    name = name,
                };
                model.businesses.Add(newBusiness);
                model.SaveChanges();
            }
        }

    }
}
