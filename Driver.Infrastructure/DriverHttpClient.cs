using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Driver.Infrastructure
{
    class DriverHttpClient : HttpClient, IHttpClient
    {
        public DriverHttpClient(HttpClientHandler handler) : base(handler) { }

        public async Task<string> GetStringAsync(Uri requestUri)
        {
            var response = await GetAsync(requestUri);
            return await ProcessResponse(response);
        }

        public async Task<string> PostStringAsync(Uri address, string data){   
            var response = await PostAsync(address, new StringContent(data, Encoding, ContentType));
           
            return await ProcessResponse(response);
        }

        protected async Task<string> ProcessResponse(HttpResponseMessage responseMessage)
        {
            var byteArray = await responseMessage.Content.ReadAsByteArrayAsync();
            var result = this.Encoding.GetString(byteArray, 0, byteArray.Length);
            if (responseMessage.IsSuccessStatusCode)
                return result;

            throw new HttpResponseException(result, (int)responseMessage.StatusCode);
        }

        public async Task<Stream> GetStreamAsync(Uri requestUri)
        {
            var response = await GetAsync(requestUri);
            var result = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
                return result;
            using (var reader = new StreamReader(result, this.Encoding))
            {
                throw new HttpResponseException(reader.ReadToEnd(), (int)response.StatusCode);
            }
        }

        public Encoding Encoding { get; set; }
        public string ContentType { get; set; }
        public string Authorization { get; set; }
    }
}