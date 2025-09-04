using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharpAPI {

    /// <summary>
    /// A collection of moves in hitorical order.
    /// Moves are distinct ( cannot be repeated ).
    /// Paths can be non-linear.
    /// </summary>
    abstract public class SearchPath : List<SearchMoveIF> { 
        
        abstract public string ToDisplay(  bool flat = false  );

    }

}
