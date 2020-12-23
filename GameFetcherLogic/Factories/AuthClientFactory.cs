namespace GameFetcherLogic.Factories
{
    public class AuthClientFactory : Factory
    {

        public override IObject ReturnObject(string objectName)
        {
            if (objectName == string.Empty) return null;

            if(objectName == nameof(TwitchAuthClient))
            {
                return TwitchAuthClient.GetInstance();
            }
           
            return null;
        }
       
    }
}
