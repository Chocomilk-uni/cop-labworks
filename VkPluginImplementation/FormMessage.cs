using LibraryBusinessLogic.PluginLogic.HelperModels;
using LibraryBusinessLogic.PluginLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VkNet;
using Message = LibraryBusinessLogic.PluginLogic.HelperModels.Message;

namespace VkPluginImplementation
{
    public partial class FormMessage : Form
    {
        private ISenderMessage vkSender;
        IEnumerable<UserInfo> userInfos;
        public FormMessage(ISenderMessage vkSender, IEnumerable<UserInfo> userInfos)
        {
            this.vkSender = vkSender;
            this.userInfos = userInfos;
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMessage.Text))
            {
                MessageBox.Show("Введите текст сообщения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (var userInfo in userInfos)
                {
                    vkSender.SendMessage(new Message
                    {
                        Id = userInfo.Id,
                        Text = textBoxMessage.Text
                    });
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при отправке сообщения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}