using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNetFramework.Filters;
using MvcNetFramework.Models.Entities;
using MvcNetFramework.Service.Database.Services;
using PagedList;

namespace MvcNetFramework.Controllers
{
    [BaseAction]
    [UnhandledException]
    public class MvcController : Controller
    {
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var res = new DbService().GetDemoPersonList();
            if (!String.IsNullOrEmpty(searchString))
            {
                res = res.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    res = res.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    res = res.OrderBy(s => s.Updated);
                    break;
                default:
                    res = res.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(res.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(Guid guid)
        {
            var res = new DbService().GetDemoPersonById(guid);
            return View(res);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DemoPerson demoPerson)
        {
            if (demoPerson.Id == Guid.Empty)
            {
                demoPerson.Id = Guid.NewGuid();
            }
            var res = new DbService().AddDemoPersonById(demoPerson.Id, demoPerson.Name, demoPerson.Remark);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(Guid guid)
        {
            var res = new DbService().GetDemoPersonById(guid); ;
            return View(res);
        }
        [HttpPost]
        public ActionResult Edit(DemoPerson demoPerson)
        {
            var res = new DbService().UpdateDemoPersonById(demoPerson.Id, demoPerson.Name, demoPerson.Remark);
            return RedirectToAction("Details", new { Guid = demoPerson.Id });
        }
        public ActionResult Delete(Guid guid)
        {
            var res = new DbService().DeleteDemoPersonById(guid);
            return View(guid);
        }
    }
}