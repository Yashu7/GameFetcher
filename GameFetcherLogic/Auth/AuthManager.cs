
using GameFetcherLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic.Auth
{
    public static class AuthManager
    {
        private static IAuthClient AuthClient;
        private readonly static Factory Factory;

        static AuthManager()
        {
            Factory = new AuthClientFactory();
        }
        /// <summary>
        /// Provide name of IAuthClient Class as a parameter to recieve access token for it.
        /// <para>For example: GetToken("TwitchAuthClient") or GetToken(nameof(TwitchAuthClient)) returns token from TwitchAuthClient instance.</para>
        /// </summary>
        /// <param name="authClientName"></param>
        /// <returns>Returns token for authorization client</returns>
        public static string GetToken(string authClientName)
        {
            if (authClientName == String.Empty) return null;

            if (authClientName == nameof(TwitchAuthClient))
            {
                AuthClient = GetClientInstance(authClientName);
                return AuthClient.ReturnToken();
            }

            return null;
        }
        private static IAuthClient GetClientInstance(string authClientName)
        {
            return (IAuthClient)Factory.ReturnObject(authClientName);
        }
       
    }
}
