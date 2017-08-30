using mvc_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_CRUD.Controllers
{
    public class operationController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        // GET: operation
        public ActionResult Insert()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Insert(mvc_profile val)
        {
            Application1Entities obj = new Application1Entities();
            obj.mvc_profile.Add(val);
            obj.SaveChanges();
            return View();
        }

        public JsonResult check(string name)
        {
           Application1Entities obj = new Application1Entities();
            var res = obj.mvc_profile.Where(x => x.name == name).FirstOrDefault();
            bool val;
            if(res!=null)
            {
                val = false;
            }
            else
            {
                val = true;
            }
            return Json(val,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Detail()
        {
            List<mvc_profile> detail;
            using (var content = new Application1Entities())
            {
                detail = content.mvc_profile.ToList();
            }
            return View(detail);
        }

        [HttpGet]
        public ActionResult Update()
        {
           
     
            return View();
        }

        [HttpPost]
        public ActionResult Update(mvc_profile val)
        {
            Application1Entities obj = new Application1Entities();
            mvc_profile uval = obj.mvc_profile.Where(x => x.id == (val.id)).FirstOrDefault();
            uval.name = val.name;
            uval.password = val.password;
            obj.SaveChanges();
            return View();
        }


        [HttpGet]
        public ActionResult Delete(mvc_profile val)
        {
            Application1Entities obj = new Application1Entities();
            mvc_profile uval = obj.mvc_profile.Where(x => x.id == (val.id + 1)).FirstOrDefault();
            obj.mvc_profile.Remove(uval);
            obj.SaveChanges();
            return RedirectToAction("Detail");
        }
    }
}