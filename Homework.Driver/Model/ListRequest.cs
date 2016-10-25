using System;

namespace Homework.Driver.Model
{
    public class ListRequest
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }
        public string Operation { get; set; }
        public string MerchantId { get; set; }
        public string AcquirerId { get; set; }
        public string PaymentMethod { get; set; }
        public string ErrorCode { get; set; }
        public string FilterField { get; set; }
        public string FilterValue { get; set; }
        public string Page { get; set; }
    }
}