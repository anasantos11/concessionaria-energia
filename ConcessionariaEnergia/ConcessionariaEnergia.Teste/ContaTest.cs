using ConcessionariaEnergia.Model;
using NUnit.Framework;

namespace ConcessionariaEnergia.Teste
{
    public class ContaTest
    {
        [Test]
        public void RetornarValorAPagarComConsumo()
        {
            Conta conta = new Conta(100, 1, 2019);
            Assert.AreEqual(95.55, conta.ValorPagar);
        }

        [Test]
        public void ArmazenarMesAnoReferencia()
        {
            Conta conta = new Conta(100, 11, 2019);
            Assert.AreEqual("11/2019", conta.MesAnoReferencia);
        }

        [Test]
        public void Igualdade()
        {
            Assert.IsTrue(new Conta(100, 1, 2019).Equals(new Conta(100, 1, 2019)));
            Assert.IsFalse(new Conta(100, 1, 2019).Equals(new Conta(100, 2, 2019)));
            Assert.IsFalse(new Conta(100, 1, 2019).Equals(null));
            Assert.IsFalse(new Conta(100, 1, 2019).Equals(new object()));
        }
    }
}