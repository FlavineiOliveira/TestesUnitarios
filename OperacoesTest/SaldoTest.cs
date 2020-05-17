using Dominio.Enums;
using Dominio.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Operacoes;

namespace OperacoesTest
{
    [TestClass]
    public class SaldoTest
    {
        [TestMethod]
        public void SaldoContaNaoInformada()
        {
            Saldo saldo = new Saldo();

            var entrada = new InConsultarSaldo();
            var retorno = saldo.Consultar(entrada);

            Assert.IsTrue(retorno.TipoStatus == TipoStatus.ERRO &&
                          retorno.DescricaoErro == "Conta não informada.");
        }

        [TestMethod]
        public void SaldoContaNaoLocalizada()
        {
            Saldo saldo = new Saldo();

            var entrada = new InConsultarSaldo();
            entrada.ContaBancaria = new Dominio.Entities.ContaBancaria
            {
                BancoCodigo = "777",
                AgenciaNumero = "1000",
                AgenciaDigito = "0",
                ContaNumero = "54321",
                ContaDigito = "5",
                TipoConta = TipoConta.ContaCorrente
            };

            var retorno = saldo.Consultar(entrada);

            Assert.IsTrue(retorno.TipoStatus == TipoStatus.ERRO &&
                          retorno.DescricaoErro == "Conta não localizada.");
        }

        [TestMethod]
        public void SaldoContaConsultada()
        {
            Saldo saldo = new Saldo();

            var entrada = new InConsultarSaldo();
            entrada.ContaBancaria = new Dominio.Entities.ContaBancaria
            {
                AgenciaNumero = "0001",
                AgenciaDigito = "1",
                BancoCodigo = "999",
                ContaNumero = "012345",
                ContaDigito = "1",
                TipoConta = TipoConta.ContaCorrente
            };

            var retorno = saldo.Consultar(entrada);

            Assert.IsTrue(retorno.TipoStatus == TipoStatus.SUCESSO);
        }
    }
}
