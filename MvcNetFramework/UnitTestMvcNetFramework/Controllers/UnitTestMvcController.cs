using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNetFramework.Controllers;
using MvcNetFramework.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTestMvcNetFramework.Controllers
{
    [TestClass]
    public class UnitTestMvcController
    {

        private DemoPerson _obj = new DemoPerson { Id = Guid.Parse("00000000-0000-0000-0001-000000000001"), Name = "un n1", Remark = "un r1" };
        [TestMethod]
        public void TestIndex()
        {
            var controller = new MvcController();

            var ret = controller.Index(sortOrder: "", currentFilter: "", searchString: "", page: null) as ViewResult;
            var retModel = ret.Model as IEnumerable<DemoPerson>;

            Assert.IsNotNull(ret);
            Assert.IsTrue(retModel.Any());
        }
        [TestMethod]
        public void TestCrud()
        {
            TestCreate();
            TestCreateSubmit();
            TestDetails();
            TestEdit();
            TestEditSubmit();
            TestDelete();
        }
        private void TestCreate()
        {
            var controller = new MvcController();

            var ret = controller.Create() as ViewResult;

            Assert.IsNotNull(ret);
        }
        private void TestCreateSubmit()
        {
            var controller = new MvcController();

            var act = controller.Create(demoPerson: _obj) as ViewResult;
            var ret = controller.Details(guid: _obj.Id) as ViewResult;
            var retModel = ret.Model as DemoPerson;

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, retModel.Id);
            Assert.AreEqual(_obj.Name, retModel.Name);
            Assert.AreEqual(_obj.Remark, retModel.Remark);
        }
        private void TestDetails()
        {
            var controller = new MvcController();

            var ret = controller.Details(guid: _obj.Id) as ViewResult;
            var retModel = ret.Model as DemoPerson;

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, retModel.Id);
            Assert.AreEqual(_obj.Name, retModel.Name);
            Assert.AreEqual(_obj.Remark, retModel.Remark);
        }
        private void TestEdit()
        {
            var controller = new MvcController();

            var ret = controller.Edit(guid: _obj.Id) as ViewResult;
            var retModel = ret.Model as DemoPerson;

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, retModel.Id);
            Assert.AreEqual(_obj.Name, retModel.Name);
            Assert.AreEqual(_obj.Remark, retModel.Remark);
        }
        private void TestEditSubmit()
        {
            var controller = new MvcController();
            var c1 = "changename1";
            var c2 = "changeremark1";
            _obj.Name = c1;
            _obj.Remark = c2;

            var act = controller.Edit(demoPerson: _obj) as ViewResult;
            var ret = controller.Details(guid: _obj.Id) as ViewResult;
            var retModel = ret.Model as DemoPerson;

            Assert.IsNotNull(ret);
            Assert.AreEqual(_obj.Id, retModel.Id);
            Assert.AreEqual(c1, retModel.Name);
            Assert.AreEqual(c2, retModel.Remark);
        }
        private void TestDelete()
        {
            var controller = new MvcController();

            var act = controller.Delete(guid: _obj.Id) as ViewResult;
            var ret = controller.Details(guid: _obj.Id) as ViewResult;
            var retModel = ret.Model as DemoPerson;

            Assert.IsNotNull(ret);
            Assert.AreEqual(Guid.Empty, retModel.Id);
            Assert.AreEqual(null, retModel.Name);
            Assert.AreEqual(null, retModel.Remark);
        }
    }
}
