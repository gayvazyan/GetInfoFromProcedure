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

        //  Անճշտությունների գումարային չափը
    }
}
