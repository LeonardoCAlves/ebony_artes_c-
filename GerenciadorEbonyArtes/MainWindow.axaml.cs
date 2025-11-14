using Avalonia.Controls;
using Avalonia.Controls.Converters;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GerenciadorEbonyArtes.Services;
using Tmds.DBus.Protocol;

namespace GerenciadorEbonyArtes {
    public partial class MainWindow : Window {
        
        private readonly AuthService _auth = new AuthService();
        
        public WindowNotificationManager Notifier;

        public MainWindow(){
            InitializeComponent();

            Notifier = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.TopCenter,
                MaxItems = 3
            };
        }

        private void NotificarSucesso(string msg)
        {
            Notifier.Show(new Notification("Sucesso", msg, NotificationType.Success));
        }

        private void NotificarErro(string msg)
        {
            Notifier.Show(new Notification("Erro", msg, NotificationType.Error));
        }

        private async void OnLoginClick(object sender, RoutedEventArgs e)
        {
            string usuario = TxtUsuario.Text;
            string senha = TxtSenha.Text;

            bool ok = _auth.Login(usuario, senha);

            if (ok)
            {
                NotificarSucesso("Login OK");
                // TODO: open the main window
            } else
            {
               NotificarErro("Dados incorretos!");
            }
        }
    }
}
