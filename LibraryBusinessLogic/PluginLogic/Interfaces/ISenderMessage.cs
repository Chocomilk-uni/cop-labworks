using LibraryBusinessLogic.PluginLogic.HelperModels;
using System.Collections.Generic;

namespace LibraryBusinessLogic.PluginLogic.Interfaces
{
    public interface ISenderMessage
    {
        string PluginType { get; }

        IEnumerable<UserInfo> Connect(SenderConfiguration config);

        void SendMessage(Message message);
    }
}