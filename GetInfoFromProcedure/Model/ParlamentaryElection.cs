using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetInfoFromProcedure.Model
{
    public class ParlamentaryElection
    {
        // Ընտրողների ցուցակներում ընդգրկված ընտրողների ընդհանուր թիվը
        public int BodyList { get; set; }

        //Քվեարկության օրն ընտրական տեղամասում կազմված ընտրողների լրացուցիչ ցուցակում ընտրողների ընդհանուր թիվը
        public int PrecinctList { get; set; }

        //Շրջիկ արկղով քվեարկող ընտրողների լրացուցիչ ցուցակում  ընտրողների ընդհանուր թիվը
        public int StationarList { get; set; }

        //Էլեկտրոնային եղանակով քվեարկության մասնակցած ընտրողների թիվը
        public int ElCountOfBody { get; set; }

        //Ընտրողների ընդհանուր թիվը
        public int CountOfBody { get; set; }

        //Քվեարկության մասնակիցների ընդհանուր թիվը 
        public int BodyCount { get; set; }

        //Տեղամասային ընտրական հանձնաժողովներին հատկացված ինքնասոսնձվող դրոշմանիշների ընդհանուր թիվը
        public int ElNum { get; set; }

        // Տեղամասային ընտրական հանձնաժողովներին հատկացված համարակալված կտրոնների ընդհանուր թիվը
        public int ElNum1 { get; set; }

        // Ընտրողներից ստացված տեխնիկական սարքավորմամբ տպված կտրոնների ընդհանուր թիվը
        public int ElecCardsEl { get; set; }

        // Ընտրողներից ստացված համարակալված քվեարկության կտրոնների ընդհանուր թիվը
        public int TotalEnvelopes { get; set; }

        //  Ընտրողներից ստացված կտրոնների ընդհանուր թիվը EnvelopesCount
        public int EnvelopesCount { get; set; }

        //  Չօգտագործված համարակալված կտրոնների ընդհանուր թիվը
        public int BadEnvelopes { get; set; }

        //  Չօգտագործված ինքնասոսնձվող դրոշմանիշերի ընդհանուր թիվը
        public int BadElecCards { get; set; }

        //  Անվավեր  քվեաթերթիկների թիվը
        public int NoElecCards { get; set; }

        // Անճշտությունների գումարային չափը
        public int NoRSize { get; set; }

        //private List<CandidateParty> _candidateParty;
        //private List<PecMember> _pecMembers; 
        //private List<SubDistrict>  _subDistricts;

        // Գրանցված թեկնածուներ (կուսակցություններ)
        //public List<CandidateParty> CandidateParties
        //{
        //    get => _candidateParty ?? (_candidateParty = new List<CandidateParty>());
        //    set => _candidateParty = value;
        //}

        // Տեղամասային հանձնաժողովի անդամներ
        //public List<PecMember> PecMembers
        //{
        //    get => _pecMembers ?? (_pecMembers = new List<PecMember>());
        //    set => _pecMembers = value;
        //}

        // Ընտրատեղամասեր
        //public List<SubDistrict> SubDistricts 
        //{
        //    get => _subDistricts ?? (_subDistricts = new List<SubDistrict>());
        //    set => _subDistricts = value;
        //}
    }
}
