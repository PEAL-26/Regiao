using Flunt.Notifications;

namespace Regiao.Application.ViewModels
{
    public class BaseViewModel : Notifiable<Notification>
    {
        public int Id { get; set; }
        public int Nome { get; set; }
    }
}
