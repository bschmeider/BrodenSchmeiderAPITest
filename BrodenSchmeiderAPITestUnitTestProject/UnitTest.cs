using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrodenSchmeiderAPITest;
using System;
using System.IO;

namespace BrodenSchmeiderAPITestUnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        // need to test program resilience with invalid filenames
        [TestMethod]
        public void TestFileCreationWithInvalidFileName()
        {
            var emptyTestAPIData = new LiveTrafficDataResponse.Response();
            string outputFileName = CSVFile.GenerateFile(emptyTestAPIData,"output" + DateTime.Today.ToShortDateString() + ".csv" );
            Assert.IsNull(outputFileName);
        }

        // empty response objects have null properties. highly unlikely to occur but good to check
        [TestMethod]
        public void TestFileCreationWithValidFileNameAndEmptyResponseObject()
        {

            var emptyTestAPIData = new LiveTrafficDataResponse.Response(); 
            string outputFileName = CSVFile.GenerateFile(emptyTestAPIData, "output.csv");
            Assert.IsNull(outputFileName);
        }

        // need to ensure program doesnt break if the response from the API is null (occurs generally if api key or url is invalid or something occures on the api's end
        [TestMethod]
        public void TestFileCreationWithValidFileNameAndNullResponseObject()
        {
            LiveTrafficDataResponse.Response testAPIData = null;
            string outputFileName = CSVFile.GenerateFile(testAPIData, "output.csv");
            Assert.IsNull(outputFileName);
        }

        [TestMethod]
        public void TestConnectingToAPIWithFakeAPIKey()
        {
            LiveTrafficDataResponse.Response actualCameraData = LiveTrafficData.RetrieveLiveTrafficData("fakeKey", "https://api.transport.nsw.gov.au/v1/live/cameras");
            Assert.IsNull(actualCameraData);
        }

        [TestMethod]
        public void TestConnectingToAPIWithFakeURL()
        {
            LiveTrafficDataResponse.Response actualCameraData = LiveTrafficData.RetrieveLiveTrafficData("j1zHbAwDsYNo4sR9FpInRVzIX8698p9JxomI", "https://api.transport.nsw.gov.au/v1/live/fake");
            Assert.IsNull(actualCameraData);
        }

        [TestMethod]
        public void TestConnectingToAPIWithValidAPIKeyAndURL()
        {
            LiveTrafficDataResponse.Response actualCameraData = LiveTrafficData.RetrieveLiveTrafficData("j1zHbAwDsYNo4sR9FpInRVzIX8698p9JxomI", "https://api.transport.nsw.gov.au/v1/live/cameras");
            Assert.IsNotNull( actualCameraData);
        }
    }
}
