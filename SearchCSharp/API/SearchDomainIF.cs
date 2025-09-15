// Copyright (c) 2025 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System.Collections.Generic;

namespace SearchCSharp.API {

    public interface SearchDomainIF {

        public SearchStateIF Start { get; }

        public bool IsDone( SearchStateIF state );

        public List<SearchMoveIF> Options( SearchStateIF state );

    }

}
