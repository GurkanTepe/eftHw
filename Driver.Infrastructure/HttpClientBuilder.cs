using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Driver.Infrastructure
{
    public class HttpClientBuilder
    {
        public HttpClientBuilder DoNotExpectContinue()
        {
            expectContinue = false;
            return this;
        }

        public HttpClientBuilder WithAutoDecompression()
        {
            enableAutoDecompression = true;
            return this;
        }

        public HttpClientBuilder WithCredential(string userName, string password, Uri uriPrefix = null)
        {
            var networkCredential = new NetworkCredential(userName, password);
            if (uriPrefix != null)
            {
                credentials = new CredentialCache
                {
                    {uriPrefix, AuthenticationSchemes.Basic.ToString(), networkCredential},
                };
            }
            else
                credentials = networkCredential;

            return this;
        }

        public HttpClientBuilder EncodeWith(Encoding value)
        {
            encoding = value;
            return this;
        }

        public HttpClientBuilder ContentType(string value)
        {
            contentType = value;
            return this;
        }

        public HttpClientBuilder ContentTypeJson()
        {
            return ContentType("application/json");
        }

        public HttpClientBuilder ContentTypeEncodedForm()
        {
            return ContentType("application/x-www-form-urlencoded");
        }

        public HttpClientBuilder Accept(string value)
        {
            accept = value;
            return this;
        }

        public HttpClientBuilder AcceptJson()
        {
            return Accept("application/json");
        }

        public HttpClientBuilder TimeOut(TimeSpan value)
        {
            timeOut = value;
            return this;
        }

        public IHttpClient Build()
        {
            var automaticDecompression = enableAutoDecompression ? DecompressionMethods.GZip | DecompressionMethods.Deflate : DecompressionMethods.None;
            var client = new DriverHttpClient(new HttpClientHandler
            {
                Credentials = credentials,
                AutomaticDecompression = automaticDecompression
            })
            {
                ContentType = contentType,
                Encoding = encoding,
            
            };

            if (timeOut.HasValue)
            {
                client.Timeout = timeOut.Value;
            }

            if (!String.IsNullOrWhiteSpace(accept))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
            }

            client.DefaultRequestHeaders.ExpectContinue = expectContinue;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", );
            return client;
        }

        bool? expectContinue;
        bool enableAutoDecompression;
        TimeSpan? timeOut;
        Encoding encoding = Encoding.UTF8;
        ICredentials credentials;
        string contentType = "application/octet-strem";
        string accept = "";
      
    }
}