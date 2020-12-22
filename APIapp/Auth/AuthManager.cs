﻿using APIapp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.Auth
{
    public static class AuthManager
    {
        private static IAuthClient authClient;
        private static Factory factory;

        static AuthManager()
        {
            factory = new AuthClientFactory();
        }
        /// <summary>
        /// Provide name of IAuthClient Class as a parameter to recieve access token for it.
        /// <para>For example: GetToken("TwitchAuthClient") returns token from TwitchAuthClient instance.</para>
        /// </summary>
        /// <param name="authClientName"></param>
        /// <returns>Returns token for authorization client</returns>
        public static string GetToken(string authClientName)
        {
            if (authClientName == String.Empty) return null;

            if (authClientName == "TwitchAuthClient")
            {
                authClient = GetClientInstance(authClientName);
                return authClient.ReturnToken();
            }

            return null;
        }
        private static IAuthClient GetClientInstance(string authClientName)
        {
            return (IAuthClient)factory.ReturnObject(authClientName);
        }
       
    }
}