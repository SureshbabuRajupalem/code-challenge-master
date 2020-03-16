using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalacticDirectory.UI.Models.Helpers
{
    interface IGalacticHelper
    {
       public Task<List<PeopleModel>>  GetPeopleDetails();
    }
}
