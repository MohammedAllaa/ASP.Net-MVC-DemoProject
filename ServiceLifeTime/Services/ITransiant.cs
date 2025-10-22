namespace ServiceLifeTime.Services
{
    public interface ITransiant
    {
        string GetGuid();
    }

    public class Transiant : ITransiant
    {
        private readonly string _guid;
        public Transiant()
        {
            _guid = System.Guid.NewGuid().ToString();
        }
        public string GetGuid()
        {
            return _guid;
        }
    }
}

