using SearchCSharpAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharpTest.SampleDomain {

    /// <summary>
    /// A State has some number of active 'stars'.
    /// A Move adds a 'route' from an active star to another star, making it active.
    /// </summary>
    public class SampleState : SearchStateIF {

        /// <summary>
        /// Start state, no path, just one star.
        /// </summary>
        /// <param name="addStar"></param>
        public SampleState( string star ) {
            ActiveStars.Add( star );
        }

        public SampleState( SampleState previous, SampleMove addMove ) {

            Path.AddRange( previous.Path );
            Path.Add( addMove );

            ActiveRoutes.AddRange( previous.ActiveRoutes );
            ActiveRoutes.Add( addMove.Route );

            ActiveStars.UnionWith( previous.ActiveStars );
            ActiveStars.Add( addMove.Route.Item2 );
        }

        public HashSet<string> ActiveStars { get; set; } = new HashSet<string>();

        public List<(string,string)> ActiveRoutes { get; set; } = new List<(string,string)>();


        // === Interface ===

        public SearchPath Path { get; set; } = new SamplePath();


        public string ToDisplay( bool flat = false ) {

            var buf = new StringBuilder();

            buf.Append("SampleState");
            buf.Append( flat ? " " : "\n\t" );
            buf.Append("Stars="+ string.Join( ",", ActiveStars.ToArray() ));
            buf.Append( flat ? " " : "\n\t" );
            buf.Append("Routes="+ ActiveRoutes.Aggregate( "", (i, j) => i + "("+j.Item1+","+j.Item2+") " ) );

            return buf.ToString();
        }

    }
}
