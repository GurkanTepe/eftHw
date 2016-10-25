using Newtonsoft.Json;

namespace Homework.Driver.Model
{
    public class ClientResponse
    {
        [JsonProperty(PropertyName = "CustomerInfo")]
        public TransactionCustomerInfo CustomerInfo { get; set; }
    }
}