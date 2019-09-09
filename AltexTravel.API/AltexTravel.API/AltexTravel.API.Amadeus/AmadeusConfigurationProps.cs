using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusConfigurationProps
    {
        public const string URL = "https://test.api.amadeus.com/v1/reference-data/locations?subType=AIRPORT,CITY&keyword=r&page[limit]=1000";
        public const string API_KEY = "gZCS7tiyaRIIVihAoQFo2vARev7AnAVh";
        public const string API_SECRET = "yb3SXyWAeLGblN8K";
        public const string TOKEN_URL = "https://test.api.amadeus.com/v1/security/oauth2/token";
        public const string BASE_URL = "https://test.api.amadeus.com/v1/";
    }
}
