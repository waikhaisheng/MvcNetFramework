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
    public class UnitTestUnhandledException
    {
        [TestMethod]
        public void TestExceptionContext()
        {
            var exceptionContext = new ExceptionContext();

            var baseActionAttribute = new UnhandledException();
            baseActionAttribute.OnException(exceptionContext);

        }
    }
}
