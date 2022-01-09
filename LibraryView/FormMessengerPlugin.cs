using LibraryBusinessLogic.PluginLogic.HelperModels;
using LibraryBusinessLogic.PluginLogic.Managers;
using System;
using System.Windows.Forms;
using Unity;
using Message = LibraryBusinessLogic.PluginLogic.HelperModels.Message;

namespace LibraryView
{
    public partial class FormMessengerPlugin : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private MessengerPluginManager _manager;

        public FormMessengerPlugin(MessengerPluginManager manager)
        {
            _manager = manager;
            InitializeComponent();
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            if (comboBoxAvailablePlugin.SelectedItem == null) return;

            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var messenger = _manager.plugins[comboBoxAvailablePlugin.Text];

            try
            {
                var userInfos = messenger.Connect(new SenderConfiguration
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text
                });

                try
                {
                    foreach (var userInfo in userInfos)
                    {
                        messenger.SendMessage(new Message
                        {
                            Id = userInfo.Id,
                            Text = "ТЕСТ"
                        });
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при отправке сообщения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMessengerPlugin_Load(object sender, EventArgs e)
        {
            if (_manager.Headers is null || _manager.Headers.Count.Equals(0)) return;
            comboBoxAvailablePlugin.Items.AddRange(_manager.Headers.ToArray());
            comboBoxAvailablePlugin.Text = comboBoxAvailablePlugin.Items[0].ToString();
        }
    }
}
