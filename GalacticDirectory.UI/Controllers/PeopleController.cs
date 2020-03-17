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
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using GalacticDirectory.UI.Data;

namespace GalacticDirectory.UI.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly StarWarDBContext _SWDBContext;
        private readonly IRepository<DAL.EFModels.PeopleModel> _reppm;
        private readonly ILogger<PeopleController> _logger;
        DAL.EFModels.PeopleModel _pm;
        private List<Film> _Films;
        //private string BaseUri="/api/people/";
        //private string Uri = string.Empty;
        private List<Models.PeopleModel> _PeopleDetails;
        //private static int TotalPeopleCount;
        private int pageSize=10;
        private int pageNumber=1;
        private static bool PostBack = false;
        


        public PeopleController(ILogger<PeopleController> logger, IHttpClientFactory httpClientFactory, StarWarDBContext SWDBContext)
        {
            _logger = logger; 
            _SWDBContext = SWDBContext;
            _reppm = new Repository<DAL.EFModels.PeopleModel>(_SWDBContext);
            _pm = new DAL.EFModels.PeopleModel();
             _Films = new List<Film>();
            _httpClientFactory = httpClientFactory;
            _PeopleDetails = new List<Models.PeopleModel>();
           
        }
        // GET: People
        [ResponseCache(CacheProfileName = "default")]//cache not working as expected need some investigation into it.
        public async Task<IActionResult> Index(int? page)
        {
            
            // var model=await GetPeopleDetails();       
            if (!PostBack && page ==null) {
            _PeopleDetails = await new GalacticAPIHelper(_httpClientFactory, _SWDBContext).GetPeopleDetails();
            foreach(var peo in _PeopleDetails)
            {
                for (int i = 0; i <= peo.Films.Length - 1; i++)
                {
                    _Films.Add(new Film(i + 1, peo.Films[i]));

                }
            }
            
            new BindEntityToEFModel(_PeopleDetails, _Films, _SWDBContext);// data in the table is gettting duplicated need some investigation to fix it.
            }
            pageNumber = (page ?? 1);      
            return View(_reppm.List().ToPagedList(pageNumber, pageSize));
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
            return View(_pm);
        }
        [HttpPost]
        public ActionResult EditPeople(DAL.EFModels.PeopleModel pm)
        {
            _reppm.Update(pm);
            PostBack = true;
            return RedirectToAction(nameof(Index));
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
            _pm = _reppm.GetById(id);
            return View(_pm);
        }

        [HttpPost]
        public ActionResult DeletePeople(DAL.EFModels.PeopleModel pm)
        {
            _reppm.Delete(pm);//delete throwing identity column errors...still need to fix it..
            PostBack = true;
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}