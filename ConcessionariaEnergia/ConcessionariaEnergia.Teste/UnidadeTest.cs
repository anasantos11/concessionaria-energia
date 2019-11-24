using ConcessionariaEnergia.Model;
using NUnit.Framework;
using System;

namespace ConcessionariaEnergia.Teste
{
    public class UnidadeTest
    {
        [Test]
        public void TestArmazenarContasMensais()
        {
            var conta = new Conta(100, 11, 2019);
            var unidade = new Unidade(Guid.NewGuid());

            unidade.AdicionarContaMensal(conta);

            Assert.IsTrue(unidade.ContasMensais.Contains(conta));
        }

        [Test]
        public void TestArmazenarContasMensaisComContaJaArmazenada()
        {
            var conta = new Conta(100, 11, 2019);
            var unidade = new Unidade(Guid.NewGuid());

            unidade.AdicionarContaMensal(conta);

            Assert.IsTrue(unidade.ContasMensais.Contains(conta));
            Assert.That(() => unidade.AdicionarContaMensal(conta),
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("A conta informada já existe na unidade."));
        }

        [Test]
        public void TestArmazenarContasMensaisContaNaoInformada()
        {
            var unidade = new Unidade(Guid.NewGuid());
            Assert.That(() => unidade.AdicionarContaMensal(null),
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("A conta não foi informada."));
        }

        [Test]
        public void TestArmazenarIdentificadorUnico()
        {
            var identificadorUnico = Guid.NewGuid();

            var unidade = new Unidade(identificadorUnico);

            Assert.AreEqual(identificadorUnico, unidade.Identificador);
        }
    }
}
