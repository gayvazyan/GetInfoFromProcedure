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

        public ParlamentaryElection GetParlamentaryElection(int elID, string regCod, string comCod, int subId)
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

        public CombineTestModel GetCombineTestList(int electionId)
        {
            CombineTestModel combineTestModel = new CombineTestModel();
            List<Test> ListTest = new List<Test>();
            int ElectionId = 0;
            var Date = DateTime.Now;
            //using (var ctx = new ElectionsDbContext())
            //{
            using (var cnn = _dbContext.Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = "dbo.test";
                cmm.Connection = cnn;
                cmm.Parameters.Add(new SqlParameter("@electionID", electionId));
                cnn.Open();
                using (var reader = cmm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Test test = new Test()
                        {
                            Region = reader["Region"].ToString(),
                            Community = reader["Community"].ToString(),
                            DistrictId = int.Parse(reader["DistrictId"].ToString()),
                            FullName = reader["FullName"].ToString(),
                            SubDistrictCode = reader["SubDistrictCode"].ToString(),
                            Sertifcate = reader["Sertifcate"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            ShortName = reader["ShortName"].ToString(),
                            WorkPosition = reader["WorkPosition"].ToString(),

                        };
                        ListTest.Add(test);

                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        ElectionId = int.Parse(reader["ElectionId"].ToString());
                        Date = Convert.ToDateTime(reader["Date"].ToString());
                    }

                    combineTestModel.listTest = ListTest;
                    combineTestModel.ElectionId = ElectionId;
                    combineTestModel.Date = Date;
                }
            }
            return combineTestModel;
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
            var combineList = GetCombineTestList(27576);

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

        public JsonResult OnGetFunctionsss(string subDistrictCode, string communityCode)
        {
            var regionCode = "02";
            SqlParameter parameter = new SqlParameter("@regionCode", regionCode);

            var communityListQuery = _dbContext.CommunityDB
                .FromSqlRaw("Execute cec.GetCommunitiesByRegion  @regionCode", parameter).AsEnumerable();
            var communities = communityListQuery.ToList();

            return new JsonResult(communities);
        }

    }
}
