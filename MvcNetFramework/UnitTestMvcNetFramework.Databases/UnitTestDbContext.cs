using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNetFramework.Databases;
using MvcNetFramework.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestMvcNetFramework.Databases
{
    [TestClass]
    public class UnitTestDbContext
    {
        private DemoPerson _obj = new DemoPerson { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "un n db", Remark = "un r db", Created = DateTime.Now, Updated = DateTime.Now };
        [TestMethod]
        public void TestGetDemoPersonList()
        {
            var dbContext = new DbContext();

            var ret = dbContext.GetDemoPersonList();

            Assert.IsNotNull(ret);
        }
        [TestMethod]
        public void TestCrud()
        {
            TestAddDemoPerson();
            TestGetDemoPersonById();
            TestUpdateDemoPerson();
            TestDeleteDemoPerson();
        }
        private void TestAddDemoPerson()
        {
            var dbContext = new DbContext();

            var ret = dbContext.AddDemoPerson(id: _obj.Id, name: _obj.Name, remark: _obj.Remark, created: _obj.Created, updated: _obj.Updated);

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, ret.Id);
            Assert.AreEqual(_obj.Name, ret.Name);
            Assert.AreEqual(_obj.Remark, ret.Remark);
            Assert.AreEqual(_obj.Created, ret.Created);
            Assert.AreEqual(_obj.Updated, ret.Updated);
        }
        private void TestGetDemoPersonById()
        {
            var dbContext = new DbContext();

            var ret = dbContext.GetDemoPersonById(id: _obj.Id);

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, ret.Id);
            Assert.AreEqual(_obj.Name, ret.Name);
            Assert.AreEqual(_obj.Remark, ret.Remark);
            Assert.IsTrue(ret.Created > DateTime.MinValue);
            Assert.IsTrue(ret.Updated > DateTime.MinValue);
        }
        private void TestUpdateDemoPerson()
        {
            var dbContext = new DbContext();
            var c1 = "changename1";
            var c2 = "changeremark1";
            var c3 = DateTime.Now;
            _obj.Name = c1;
            _obj.Remark = c2;
            _obj.Updated = c3;

            var ret = dbContext.UpdateDemoPerson(id: _obj.Id, name: _obj.Name, remark: _obj.Remark, updated: _obj.Updated);

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, ret.Id);
            Assert.AreEqual(c1, ret.Name);
            Assert.AreEqual(c2, ret.Remark);
            Assert.IsTrue(ret.Created > DateTime.MinValue);
            Assert.AreEqual(c3.Day, ret.Updated.Day);
            Assert.AreEqual(c3.Second, ret.Updated.Second);
        }

        private void TestDeleteDemoPerson()
        {
            var dbContext = new DbContext();

            var ret = dbContext.DeleteDemoPerson(id: _obj.Id);

            Assert.IsNotNull(ret);
        }
    }
}
