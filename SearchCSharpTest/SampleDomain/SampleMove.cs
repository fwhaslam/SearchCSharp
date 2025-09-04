using SearchCSharpAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharpTest.SampleDomain {

    public class SampleMove : SearchMoveIF {

        public (string,string) Route { get; set; }

        public SearchStateIF? Before { get; set; }

        public SearchStateIF? After { get; set; }

        public string ToDisplay( bool flat = false ) {
            return "M"+Route;
        }

    }

}
