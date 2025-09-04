using SearchCSharpAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharpTest.SampleDomain {

    public class SamplePath : SearchPath {

        public void Merge( SamplePath oldPath, SampleMove newMove ) {
            if (oldPath!=null) AddRange( oldPath );
            Add( newMove );
        }

        override public string ToDisplay( bool flat = false ) {

            var buf = new StringBuilder();

            buf.Append("SamplePath:");
            foreach ( var move in this ) {
                buf.Append( flat ? " " : "\n\t" );
                buf.Append(move.ToDisplay());
            }

            return buf.ToString();
        }

    }

}
