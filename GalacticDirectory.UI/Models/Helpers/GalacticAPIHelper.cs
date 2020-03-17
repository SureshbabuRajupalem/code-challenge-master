using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GalacticDirectory.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GalacticDirectory.DAL;
using GalacticDirectory.UI.Data;
using GalacticDirectory.DAL.Data;

namespace GalacticDirectory.UI.Models.Helpers
{

    public class GalacticAPIHelper: IGalacticHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string BaseUri = "/api/people/";
        private string Uri = string.Empty;
        private List<PeopleModel> _PeopleDetails;
        private List<Film> _Films;
        //private List<Species> _Species;
       // private List<Starship> _Starship;
       // private List<Vehicle> _Vehicle;
        private static int TotalPeopleCount;
        private int pageSize = 0;
        private int p_ID;
        private BindEntityToEFModel _EntityToModel;
        private readonly StarWarDBContext _SWDBContext;
                          
        public GalacticAPIHelper()
        {
            
        }
        public GalacticAPIHelper(IHttpClientFactory httpClientFactory, StarWarDBContext SWDBContext)
        {
            _SWDBContext = SWDBContext;
            _httpClientFactory = httpClientFactory;
            _PeopleDetails = new List<PeopleModel>();
            _Films = new List<Film>();
         

        }
        public async Task<List<PeopleModel>> GetPeopleDetails()
        {
            // Get an instance of HttpClient from the factpry that we registered
            // in Startup.cs
            
            var client = _httpClientFactory.CreateClient("API Client");
          
            if (string.IsNullOrEmpty(Uri)) { Uri = BaseUri; }

            var result = await client.GetAsync(Uri);


            if (result.IsSuccessStatusCode)
            {
              
                var content = await result.Content.ReadAsStringAsync();
                PeopleModelRoot rootModel = JsonConvert.DeserializeObject<PeopleModelRoot>(content);
                if (string.IsNullOrEmpty(rootModel.previous)) TotalPeopleCount = rootModel.count;

                while (TotalPeopleCount > 0)
                {

                    if (!string.IsNullOrEmpty(rootModel.next) && rootModel.next.IndexOf("?") > 0)
                    {

                        Uri = string.Empty;
                        Uri = BaseUri + rootModel.next.Substring(rootModel.next.IndexOf("?"), rootModel.next.Length - rootModel.next.IndexOf("?"));

                    }
                    for (int res = 0; res <= rootModel.results.Length - 1; res++)
                    {

                        string SubUrl = rootModel.results[res].Url
                            .Substring(rootModel.results[res].Url.IndexOf("people/"), rootModel.results[res].Url.Length - rootModel.results[res].Url.IndexOf("people/"));
                        string PeopleID = SubUrl
                            .Substring(SubUrl.IndexOf("/") + 1, SubUrl.LastIndexOf("/") - SubUrl.IndexOf("/") - 1);

                        p_ID = Convert.ToInt32(PeopleID);

                        // rootModel.results[res].People_ID = p_ID;

                        for (int i = 0; i <= rootModel.results[res].Films.Length - 1; i++)
                        {
                            _Films.Add(new Film(i + 1, rootModel.results[res].Films[i]));//rootModel.results[res].People_ID,

                        }
                    }
                    TotalPeopleCount -= rootModel.results.Count();
                    pageSize = rootModel.results.ToList<PeopleModel>().Count >= pageSize
                                                        ? rootModel.results.ToList<PeopleModel>().Count : pageSize;
                    _PeopleDetails.AddRange(rootModel.results.ToList<PeopleModel>());
                    await GetPeopleDetails();
                }               
                return _PeopleDetails;            
            }
            else { 
                return null;
            }
           
        }
        //public void CacheToDB()
        //{
        //    _EntityToModel = new BindEntityToEFModel(_PeopleDetails, _Films, _SWDBContext);
        //}
    }
}
