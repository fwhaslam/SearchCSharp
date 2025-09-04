// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using SearchCSharpAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp {
    
    public interface SearchDriverIF {

        public SearchResults Results { get; set; }

        /// <summary>
        /// Perform search.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="limit">How many solutions to find; set to ZERO to find ALL solutions.</param>
        /// <param name="best">Only return the SHORTEST solutions.</param>
        public void Perform( SearchDomainIF domain, int limit, bool best );

    }
}
