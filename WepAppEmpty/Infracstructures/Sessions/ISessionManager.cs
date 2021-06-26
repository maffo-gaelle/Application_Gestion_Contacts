namespace WepAppEmpty.Infracstructures.Sessions
{
    public interface ISessionManager
    {
        UserSession User { get; set; }

        void Clear();
    }
}