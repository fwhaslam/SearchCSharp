// Copyright (c) 2025 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using SearchCSharp.Drivers;
using SearchCSharp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp {

    public class SearchEngine {

        static public SearchEngine MakeBreadthFirstSearch( SearchDomainIF domain ) {
            return new SearchEngine() {
                Domain = domain,
                Driver = new BreadthFirstDriver()
            };
        }

        public SearchDomainIF Domain { get; init; }

        public SearchDriverIF Driver { get; init; }


        // diverse search goals

        public SearchResults FindFirst() {

            Driver.Perform( Domain, 1, false );

            return Driver.Results;

        }

        public SearchResults FindBest() {

            Driver.Perform( Domain, 0, true );

            Driver.Results.TrimToBest();

            return Driver.Results;

        }

        public SearchResults FindAll() {

            Driver.Perform( Domain, 0, false );

            return Driver.Results;

        }
    }
}
