namespace ServiceLifeTime.Services
{
    public interface ISingleton
    {
        string GetGuid();
    }

    public class Singelton : ISingleton
    {
        private readonly string _guid;
        public Singelton()
        {
            _guid = System.Guid.NewGuid().ToString();
        }
        public string GetGuid()
        {
            return _guid;
        }
    }
}
