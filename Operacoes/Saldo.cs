using Dominio.Entities;
using Dominio.Enums;
using Dominio.Input;
using Dominio.Output;
using System.Collections.Generic;

namespace Operacoes
{
    public class Saldo
    {
        public List<ContaBancaria> BaseContas { get; set; }

        public Saldo()
        {
            BaseContas = new List<ContaBancaria>();
            BaseContas.Add(new ContaBancaria
            {
                Id = 1,
                AgenciaNumero = "0001",
                AgenciaDigito = "1",
                BancoNome = "BANCO TESTE",
                BancoCodigo = "999",
                ContaNumero = "012345",
                ContaDigito = "1",
                TipoConta = TipoConta.ContaCorrente,
                Saldo = 1234.56
            });
        }

        public OutConsultarSaldo Consultar(InConsultarSaldo entrada)
        {
            var retorno = new OutConsultarSaldo();

            if (entrada == null ||
                entrada.ContaBancaria == null)
            {
                retorno.DescricaoErro = "Conta não informada.";
                return retorno;
            }

            var contaCliente = BaseContas.Find(x => x.BancoCodigo == entrada.ContaBancaria.BancoCodigo &&
                                                    x.AgenciaDigito == entrada.ContaBancaria.AgenciaDigito &&
                                                    x.AgenciaNumero == entrada.ContaBancaria.AgenciaNumero &&
                                                    x.ContaDigito == entrada.ContaBancaria.ContaDigito &&
                                                    x.ContaNumero == entrada.ContaBancaria.ContaNumero);

            if (contaCliente == null)
            {
                retorno.DescricaoErro = "Conta não localizada.";
                return retorno;
            }

            retorno.Saldo = contaCliente.Saldo;
            retorno.TipoStatus = TipoStatus.SUCESSO;

            return retorno;
        }
    }
}
