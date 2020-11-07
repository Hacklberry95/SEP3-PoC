using ClientFramework.Data;
using ClientFramework.REST;
using NuGet.Frameworks;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientUnitTests
{
    class HttpMessageTest
    {
        CustomHTTPRequests requests;
        Order o1;
        Order o2;

        [SetUp]
        public void Setup()
        {
            requests = new CustomHTTPRequests();
            o1 = new Order(0);
            o2 = new Order(222);
        }

        [Test]
        public void PostIDTestCorrect()
        {
            Task<HttpResponseMessage> task = requests.PostConfirmation(0);
            Assert.NotNull(task.Result);
        }

        [Test]
        public void PostIDTestIncorrect()
        {
            Task<HttpResponseMessage> task = requests.PostConfirmation(222);
            Assert.IsNull(task.Result);
        }


        [Test]
        public void PostOrderTestCorrect()
        {
            Task<HttpResponseMessage> task = requests.PostConfirmation(o1) ;
            Assert.NotNull(task.Result);
        }

        [Test]
        public void PostOrderTestIncorrect()
        {
            Task<HttpResponseMessage> task = requests.PostConfirmation(o2);
            Assert.IsNull(task.Result);
        }
    }
}
