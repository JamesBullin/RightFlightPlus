using System;
using NUnit.Framework;

namespace TokenAPI
{
    [TestFixture]
    public class TokenTests
    {
        // Instance of FLService
        TokenService _lastToken = new TokenService();

        [Test]
        public void IsStateApproved()
        {
            Assert.That(_lastToken.LastToken.state.ToString(), Is.EqualTo("approved"));
        }

        [Test]
        public void IsState200()
        {
            Assert.That(_lastToken.TokenCallManager.GetStatusCode(), Is.EqualTo("OK"));
        }

    }
}
