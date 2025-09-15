// Copyright (c) 2025 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using SearchCSharp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp.Drivers {

    public class BreadthFirstDriver : SearchDriverIF {

        public SearchResults Results { get; set; } = new SearchResults();

        /// <summary>
        /// Find solutions.
        /// </summary>
        /// <param name="domain">Domain to be searched.</param>
        /// <param name="limit">How many solutions to find; set to ZERO to find ALL solutions.</param>
        public void Perform( SearchDomainIF domain, int limit, bool best ) {
           
            var queue = new Queue<(int,SearchStateIF)>();
            queue.Enqueue( (0, domain.Start) );
            int bestDepth = -1;

            while ( queue.Count>0 ) {

                var (depth,next) = queue.Dequeue();

                // skip solutions that are longer than the 'best' found
                if (best && bestDepth>=0 && depth>bestDepth) continue;

                // solution found
                if ( domain.IsDone( next )) {
                    Results.AddCompletedState( next  );
                    if ( limit>0 && Results.Count >= limit ) break;
                    bestDepth = depth;
                }
                // no solution, keep searching
                else {

                    depth = depth+1;
                    if (best && bestDepth>=0 && depth>bestDepth) continue;

                    var options = domain.Options( next );
                    foreach ( var option in options ) {
                        queue.Enqueue( (depth,option.After) );
                    }
                }

            }

            Results.Ready = true;

        }
    }
}
