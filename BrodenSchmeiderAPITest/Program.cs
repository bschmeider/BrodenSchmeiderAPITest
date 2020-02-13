using System;

namespace BrodenSchmeiderAPITest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMessaging.DisplayMessageToUser("Attempting to retrieve camera data from the api.");
            LiveTrafficDataResponse.Response cameraData = LiveTrafficData.RetrieveLiveTrafficData("j1zHbAwDsYNo4sR9FpInRVzIX8698p9JxomI", "https://api.transport.nsw.gov.au/v1/live/cameras");

            // check if null. null means an error occured when talking to the api or deserialising
            // the data
            if (cameraData != null)
            {
                ConsoleMessaging.DisplayMessageToUser("Successfully retrieved camera data from the api.");
                ConsoleMessaging.DisplayMessageToUser("Now converting api data to a csv file.");
                string filePath = CSVFile.GenerateFile(cameraData,"output.csv");
                if (!String.IsNullOrEmpty(filePath))
                {
                    ConsoleMessaging.DisplayMessageToUser("File generated successfully. It can be found at " + filePath);
                }
                else
                {
                    ConsoleMessaging.DisplayMessageToUser("File failed to be created.");
                }
            }
            else
            {
                ConsoleMessaging.DisplayMessageToUser("Something went wrong when retrieving the camera data.");
            }
        }
    }
}
