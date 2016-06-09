// Файл P2PService.cs
using System.ServiceModel;

namespace P2P
{
    public delegate void Msg(string message, string from);

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class P2PService : IP2PService
    {
        private readonly MainWindow _hostReference;
        private readonly string _username;

        public event Msg GettingMessage;

        public P2PService(MainWindow hostReference, string username)
        {
            _hostReference = hostReference;
            _username = username;
        }

        public string GetName()
        {
            return _username;
        }

        public void SendMessage(string message, string from)
        {
            _hostReference.DisplayMessage(message, from);
            if (GettingMessage != null) GettingMessage(message, @from);
        }
    }
}