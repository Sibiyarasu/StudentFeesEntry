using DataAccessLayer.Model;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFeesEntry.Controllers
{
    public class FeesController : Controller
    {
        StudentRepository obj;
        public FeesController()
        {
            obj = new StudentRepository();
        }
        // GET: FeesController
        public ActionResult List()
        {
            obj.GetStudentDetail();
            return View("List",obj.GetStudentDetail());
        }

        // GET: FeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeesController/Create
        public ActionResult Create()
        {
            var model = new StudentModel();
            return View("Create", model);
        }

        // POST: FeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.InsertDetails(collection);
                         return RedirectToAction(nameof(List));
                }
                else
                {
                   
                    return View("Create", collection);
                }
               

               
            }
            catch
            {
                return View();
            }
        }

        // GET: FeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var result =obj.selectid(id);
            
            
            return View("Edit", result);
        }

        // POST: FeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentModel collection)
        {
            try
            {
                obj.updatesp(collection);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
