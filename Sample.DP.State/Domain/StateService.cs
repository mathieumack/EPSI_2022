
namespace Sample.DP.State.Domain
{
    internal enum MessageState
    {
        New,
        Writing,
        Written
    }

    internal class MessageService
    {
        private string _message;
        internal MessageState State { get; private set; }

        internal void StartWriting()
        {
            _message = string.Empty;
            State = MessageState.New;
        }

        internal void WriteLine(string message)
        {
            _message += message + Environment.NewLine;
            State = MessageState.Writing;
        }

        internal void Send()
        {
            _message = null;
            State = MessageState.Written;
        }
    }
}
