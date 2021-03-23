using Flunt.Validations;
using System.Collections.Generic;

namespace Regiao.Domain.Entidades
{
    public class Pais : Entidade
    {
        public string Codigo { get; set; }
        public const int CODIGO_TAMANHO_OBRIGATORIO = 2;
        public virtual ICollection<Provincia> Provincias { get; set; }

        public Pais()
        {
            Provincias = new HashSet<Provincia>();
        }

        public Pais(string codigo, string nome) : this()
        {
            Codigo = codigo;
            Nome = nome;
            Validar();
        }

        public Pais(int id, string codigo, string nome) : base(id)
        {
            Codigo = codigo;
            Nome = nome;
            Validar();
        }

        public override void Validar()
        {
            ValidarCodigo();
            ValidarNome();
        }

        private void ValidarCodigo()
        {
            AddNotifications(new Contract<Pais>()
               .Requires()
               .IsNotNullOrEmpty(Codigo, nameof(Codigo), $"O código é obrigatório.")
               .AreEquals(CODIGO_TAMANHO_OBRIGATORIO, Codigo, nameof(Codigo), $"O código do país tem que ter {CODIGO_TAMANHO_OBRIGATORIO} caracter(es).")
               );
        }
    }
}
