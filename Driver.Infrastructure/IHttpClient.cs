using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Driver.Infrastructure
{
    public interface IHttpClient : IDisposable
    {
        Task<string> GetStringAsync(Uri requestUri);
        Task<string> PostStringAsync(Uri requestUri, string data);
        Task<Stream> GetStreamAsync(Uri requestUri);
    }
}