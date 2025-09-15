// Copyright (c) 2025 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp.API {

    public interface SearchStateIF {

        public SearchPath Path {  get; }

        public string ToDisplay( bool flat = false );

    }

}
