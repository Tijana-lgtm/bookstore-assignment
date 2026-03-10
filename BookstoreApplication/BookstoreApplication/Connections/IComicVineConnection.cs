namespace BookstoreApplication.Connections
{
    public interface IComicVineConnection
    {
        public Task<string> Get(string url);
    }

}
