﻿
using Microsoft.NodejsTools.TestAdapter.TestFrameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAdapterTests {
    [TestClass]
    public class NodejsTestInfoTests {

        [TestMethod, Priority(0)]
        public void ConstructFullyQualifiedName_ValidInput() {
            //Arrange
            string testFile = "c:\\dummyWhatever.js";
            string testSuiteName = "testsuite1";
            string testName = "myMochaTest";
            string testFramework = "mocha";

            //Act
            NodejsTestInfo testInfo = new NodejsTestInfo(testFile, testName, testSuiteName, testFramework);

            //Assert
            string expected = testFile + "::" + testSuiteName + "::" + testName + "::" + testFramework;
            Assert.AreEqual(expected, testInfo.FullyQualifiedName);
            Assert.AreEqual(testName, testInfo.TestName);
            Assert.AreEqual(testFramework, testInfo.TestFramework);
            Assert.AreEqual(testFile, testInfo.ModulePath);
            Assert.AreEqual(testSuiteName + ":" + testName, testInfo.DisplayName);
        }

        [TestMethod, Priority(0)]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ConstructFromQualifiedName_ThrowOnInValidInput() {
            //Arrange
            string badDummy = "c:\\dummy.js::dummy::test1";

            //Act
            NodejsTestInfo testInfo = new NodejsTestInfo(badDummy);

            //Assert: N/A
        }
    }
}