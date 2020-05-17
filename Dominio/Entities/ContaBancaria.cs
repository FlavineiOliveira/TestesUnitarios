using Dominio.Entities.Base;
using Dominio.Enums;

namespace Dominio.Entities
{
    public class ContaBancaria : EntityBase
    {
        public string BancoNome { get; set; }

        public string BancoCodigo { get; set; }

        public string AgenciaNumero { get; set; }

        public string AgenciaDigito { get; set; }

        public string ContaNumero { get; set; }

        public string ContaDigito { get; set; }

        public TipoConta TipoConta { get; set; }

        public double Saldo { get; set; }
    }
}
