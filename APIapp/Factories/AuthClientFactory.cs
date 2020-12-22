using APIapp.Auth;
using APIapp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.Factories
{
    public class AuthClientFactory : Factory
    {

        public override IObject ReturnObject(string objectName)
        {
            if (objectName == string.Empty) return null;

            if(objectName == "TwitchAuthClient")
            {
                return TwitchAuthClient.GetInstance();
            }
           
            return null;
        }
       
    }
}
