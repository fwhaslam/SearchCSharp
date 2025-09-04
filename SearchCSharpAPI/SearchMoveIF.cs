using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharpAPI {

    public interface SearchMoveIF {
    
        public SearchStateIF Before {  get; }

        public SearchStateIF After {  get; }

        public string ToDisplay( bool flat = false );

    }

}
