namespace UniStat.APIBrokers.BrokerInterfaces
{
    public interface IUniversityAPIBroker
    {
        /// <summary>
        /// Returns the response message of an asynchronous HTTP Request at the passed in URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> Get(Uri uri);
    }
}
