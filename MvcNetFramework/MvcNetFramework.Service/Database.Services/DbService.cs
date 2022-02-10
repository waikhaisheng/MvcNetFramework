using MvcNetFramework.Databases;
using MvcNetFramework.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcNetFramework.Service.Database.Services
{
    public class DbService
    {
        private static DbContext _dbContext = new DbContext();

        #region demoPerson
        public IEnumerable<DemoPerson> GetDemoPersonList()
        {
            return _dbContext.GetDemoPersonList();
        }
        public DemoPerson GetDemoPersonById(Guid guid)
        {
            return _dbContext.GetDemoPersonById(guid);
        }
        public DemoPerson AddDemoPersonById(Guid guid, string name, string remark)
        {
            return _dbContext.AddDemoPerson(guid, name, remark, DateTime.Now, DateTime.Now);
        }
        public DemoPerson UpdateDemoPersonById(Guid id, string name, string remark)
        {
            return _dbContext.UpdateDemoPerson(id, name, remark, DateTime.Now);
        }
        public bool DeleteDemoPersonById(Guid id)
        {
            return _dbContext.DeleteDemoPerson(id);
        }
        #endregion
    }
}
