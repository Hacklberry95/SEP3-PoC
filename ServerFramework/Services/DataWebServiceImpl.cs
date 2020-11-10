using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerFramework.Services
{
    public class DataWebServiceImpl : DataWebService
    {
        public async Task RefactorTheNameLater(int OID)
        {
            HttpClient ObjectName = new HttpClient();
            //localhost
            Uri uri = new Uri("");
            await ObjectName.PostAsync(uri, new StringContent(JsonSerializer.Serialize(OID,OID.GetType())));
            //idk what this is
        }
    }
}
