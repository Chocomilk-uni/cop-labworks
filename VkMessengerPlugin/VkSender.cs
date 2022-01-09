using LibraryBusinessLogic.PluginLogic.HelperModels;
using LibraryBusinessLogic.PluginLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Forms;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using Message = LibraryBusinessLogic.PluginLogic.HelperModels.Message;

namespace VkMessengerPlugin
{
    [Export(typeof(ISenderMessage))]
    public class VkSender : ISenderMessage
    {
        private VkApi _api;
        public string PluginType => "Vk";

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
/*
            var formMes = ShowForm(userInfos);
            formMes.ShowDialog();*/
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

        private Form ShowForm(IEnumerable<UserInfo> userInfos)
        {
            var form = new FormMessage(this, userInfos);
            return form;
        }
    }
}