using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GalacticDirectory.UI.Models;
using GalacticDirectory.UI.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;


namespace GalacticDirectory.UI.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private string BaseUri="/api/people/";
        //private string Uri = string.Empty;
        private List<PeopleModel> _PeopleDetails;
        //private static int TotalPeopleCount;
        private int pageSize=10;
        private int pageNumber;


        public PeopleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _PeopleDetails = new List<PeopleModel>();

        }
        // GET: People
        public async Task<IActionResult> Index(int? page)
        {
            
            // var model=await GetPeopleDetails();
            _PeopleDetails=await new GalacticAPIHelper(_httpClientFactory).GetPeopleDetails();
            pageNumber = (page ?? 1);
            return View(_PeopleDetails.ToPagedList(pageNumber, pageSize));
        }
        // GET: People/Details/5
        //private async Task<List<PeopleModel>> GetPeopleDetails()
        //{
        //    // Get an instance of HttpClient from the factpry that we registered
        //    // in Startup.cs
        //    var client = _httpClientFactory.CreateClient("API Client");
        //    // Call the API & wait for response. 
        //    // If the API call fails, call it again according to the re-try policy
        //    // specified in Startup.cs
        //    if (string.IsNullOrEmpty(Uri)) { Uri = BaseUri; }           
              
        //       var  result = await client.GetAsync(Uri);        
                          
               

        //    //if (Uri.IndexOf("?") > 0)
        //    //    Uri = Uri.Substring(0, Uri.IndexOf("?"));

        //    if (result.IsSuccessStatusCode)
        //    {
        //        // Read all of the response and deserialise it into an instace of
        //        // PeopleModel class
        //        var content = await result.Content.ReadAsStringAsync();
        //        PeopleModelRoot rootModel = JsonConvert.DeserializeObject<PeopleModelRoot>(content);
        //        if (string.IsNullOrEmpty(rootModel.previous)) TotalPeopleCount = rootModel.count;
        //        //   for(int i = TotalPeopleCount; i > rootModel.results.Count(); i -= rootModel.results.Count())
        //        //  {
        //        while (TotalPeopleCount > 0)
        //        {
                 
        //            if (!string.IsNullOrEmpty(rootModel.next) && rootModel.next.IndexOf("?") > 0)
        //            {
        //                //var ct = rootModel.next.IndexOf("?");
        //                //var lnt = rootModel.next.Length;        
        //                //var substr= rootModel.next.Substring(ct, lnt-ct);
        //                Uri = string.Empty;
        //                Uri = BaseUri + rootModel.next.Substring(rootModel.next.IndexOf("?"), rootModel.next.Length - rootModel.next.IndexOf("?"));

        //            }
        //            foreach (var res in rootModel.results)
        //            {

        //                string SubUrl = res.Url.Substring(res.Url.IndexOf("people/"), res.Url.Length - res.Url.IndexOf("people/"));
        //                string PeopleID = SubUrl.Substring(SubUrl.IndexOf("/") + 1, SubUrl.LastIndexOf("/") - SubUrl.IndexOf("/") - 1);
        //               int p_ID =Convert.ToInt32(PeopleID);
                        
        //            }
        //            TotalPeopleCount -= rootModel.results.Count();
        //            pageSize = rootModel.results.ToList<PeopleModel>().Count >= pageSize 
        //                                                ? rootModel.results.ToList<PeopleModel>().Count: pageSize;
        //            _PeopleDetails.AddRange(rootModel.results.ToList<PeopleModel>());
        //            // TotalPeopleCount -= rootModel.results.Count();
        //            await GetPeopleDetails();                 
        //           // Uri = string.Empty;
        //        } 
        //            return _PeopleDetails;
        //}
        //return null;
        //}

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