using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BrodenSchmeiderAPITest
{
    public class CSVFile
    {
        private static string directoryPath;
        private static string fullFilePath;

        public static string GenerateFile(LiveTrafficDataResponse.Response apiData, string fileName)
        {
            try
            {
                if (apiData != null && !String.IsNullOrEmpty(fileName))
                {
                    directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LiveTrafficData");
                    fullFilePath = Path.Combine(directoryPath, fileName);

                    if (!Directory.Exists(directoryPath))
                    {
                        HelperMethods.CreateDirectory(directoryPath);
                    }

                    if (!File.Exists(fullFilePath))
                    {
                        HelperMethods.CreateFile(fullFilePath);
                    }
                    if (!GenerateCSVFile(apiData))
                    {
                        fullFilePath = null;
                    }
                }
            }
            catch (Exception ex)
            {
                fullFilePath = null;
            }
            return fullFilePath;
        }

        private static bool GenerateCSVFile(LiveTrafficDataResponse.Response apiData)
        {
            bool success = true;

            if (apiData != null && apiData.features != null)
            {
                try
                {
                    string delimiter = ",";
                    using (StreamWriter writer = new StreamWriter(fullFilePath, false))
                    {
                        // write the headers
                        string headerRow = "Region" + delimiter + "Title" + delimiter + "View" + delimiter
                            + "Direction";

                        writer.WriteLine(headerRow);

                        // write the actual content

                        foreach (LiveTrafficDataResponse.FeatureObject item in apiData.features)
                        {
                            string contentRow = item.properties.region + delimiter + item.properties.title +
                                    delimiter + item.properties.view + delimiter + item.properties.direction;

                            writer.WriteLine(contentRow);
                        }

                    }
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            else
            {
                success = false;
            }
            return success;
        }
    }
}
