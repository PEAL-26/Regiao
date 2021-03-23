using Flunt.Validations;
using System.Collections.Generic;

namespace Regiao.Domain.Entidades
{
    public class Provincia : Entidade
    {
        public int PaisId { get; private set; }
        public virtual Pais Pais { get; private set; }
        public virtual ICollection<Municipio> Municipios { get; private set; }

        public Provincia()
        {
            Municipios = new HashSet<Municipio>();
            Pais = new Pais();
        }

        public Provincia(int id, int paisId, string nome) : base(id)
        {
            PaisId = paisId;
            Nome = nome;
            Validar();
        }

        public Provincia(int paisId, string nome) : this()
        {
            PaisId = paisId;
            Nome = nome;
            Validar();
        }
        
        public override void Validar()
        {
            ValidarNome();
            ValidarPais();
        }

        private void ValidarPais()
        {
            AddNotifications(new Contract<Provincia>()
              .Requires()
              .IsGreaterThan(PaisId, 0, nameof(PaisId), $"Seleccione o país.")
              );
        }
      
    }
}
