// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using SearchCSharpAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp {

    public class SearchResults {

        public bool Ready { get; set; } = false;

        public List<SearchStateIF> Completed { get; set; } = new List<SearchStateIF>();

        public int Count { get {  return Completed.Count; } }

        public void AddCompletedState( SearchStateIF state ) {

            Completed.Add( state );

        }

        /// <summary>
        /// Find shortest solutions, discard all that are longer.
        /// </summary>
        public void TrimToBest() {

            var shortest = Completed.Min(s=>s.Path.Count);
            var newSeq = Completed.Where( s => (s.Path.Count==shortest) );
            Completed = newSeq.ToList();

        }

        public String ToDisplay() {
            int num = Completed.Count;
            var buf = new StringBuilder();
            buf.Append("Solutions[").Append(num).Append("]:");
            foreach ( var state in Completed ) {
                buf.Append("\n\t");
                buf.Append( state.ToDisplay(true) );
            }
            return buf.ToString();
        }
    }
}
