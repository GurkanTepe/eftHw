using System;

namespace Homework.Driver
{
    public class Configuration
    {
        public string UrlPattern { get; set; }

        public Uri BuildUrlFor(string method)
        {
            return new Uri(string.Format(UrlPattern,method));            
        }
    }
}