using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNetFramework.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTestMvcNetFramework.Filters
{
    [TestClass]
    public class UnitTestBaseActionAttribute
    {
        [TestMethod]
        public void TestOnActionExecuting()
        {
            var actionExecutingContext = new ActionExecutingContext();

            var baseActionAttribute = new BaseActionAttribute();
            baseActionAttribute.OnActionExecuting(actionExecutingContext);

        }
        [TestMethod]
        public void TestOnActionExecuted()
        {
            var actionExecutedContext = new ActionExecutedContext();

            var baseActionAttribute = new BaseActionAttribute();
            baseActionAttribute.OnActionExecuted(actionExecutedContext);

        }
        [TestMethod]
        public void TestOnResultExecuting()
        {
            var resultExecutingContext = new ResultExecutingContext();

            var baseActionAttribute = new BaseActionAttribute();
            baseActionAttribute.OnResultExecuting(resultExecutingContext);

        }
        [TestMethod]
        public void TestOnResultExecuted()
        {
            var RrsultExecutedContext = new ResultExecutedContext();

            var baseActionAttribute = new BaseActionAttribute();
            baseActionAttribute.OnResultExecuted(RrsultExecutedContext);

        }
    }
}
