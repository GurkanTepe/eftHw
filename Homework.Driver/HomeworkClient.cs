using System;
using System.CodeDom;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Driver.Comon.Serialization;
using Driver.Infrastructure;
using Homework.Driver.Model;

namespace Homework.Driver
{
    public class HomeworkClient
    {
        public HomeworkClient(Configuration configuration, ITextSerializer serializer)
        {
            this.configuration = configuration;
            this.serializer = serializer;

        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await MakeApiCall<LoginResponse>("merchant/user/login", request, "");
        }

        public async Task<ReportResponse> Report(ReportRequest request, string token)
        {
            return await MakeApiCall<ReportResponse>("transactions/report ", request, token);
        }

        public async Task<ListResponse> List(ListRequest request, string token)
        {
            return await MakeApiCall<ListResponse>("transaction/list", request, token);
        }

        public async Task<TransactionResponse> Transaction(TransactionRequest request, string token)
        {
            return await MakeApiCall<TransactionResponse>("transaction", request, token);
        }

        public async Task<ClientResponse> Client(ClientRequest request, string token)
        {
            return await MakeApiCall<ClientResponse>("client",request, token);
        }

        async Task<T> MakeApiCall<T>(string method, object data, string credentials)
        {
            var httpClient = new HttpClient();
            if (credentials != "")
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(credentials);

            var requestUrl = configuration.BuildUrlFor(method);
            var datas = await httpClient.PostAsync(requestUrl, new StringContent(serializer.Serialize(data), encoding, contentType));
            var responseContent = await datas.Content.ReadAsStringAsync();
            var response = serializer.Deserialize<T>(responseContent);
            return response;
        }


        Configuration configuration;
        ITextSerializer serializer;


        Encoding encoding = Encoding.UTF8;
        string contentType = "application/json";

    }
}