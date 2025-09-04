// Copyright (c) 2025 Frederick William Haslam born 1962 in the USA.


namespace SearchCSharpAPI {

    public interface SearchDomainIF {

        public SearchStateIF Start { get; }

        public bool IsDone( SearchStateIF state );

        public List<SearchMoveIF> Options( SearchStateIF state );

    }

}
