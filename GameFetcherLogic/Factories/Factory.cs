namespace GameFetcherLogic.Factories
{
    public abstract class Factory
    {
        public abstract IObject ReturnObject(string objectName);
    }
}
