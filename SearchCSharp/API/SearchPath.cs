// Copyright (c) 2025 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp.API {

    /// <summary>
    /// A collection of moves in hitorical order.
    /// Moves are distinct ( cannot be repeated ).
    /// Paths can be non-linear.
    /// </summary>
    abstract public class SearchPath : List<SearchMoveIF> { 
        
        abstract public string ToDisplay(  bool flat = false  );

    }

}
