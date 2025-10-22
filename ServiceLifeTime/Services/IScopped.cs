namespace ServiceLifeTime.Services
{
    public interface IScopped
    {
        string GetGuid();
    }

    public class Scopped : IScopped
    {
        private readonly string _guid;
        public Scopped()
        {
            _guid = System.Guid.NewGuid().ToString();
        }
        public string GetGuid()
        {
            return _guid;
        }
    }
}
