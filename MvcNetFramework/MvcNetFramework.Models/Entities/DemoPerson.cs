using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcNetFramework.Models.Entities
{
    public class DemoPerson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
