using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        DataLayer dl = new DataLayer();
        Property obj1 = new Property();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllStudent()
        {
            obj1.action =2;
            obj1.dt = dl.GetAllRecord(obj1);
            return View(obj1);
        }
        
        public JsonResult InsertUpdateStudent(Property obj)
        {
            if(Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string Ifile = Path.Combine(Server.MapPath("~/Content/uimg"),file.FileName);
                file.SaveAs(Ifile);
                obj.picture = file.FileName;
            }
            obj.picture = null;
            obj.dt=dl.GetAllRecord(obj);
            if(obj.dt != null && obj.dt.Rows.Count>0)
            {
                obj.srno = obj.dt.Rows[0]["SR"].ToString();
            }
            return Json(obj.srno,JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetRecordForEdit(Property obj)
        {
            DataTable dt = dl.GetAllRecord(obj);
            if(dt.Rows.Count>0 && dt !=null)
            {
                obj.Username = dt.Rows[0]["username"].ToString();
                obj.Email = dt.Rows[0]["email"].ToString();
                obj.Password = dt.Rows[0]["password"].ToString();
                obj.DOB = dt.Rows[0]["dob"].ToString();
                obj.picture = ("..Content/Uimg"+ dt.Rows[0]["image"].ToString());
                obj.Gender = dt.Rows[0]["gender"].ToString();
                obj.User_id = Convert.ToInt32(dt.Rows[0]["usr_id"]);
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}