using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetInfoFromProcedure.Context;
using GetInfoFromProcedure.Model;
using GetInfoFromProcedure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GetInfoFromProcedure.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ElectionsDbContext _dbContext;

        [BindProperty(SupportsGet = true)]
        public string RegionCode { get; set; }
        public string CommunityCode { get; set; }
        public string SubDistrictCode { get; set; }

        public string regionCode;
        public string communityCode;
        public string subDistrictCode;
        

        public SelectList RegionList { get; set; }

        public ParlamentaryElection Input { get; set; }
        public IndexModel(ILogger<IndexModel> logger,
                          ElectionsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            Input = new ParlamentaryElection();
        }

        public ParlamentaryElection GetParlamentaryElection(int elID,string regCod,string comCod,int subId)
        {
            var parameters = new[] {
                new SqlParameter("@electionID", elID),
                new SqlParameter("@regionCode",regCod),
                new SqlParameter("@communityCode",comCod),
                new SqlParameter("@subdistinctID",subId),
            };

            var parlamentaryElectionQuery = _dbContext.ParlamentaryElectionDB
                .FromSqlRaw("Execute cec.GetParliamentaryElectiveResultsByElectionId @electionID,@regionCode,@communityCode,@subdistinctID", parameters).AsEnumerable();
           return parlamentaryElectionQuery.FirstOrDefault();
        }


        public List<CandidateParty> GetCandidateParty(int elID, string regCod, string comCod, int subId)
        {
            var parameters = new[] {
                new SqlParameter("@electionID", elID),
                new SqlParameter("@regionCode",regCod),
                new SqlParameter("@communityCode",comCod),
                new SqlParameter("@subdistinctID",subId),
            };

            var candidatePartyQuery = _dbContext.CandidatePartyDB
                .FromSqlRaw("Execute cec.GetParliamentaryCandidateInfoAndZoneResults @electionID,@regionCode,@communityCode,@subdistinctID", parameters).AsEnumerable();
            return candidatePartyQuery.ToList();
        }

        public void OnGet()
        {
            
            var list1 = GetCandidateParty(27576, "", "", 0);

            Input = GetParlamentaryElection(27576, "", "", 0);
            ////////////////////////////////////////////////
            var regionListQuery = _dbContext.RegionDB
               .FromSqlRaw("Execute cec.GetRegions").AsEnumerable();
            var regionList = regionListQuery.ToList();

            RegionList = new SelectList(regionList, nameof(Region.RegionCode), nameof(Region.Name));

        }

        public JsonResult OnGetCommunities(string regionCode)
        {
            Input = GetParlamentaryElection(27576, regionCode, "", 0);

            SqlParameter parameter = new SqlParameter("@regionCode", regionCode);

            var communityListQuery = _dbContext.CommunityDB
                .FromSqlRaw("Execute cec.GetCommunitiesByRegion  @regionCode", parameter).AsEnumerable();
            var communities = communityListQuery.ToList();

            return new JsonResult(communities);
        }

        public JsonResult OnGetSubDistricts(string communityCode)
        {
            var electionId = 27576;
            var parameters = new[] {
                new SqlParameter("@communityCode", communityCode),
                new SqlParameter("@electionId",electionId),
            };
            var subDistrictsQuery = _dbContext.SubDistrictModelDB
                          .FromSqlRaw("Execute cec.GetSubDistrictsByCommunityCodeAndElectionId @communityCode , @electionId", parameters).AsEnumerable();
            var subDistricts = subDistrictsQuery.ToList();

            
            return new JsonResult(subDistricts);
        }

        

        public JsonResult OnGetFunctionsss(string subDistrictCode,string communityCode)
        {
            var regionCode="02";
            SqlParameter parameter = new SqlParameter("@regionCode", regionCode);

            var communityListQuery = _dbContext.CommunityDB
                .FromSqlRaw("Execute cec.GetCommunitiesByRegion  @regionCode", parameter).AsEnumerable();
            var communities = communityListQuery.ToList();

            return new JsonResult(communities);
        }

    }
}
