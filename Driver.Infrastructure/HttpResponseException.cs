using System;

namespace Driver.Infrastructure
{
    public class HttpResponseException : Exception
    {
        readonly int statusCode;
        readonly string response;

        public HttpResponseException() { }

        public HttpResponseException(string response, int statusCode)
                : base(response + ", StatusCode: " + statusCode)
        {
            this.response = response;
            this.statusCode = statusCode;
            this.Data.Add("RemoteStatusCode", statusCode);
        }

        public string Response { get { return response; } }
        public int StatusCode { get { return statusCode; } }
    }
}