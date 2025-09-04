using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharpAPI {

    public interface SearchStateIF {

        public SearchPath Path {  get; }

        public string ToDisplay( bool flat = false );

    }

}
