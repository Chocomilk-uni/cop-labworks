using LibraryBusinessLogic.PluginLogic.HelperModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using Message = LibraryBusinessLogic.PluginLogic.HelperModels.Message;

namespace VkPlugin
{
    public class VkSender
    {
        private VkApi _api;

        public IEnumerable<UserInfo> Connect(SenderConfiguration config)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();

            _api = new VkApi(services);

            _api.Authorize(new ApiAuthParams
            {
                Login = config.Login,
                Password = config.Password,
                Settings = Settings.Friends | Settings.Messages
            });

            var users = _api.Friends.Get(new FriendsGetParams
            {
                UserId = _api.UserId,
                Fields = ProfileFields.FirstName,
            });

            return users.Select(u => new UserInfo
            {
                Id = u.Id,
                Name = $"{u.LastName} {u.FirstName}"
            });
        }

        public void SendMessage(Message message)
        {
            _api.Messages.Send(new MessagesSendParams
            {
                UserId = message.Id,
                Message = message.Text,
                RandomId = new Random().Next()
            });
        }
    }
}