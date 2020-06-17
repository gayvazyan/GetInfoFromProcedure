using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInfoFromProcedure.Context;
using GetInfoFromProcedure.Model;
using GetInfoFromProcedure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GetInfoFromProcedure.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ElectionsDbContext _dbContext;


        public int typeID { get; set; }
        public string regionCode { get; set; }
        public string communityCode { get; set; }
        public int subdistinctID { get; set; }


        public IndexModel(ILogger<IndexModel> logger,
                          ElectionsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public void OnGet()
        {
            typeID = 9;
            regionCode = "02";
            communityCode = "28";
            subdistinctID = 72719;
            //SqlParameter parameterTypeID = new SqlParameter("@typeID", typeID);
            //SqlParameter parameterRegionCode = new SqlParameter( "@regionCode",regionCode);

            var parameters = new[] {
            new SqlParameter("@typeID", typeID),
            new SqlParameter("@regionCode",regionCode),
            new SqlParameter("@communityCode",communityCode),
            new SqlParameter("@subdistinctID",subdistinctID),
        };

            var ElectionListQuery = _dbContext.ParlamentaryElectionDB
                .FromSqlRaw("Execute cec.GetElectiveResultsFiltered @typeID , @regionCode, @communityCode, @subdistinctID", parameters).AsEnumerable();
            var ElectionList = ElectionListQuery.FirstOrDefault();
        }

    }
}
