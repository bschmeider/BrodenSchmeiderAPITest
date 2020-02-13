using System;
using System.Collections.Generic;
using System.Text;

namespace BrodenSchmeiderAPITest
{
    public class LiveTrafficDataResponse
    {
        public class Response
        {
            public string type { get; set; }
            public LiveTrafficDataModels.Rights rights { get; set; }
            public FeatureObject[] features {get;set;}

        }

        public class FeatureObject
        {
            public string type { get; set; }
            public string id { get; set; }
            public LiveTrafficDataModels.FeatureGeometry geometry { get; set; }
            public LiveTrafficDataModels.FeatureProperties properties { get; set; }
        }
    }
}
