using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcNetFramework.Service.Database.Services;
using MvcNetFramework.Models.Entities;

namespace UnitTestMvcNetFramework.Services.Database.Services
{
    [TestClass]
    public class UnitTestDbService
    {
        private DemoPerson _obj = new DemoPerson { Id = Guid.Parse("00000000-0000-0001-0001-000000000001"), Name = "un n serv", Remark = "un r serv" };
        [TestMethod]
        public void TestMethod1()
        {
            var dbService = new DbService();

            var ret = dbService.GetDemoPersonList();

            Assert.IsNotNull(ret);
        }

        [TestMethod]
        public void TestCrud()
        {
            TestAddDemoPersonById();
            TestGetDemoPersonById();
            TestUpdateDemoPersonById();
            TestDeleteDemoPersonById();
        }
        private void TestAddDemoPersonById()
        {
            var dbService = new DbService();

            var ret = dbService.AddDemoPersonById(guid: _obj.Id, name: _obj.Name, remark: _obj.Remark);

            Assert.IsNotNull(ret);
        }
        private void TestGetDemoPersonById()
        {
            var dbService = new DbService();

            var ret = dbService.GetDemoPersonById(guid: _obj.Id);

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, ret.Id);
            Assert.AreEqual(_obj.Name, ret.Name);
            Assert.AreEqual(_obj.Remark, ret.Remark);
        }
        private void TestUpdateDemoPersonById()
        {
            var dbService = new DbService();
            var c1 = "changename1";
            var c2 = "changeremark1";
            _obj.Name = c1;
            _obj.Remark = c2;

            var ret = dbService.UpdateDemoPersonById(id: _obj.Id, name: _obj.Name, remark: _obj.Remark);

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, ret.Id);
            Assert.AreEqual(c1, ret.Name);
            Assert.AreEqual(c2, ret.Remark);
        }
        private void TestDeleteDemoPersonById()
        {
            var dbService = new DbService();

            var act = dbService.DeleteDemoPersonById(id: _obj.Id);
            var ret = dbService.GetDemoPersonById(guid: _obj.Id);

            Assert.IsNotNull(ret);
            Assert.AreEqual(Guid.Empty, ret.Id);
            Assert.AreEqual(null, ret.Name);
            Assert.AreEqual(null, ret.Remark);
        }
    }
}
