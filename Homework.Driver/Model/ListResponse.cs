

using System.Xml.XPath;
using Newtonsoft.Json;

namespace Homework.Driver.Model
{
    public class ListResponse
    {
        public int Per_Page { get; set; }
        public int Current_Page { get; set; }
        public string Next_Page_Url { get; set; }
        public string Prev_Page_Url { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public Data[] Data { get; set; }
    }

    public class Data
    {
        public Fx fx { get; set; }
        public string Created_at { get; set; }
        public Ipn Ipn { get; set; }
        public Acquirer Acquirer { get; set; }
        public Transaction Transaction { get; set; }
        public bool Refundable { get; set; }
        public Merchant Merchant { get; set; }
   
    }

    public class Merchant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool AllowPartialRefund { get; set; }
        public bool AllowPartialCapture { get; set; }
    }

    public class Transaction
    {
        [JsonProperty(PropertyName = "Merchant")]
        public TransactionMerchant TransactionMerchant { get; set; }
    }

    public class TransactionMerchant
    {
        public string ReferenceNo { get; set; }
        public string Status { get; set; }
        public string Operation { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string CustomData { get; set; }
        public string Created_At { get; set; }
        public string TransactionId { get; set; }
     
    }

    public class Acquirer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
    }


    public class Ipn
    {
        [JsonProperty(PropertyName = "Merchant")]
        public IpnMerchant IpnMerchant { get; set; }
        public bool Sent { get; set; }
    }

    public class IpnMerchant
    {
        public string TransactionId { get; set; }
        public string ReferenceNo { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Operation { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string CustomData { get; set; }
        public string ChainId { get; set; }
        public string PaymentType { get; set; }
        public string AuthTransactionId { get; set; }
        public string Token { get; set; }
        public string CovertedAmount { get; set; }
        public string ConvertedCurrency { get; set; }
        public string IPNUrl { get; set; }
    }

    public class Fx
    {
        [JsonProperty(PropertyName = "Merchant")]
        public FxMerchant Merchant { get; set; }
    }

    public class FxMerchant
    {
        public string ConcertedAmount { get; set; }
        public string ConvertedCurrency { get; set; }
        public string OrginalAmount { get; set; }
        public string OrginalCurrency { get; set; }
    }

    public class CustomerInfo
    {
        public string Email { get; set; }
        public string BillingFirstName { get; set; }
    }

    public class AcquirerTransactions
    {
        public string Nameofacquirer { get; set; }
        public string Code { get; set; }
    }

}