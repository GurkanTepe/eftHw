using Newtonsoft.Json;

namespace Homework.Driver.Model
{
    public class TransactionResponse
    {
        [JsonProperty(PropertyName = "CustomerInfo")]
        public TransactionCustomerInfo CustomerInfo { get; set; }
        public TransactionFx Fx { get; set; }
        [JsonProperty(PropertyName = "Transaction")]
        public TTransaction Transaction { get; set; }

    }

    public class TTransaction
    {
        [JsonProperty(PropertyName = "Merchant")]
        public TTransactionMerchant Merchant { get; set; }
    }

    public class TTransactionMerchant
    {
        public string ReferanceNo { get; set; }
        public string MerchantId { get; set; }
        public string Status { get; set; }
        public string Channel { get; set; }
        public string CustomData { get; set; }
        public string ChainId { get; set; }
        public string AgentInfoId { get; set; }
        public string Operation { get; set; }
        public string Type { get; set; }
        public string Updated_at { get; set; }
        public string Created_at { get; set; }
        public string Id { get; set; }
        public string FxTransactionId { get; set; }
        public string AcquirerTransactionId { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
        public Agent Agent { get; set; }

    }

    public class Agent
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerUserAgent { get; set; }
        public string MerchantIp { get; set; }
        public string MerchantUserAgent { get; set; }
        public string Create_at { get; set; }
        public string Updated_at { get; set; }
        public string Deleted_at { get; set; }
    }

    public class TransactionFx
    {
        [JsonProperty(PropertyName = "Merchant")]
        public TransactionFxMerchant Merchant { get; set; }
    }

    public class TransactionFxMerchant
    {
        public string OrginalAmount { get; set; }
        public string OrginalCurrency { get; set; }
    }

    public class TransactionCustomerInfo
    {
        public string Id { get; set; }
        public string Create_at { get; set; }
        public string Update_at { get; set; }
        public string Deleted_at { get; set; }
        public string Number { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string StartMonth { get; set; }
        public string StartYear { get; set; }
        public string IssueNumber { get; set; }
        public string Email { get; set; }
        public string Birthdat { get; set; }
        public string Gender { get; set; }
        public string BillingTitle { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingCompany { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingPostcode { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPhone { get; set; }
        public string BillingFax { get; set; }
        public string ShippingTitle { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingCompany { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostcode { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingFax { get; set; }
        public string Token { get; set; }
    }
}