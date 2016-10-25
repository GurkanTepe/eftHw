using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Driver.Comon.Serialization;
using FluentAssertions;
using Homework.Driver;
using Homework.Driver.Model;
using NUnit.Framework;

namespace Homework.Tests
{
    [TestFixture]
    public class HomeworkClientFixture
    {
        private HomeworkClient client;
        private Configuration config;
        private const string Email = "";
        private const string Password = "";

        [TestFixtureSetUp]
        public void SetUp()
        {
            config = new Configuration
            {
                UrlPattern = "https://testreportingapi.clearsettle.com/api/v3/{0}"
            };
            client = new HomeworkClient(config, new JsonSerializer());
        }

        [Test]
        public async Task Login()
        {
            var loginResponse = await client.Login(new LoginRequest
            {
                Email = Email,
                Password = Password
            });

            loginResponse.Status.Should().Be("APPROVED");
            loginResponse.Token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Report()
        {
            var loginResponse = await client.Login(new LoginRequest
            {
                Email = Email,
                Password = Password
            });

            var result = await client.Report(new ReportRequest
            {

                FromDate = new DateTime(2016, 07, 01).ToString("yyyy-MM-dd"),
                ToDate = new DateTime(2016, 10, 01).ToString("yyyy-MM-dd")
            }, loginResponse.Token);

            foreach (var response in result.Response)
            {
                response.Count.Should().BeGreaterThan(0);
                response.Currency.Should().NotBeNullOrEmpty();
                response.Total.Should().BeGreaterThan(0);
            }

        }

        [Test]
        public async Task List()
        {
            var loginResponse = await client.Login(new LoginRequest
            {
                Email = Email,
                Password = Password
            });

            var result = await client.List(new ListRequest
            {
                FromDate = new DateTime(2016, 10, 10).ToString("yyyy-MM-dd"),
                ToDate = new DateTime(2016, 10, 23).ToString("yyyy-MM-dd"),
            }, loginResponse.Token);

            foreach (var data in result.Data)
            {
                data.Acquirer.Code.Should().NotBeNullOrEmpty();
                data.Acquirer.Id.Should().NotBeNullOrEmpty();
                data.Acquirer.Name.Should().NotBeNullOrEmpty();
                data.Acquirer.Type.Should().NotBeNullOrEmpty();
                data.Ipn.IpnMerchant.Amount.Should().NotBeNullOrEmpty();
                data.Ipn.IpnMerchant.ChainId.Should().NotBeNullOrEmpty();
                data.Ipn.IpnMerchant.Code.Should().NotBeNullOrEmpty();
                data.Merchant.Id.Should().NotBeNullOrEmpty();
            }

        }

        [Test]
        public async Task Transaction()
        {
            var loginResponse = await client.Login(new LoginRequest
            {
                Email = Email,
                Password = Password
            });

            var result = await client.Transaction(new TransactionRequest
            {
                TransactionId = "821384-1476970505-184"
            }, loginResponse.Token);

            var merchant = result.Transaction.Merchant;
            merchant.AcquirerTransactionId.Should().Be("819518");
            merchant.MerchantId.Should().Be("184");
            merchant.Status.Should().Be("APPROVED");
            merchant.Channel.Should().Be("API");
            merchant.ChainId.Should().Be("5808c809408ba");
            merchant.AgentInfoId.Should().Be("13036");
            merchant.Operation.Should().Be("DIRECT");
            merchant.Type.Should().Be("AUTH");
            merchant.Updated_at.Should().Be("2016-10-20 13:35:09");
            merchant.Created_at.Should().Be("2016-10-20 13:35:05");
        }

        [Test]
        public async Task Client()
        {
            var loginResponse = await client.Login(new LoginRequest
            {
                Email = Email,
                Password = Password
            });

            var result = await client.Client(new ClientRequest
            {
                TransactionId = "821384-1476970505-184"
            }, loginResponse.Token);

            result.CustomerInfo.BillingAddress1.Should().Be("Akdeniz Uni");
            result.CustomerInfo.BillingCity.Should().Be("Antalya");
            result.CustomerInfo.BillingCompany.Should().Be("Bumin");
        }
    }
}