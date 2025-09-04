// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Collections;
using System.Collections.Generic;
using VerboseCSharp.Asserts;
using static VerboseCSharp.Asserts.VerboseAsserts;
using SearchCSharpTest.SampleDomain;
using SearchCSharp;

namespace SearchCSharpTest {

    [TestClass]
    public class SearchEngine_BreadthFirstDriverTest {


        [TestMethod]
        public void Engage_OneStepSolution() {
            
            var domain = DomainExamplesDepot.OneStepDomain;

            var engine = SearchEngine.MakeBreadthFirstSearch( domain );

            //=== invocation ===
            var searchResult = engine.FindFirst(); 
            
            //=== assertions ===
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

            // Search Results
            result = searchResult.ToDisplay();
            StringsAreEqual(
                "Solutions[1]:\n"+
		        "	SampleState Stars=a,z Routes=(a,z) ", result );
        }

        [TestMethod]
        public void Engage_TwoStepSolution() {
            
            var domain = DomainExamplesDepot.TwoStepDomain;

            var engine = SearchEngine.MakeBreadthFirstSearch( domain );

            //=== invocation ===
            var searchResult = engine.FindFirst(); 
            
            //=== assertions ===
            var result = searchResult.ToDisplay();
            StringsAreEqual(
                "Solutions[1]:\n"+
		        "	SampleState Stars=a,c,z Routes=(a,c) (c,z) ", result );
        }

        [TestMethod]
        public void Engage_ThreeStepMultiSolution_FindFirst() {
            
            var domain = DomainExamplesDepot.ThreeStepMultiDomain;

            var engine = SearchEngine.MakeBreadthFirstSearch( domain );

            //=== invocation ===
            var searchResult = engine.FindFirst(); 
            
            //=== assertions ===
            var result = searchResult.ToDisplay();
            StringsAreEqual(
                "Solutions[1]:\n"+
		        "	SampleState Stars=a,b,e,z Routes=(a,b) (b,e) (e,z) ", result );
        }

        [TestMethod]
        public void Engage_ThreeStepMultiSolution_FindAll() {
            
            var domain = DomainExamplesDepot.ThreeStepMultiDomain;

            var engine = SearchEngine.MakeBreadthFirstSearch( domain );

            //=== invocation ===
            var searchResult = engine.FindAll(); 
            
            //=== assertions ===
            AreEqual( 230, searchResult.Count );
        }

        [TestMethod]
        public void Engage_ThreeStepMultiSolution_FindBest() {
            
            var domain = DomainExamplesDepot.ThreeStepMultiDomain;

            var engine = SearchEngine.MakeBreadthFirstSearch( domain );

            //=== invocation ===
            var searchResult = engine.FindBest(); 
            
            //=== assertions ===
            var result = searchResult.ToDisplay();
            StringsAreEqual(
                "Solutions[2]:\n"+
		        "	SampleState Stars=a,b,e,z Routes=(a,b) (b,e) (e,z) \n"+
		        "	SampleState Stars=a,c,e,z Routes=(a,c) (c,e) (e,z) ", result );
        }

        [TestMethod]
        public void Engage_FirstWorstSolution_FindFirst() {
            
            var domain = DomainExamplesDepot.FirstWorstDomain;

            var engine = SearchEngine.MakeBreadthFirstSearch( domain );

            //=== invocation ===
            var searchResult = engine.FindFirst(); 
            
            //=== assertions ===
            var result = searchResult.ToDisplay();
            StringsAreEqual(
                "Solutions[1]:\n"+
		        "	SampleState Stars=a,z Routes=(a,z) ", result );
        }

        [TestMethod]
        public void Engage_FirstWorstSolution_FindBest() {
            
            var domain = DomainExamplesDepot.FirstWorstDomain;

            var engine = SearchEngine.MakeBreadthFirstSearch( domain );

            //=== invocation ===
            var searchResult = engine.FindBest(); 
            
            //=== assertions ===
            var result = searchResult.ToDisplay();
            StringsAreEqual(
                "Solutions[1]:\n"+
		        "	SampleState Stars=a,z Routes=(a,z) ", result );
        }

    }
}
