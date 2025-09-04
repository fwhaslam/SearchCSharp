using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SearchCSharpAPI;

namespace SearchCSharpTest.SampleDomain {

    /// <summary>
    /// 
    /// IMPORTANT: States are not the same as NODEs.  A state is created by a seriesof operations.
    /// 
    /// Nodes are strings.
    /// Domain is a collection of node tuples.
    /// There is a start node and a finish node.
    /// Tuples are valid transitions ( eg. Moves ).
    /// 
    /// A transition makes more nodes active.  All active nodes provide moves.
    /// Used moves cannot be repeated.  A 'path' is a series of moves.
    /// 
    /// </summary>

    public class SampleDomain : SearchDomainIF {

        internal Dictionary<string,List<(string,string)>> RouteMap = new Dictionary<string,List<(string,string)>>();

        public SampleDomain( string first, string final, HashSet<(string, string)> routes ) {

            First = first;
            Final = final;
            Routes = routes.ToList();

            Start = new SampleState( First );

            RouteMap.Clear();
            foreach( var pair in Routes ) {

                var key1 = pair.Item1;
                if (!RouteMap.ContainsKey(key1)) RouteMap[key1] = new List<(string,string)>();

                var key2 = pair.Item2;
                if (!RouteMap.ContainsKey(key2)) RouteMap[key2] = new List<(string,string)>();

                RouteMap[key1].Add( pair );
            }

        }

        //=== Domain Specifics
        public string First { get; init; }

        public string Final { get; init; }

        
        public List<(string,string)> Routes { get; init; }


        //=== SearchDomain API ===

        public SearchStateIF Start { get; init; }

        public bool IsDone( SearchStateIF stateIF ) {
            var state = (SampleState)stateIF;
            return state.ActiveStars.Contains( Final );
        }

        public List<SearchMoveIF> Options( SearchStateIF beforeState ) {

            // find valid routes from active stars
            var edge = new List<(string,string)>();
            var state = (SampleState)beforeState;

            foreach ( var activeStar in state.ActiveStars ) {
                edge.AddRange(RouteMap[activeStar]);
            }
            foreach ( var route in state.ActiveRoutes ) {
                edge.Remove(route);
            }

            //=== build moves + associated states ===
            var list = new List<SearchMoveIF>();

            foreach ( var route in edge ) {

                var move = new SampleMove() { 
                      Route = route,
                      Before = beforeState
                };

                var nextState = new SampleState( state, move );
                move.After = nextState;

                list.Add( move );
            }

            return list;
        }

    }

}
