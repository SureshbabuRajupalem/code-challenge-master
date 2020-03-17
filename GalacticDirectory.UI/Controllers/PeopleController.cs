using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GalacticDirectory.DAL.Data;
using GalacticDirectory.UI.Models;
using GalacticDirectory.UI.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
using GalacticDirectory.DAL.EFModels;
using GalacticDirectory.DAL.Services;

namespace GalacticDirectory.UI.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly StarWarDBContext _SWDBContext;
        private readonly IRepository<DAL.EFModels.PeopleModel> _reppm;
        DAL.EFModels.PeopleModel _pm;
        //private string BaseUri="/api/people/";
        //private string Uri = string.Empty;
        private List<Models.PeopleModel> _PeopleDetails;
        //private static int TotalPeopleCount;
        private int pageSize=10;
        private int pageNumber;


        public PeopleController(IHttpClientFactory httpClientFactory, StarWarDBContext SWDBContext)
        {
            _SWDBContext = SWDBContext;
            _reppm = new Repository<DAL.EFModels.PeopleModel>(_SWDBContext);
            _pm = new DAL.EFModels.PeopleModel();
            _httpClientFactory = httpClientFactory;
            _PeopleDetails = new List<Models.PeopleModel>();

        }
        // GET: People
        public async Task<IActionResult> Index(int? page)
        {
            
            // var model=await GetPeopleDetails();
            _PeopleDetails=await new GalacticAPIHelper(_httpClientFactory, _SWDBContext).GetPeopleDetails();
            pageNumber = (page ?? 1);
            return View(_PeopleDetails.ToPagedList(pageNumber, pageSize));
        }
        

        // GET: People/Details/5
        public ActionResult GetPeopleDetailsByID(int Id)
        {

            return View();
        }

        // GET: People/Create
        public ActionResult CreatePeople()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult EditPeople(int id)
        {
           _pm=_reppm.GetById(id);
            return View();
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult DeletePeople(int id)
        {
            return View();
        }

        // POST: People/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}