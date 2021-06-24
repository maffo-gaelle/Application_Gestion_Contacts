namespace WepAppEmpty.Models.Sessions
{
    public interface ISessionManager
    {
        UserSession User { get; set; }

        void Clear();
    }
}