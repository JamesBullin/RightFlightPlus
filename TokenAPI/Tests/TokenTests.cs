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
        public void IsState200()
        {
            Assert.That(_lastToken.TokenCallManager.GetStatusCode(), Is.EqualTo("OK"));
        }

        [Test]
        public void IsDataCorrect()
        {
            string expectedType = "amadeusOAuth2Token";
            Assert.That(_lastToken.LastToken.type.ToString(), Is.EqualTo(expectedType));

            string expectedUsername = "james.r.k.bullin@gmail.com";
            Assert.That(_lastToken.LastToken.username.ToString(), Is.EqualTo(expectedUsername));

            string expectedApplicationName = "RightFlightPlus";
            Assert.That(_lastToken.LastToken.application_name.ToString(), Is.EqualTo(expectedApplicationName));

            string expectedClientID = "u7Cn4VFNmeG9K8QYrnxzs1X0TlXaygSp";
            Assert.That(_lastToken.LastToken.client_id.ToString(), Is.EqualTo(expectedClientID));
            
            string expectedTokenType = "Bearer";
            Assert.That(_lastToken.LastToken.token_type.ToString(), Is.EqualTo(expectedTokenType));
            
            int expectedExpectedExpirationTime = 1799;
            Assert.That(_lastToken.LastToken.expires_in, Is.EqualTo(expectedExpectedExpirationTime));

            string expectedState = "approved";
            Assert.That(_lastToken.LastToken.state.ToString(), Is.EqualTo(expectedState));

        }

        [Test]
        public void IsAccessKeyInCorrectFormat()
        {
            string accessKey = _lastToken.LastToken.access_token.ToString();
            int expectedLength = 28;

            Assert.That(accessKey.Length, Is.EqualTo(expectedLength));
        }
    }
}
