using Flunt.Validations;

namespace Regiao.Domain.Entidades
{
    public class Distrito : Entidade
    {
        public int MunicipioId { get; private set; }
        public virtual Municipio Municipio { get; private set; }
        
        public Distrito()
        {
            Municipio = new Municipio();
        }

        public Distrito(int id, int municipioId, string nome) : base(id)
        {
            MunicipioId = municipioId;
            Nome = nome;
            Validar();
        }

        public Distrito(int municipioId, string nome) : this()
        {
            MunicipioId = municipioId;
            Nome = nome;
            Validar();
        }

        public override void Validar()
        {
            ValidarNome();
            ValidarMunicipio(); 
        }

        private void ValidarMunicipio()
        {
            AddNotifications(new Contract<Distrito>()
              .Requires()
              .IsGreaterThan(MunicipioId, 0, nameof(MunicipioId), $"Seleccione o municipio.")
              );
        }
    }
}
