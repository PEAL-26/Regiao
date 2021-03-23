using Flunt.Notifications;
using Flunt.Validations;

namespace Regiao.Domain.Entidades
{
    public abstract class Entidade : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public const int NOME_TAMANHO_MAXIMO = 80;

        public Entidade() { }
        public Entidade(int id) { Id = id; }
        public Entidade(int id, string nome) { Id = id; Nome = nome; ValidarNome(); }
        public Entidade(string nome) { Nome = nome; ValidarNome(); }
        public abstract void Validar();
        protected void ValidarNome()
        {
            AddNotifications(new Contract<Entidade>()
                  .Requires()
                  .IsNotNullOrEmpty(Nome, nameof(Nome), $"O código é obrigatório.")
                  .IsBetween(Nome.Length, 1, NOME_TAMANHO_MAXIMO, nameof(Nome), $"O nome tem que ter entre 1 à {NOME_TAMANHO_MAXIMO} caracter(es).")
                  );
        }
    }
}
