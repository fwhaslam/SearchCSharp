// Copyright (c) 2025 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharpTest.SampleDomain {
    
    public class DomainExamplesDepot {

        public static SampleDomain OneStepDomain = new SampleDomain( 
            "a", "z",
            new HashSet<(string, string)>() { ("a", "z") }
        );

        public static SampleDomain TwoStepDomain = new SampleDomain(
            "a", "z",
            new HashSet<(string, string)>() { ("a", "b"), ("a", "c"), ("c", "z") }
        );

        public static SampleDomain ThreeStepMultiDomain = new SampleDomain(
            "a", "z",
            new HashSet<(string, string)>() { 
                ("a", "b"), ("b", "e" ),
                ("a", "c"), ("c", "e"),
                ("a", "d"), 
                ("e", "f"),
                ("e", "z") 
            }
        );

        public static SampleDomain FirstWorstDomain = new SampleDomain(
            "a", "z",
            new HashSet<(string, string)>() { 
                ("a", "b"), ("b", "z" ),
                ("a", "z") 
            }
        );

    }
}
