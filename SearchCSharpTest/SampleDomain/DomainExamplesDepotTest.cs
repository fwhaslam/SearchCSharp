// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Collections;
using System.Collections.Generic;
using VerboseCSharp.Asserts;
using static VerboseCSharp.Asserts.VerboseAsserts;

namespace SearchCSharpTest.SampleDomain {

    [TestClass]
    public class DomainExamplesDepotTest {

        [TestMethod]
        public void ToDisplay_all() {

            var domain = DomainExamplesDepot.OneStepDomain;

            var start = domain.Start;
            var options = domain.Options( start );
            var end = options[0].After;

            // move
            var result = options[0].ToDisplay();
            StringsAreEqual ("M(a, z)", result );

            // path
            result = end.Path.ToDisplay();
            StringsAreEqual (
                "SamplePath:\n"+
		        "	M(a, z)", result );

            // start state
            result = start.ToDisplay();
            StringsAreEqual (
                "SampleState\n"+
		        "	Stars=a\n"+
		        "	Routes=", result );

            // end state
            result = end.ToDisplay();
            StringsAreEqual (
                "SampleState\n"+
		        "	Stars=a,z\n"+
		        "	Routes=(a,z) ", result );
        }

    }
}
