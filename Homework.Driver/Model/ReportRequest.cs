using System;

namespace Homework.Driver.Model
{
    public class ReportRequest
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Merchant { get; set; }
        public string Acquirer { get; set; }
    }
}