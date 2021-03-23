using Flunt.Validations;
using System.Collections.Generic;

namespace Regiao.Domain.Entidades
{
    public class Municipio : Entidade
    {
        public int ProvinciaId { get; private set; }
        public virtual Provincia Provincia { get; private set; }
        public virtual ICollection<Distrito> Distritos { get; private set; }
        public Municipio()
        {
            Provincia = new Provincia();
            Distritos = new HashSet<Distrito>();
        }
       
        public Municipio(int id, int provinciaId, string nome) : base(id)
        {
            ProvinciaId = provinciaId;
            Nome = nome;
            Validar();
        }  
        
        public Municipio(int provinciaId, string nome) : this()
        {
            ProvinciaId = provinciaId;
            Nome = nome;
            Validar();
        }

        public override void Validar()
        {
            ValidarNome();
            ValidarProvincia();
        }

        private void ValidarProvincia()
        {
            AddNotifications(new Contract<Municipio>()
              .Requires()
              .IsGreaterThan(ProvinciaId, 0, nameof(ProvinciaId), $"Seleccione o município.")
              );
        }
    }
}
