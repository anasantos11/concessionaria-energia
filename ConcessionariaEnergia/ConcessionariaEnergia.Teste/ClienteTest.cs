using ConcessionariaEnergia.Model;
using NUnit.Framework;
using System;

namespace ConcessionariaEnergia.Teste
{
    public class ClienteTest
    {
        [Test]
        public void TestArmazenarCpfCnpj()
        {
            Assert.AreEqual("27873855082", new Cliente("27873855082").CpfCnpj);
            Assert.AreEqual("31355414000167", new Cliente("31355414000167").CpfCnpj);
        }

        [Test]
        public void TestArmazenarCpfCnpjInvalido()
        {
            Assert.That(() => new Cliente("00000000000").CpfCnpj,
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("O CPF/CNPJ informado é inválido."));

            Assert.That(() => new Cliente("10101010101010").CpfCnpj,
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("O CPF/CNPJ informado é inválido."));
        }

        [Test]
        public void TestArmazenarCpfCnpjNaoInformado()
        {
            Assert.That(() => new Cliente(null).CpfCnpj,
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("O CPF/CNPJ não foi informado."));

            Assert.That(() => new Cliente("   ").CpfCnpj,
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("O CPF/CNPJ não foi informado."));

            Assert.That(() => new Cliente("").CpfCnpj,
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("O CPF/CNPJ não foi informado."));
        }

        [Test]
        public void TestArmazenasUnidadesAssociadas()
        {
            var unidade = new Unidade(Guid.NewGuid());
            var cliente = new Cliente("19152407004");

            cliente.AdicionarUnidade(unidade);

            Assert.IsTrue(cliente.Unidades.Contains(unidade));
        }

        [Test]
        public void TestArmazenasUnidadesAssociadasComUnidadeJaArmazenada()
        {
            var unidade = new Unidade(Guid.NewGuid());
            var cliente = new Cliente("19152407004");

            cliente.AdicionarUnidade(unidade);

            Assert.IsTrue(cliente.Unidades.Contains(unidade));

            Assert.That(() => cliente.AdicionarUnidade(unidade),
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("A unidade informada já existe no cliente."));
        }

        [Test]
        public void TestArmazenasUnidadesAssociadasComUnidadeNaoInformada()
        {
            Assert.That(() => new Cliente("19152407004").AdicionarUnidade(null),
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("A unidade não foi informada."));
        }

        [Test]
        public void TestRetornarContaMaisCaraPaga()
        {
            var unidade = new Unidade(Guid.NewGuid());
            var contaMaiorValor = new Conta(100, 1, 2019);
            var cliente = new Cliente("97144750070");

            cliente.AdicionarUnidade(unidade);
            unidade.AdicionarContaMensal(contaMaiorValor);
            unidade.AdicionarContaMensal(new Conta(90, 2, 2019));
            unidade.AdicionarContaMensal(new Conta(80, 3, 2019));

            Assert.AreEqual(contaMaiorValor, cliente.CarregarContaMaiorValorJaPaga());
        }

        [Test]
        public void TestRetornarContaMaisCaraPagaComMaisDeUmaUnidade()
        {
            var unidade1 = new Unidade(Guid.NewGuid());
            var unidade2 = new Unidade(Guid.NewGuid());
            var contaMaiorValor = new Conta(200, 1, 2019);
            var cliente = new Cliente("97144750070");

            cliente.AdicionarUnidade(unidade1);
            cliente.AdicionarUnidade(unidade2);

            unidade1.AdicionarContaMensal(new Conta(100, 1, 2019));
            unidade1.AdicionarContaMensal(new Conta(90, 2, 2019));
            unidade1.AdicionarContaMensal(new Conta(80, 3, 2019));
            unidade2.AdicionarContaMensal(new Conta(199, 1, 2019));
            unidade2.AdicionarContaMensal(contaMaiorValor);
            unidade2.AdicionarContaMensal(new Conta(150, 1, 2019));

            Assert.AreEqual(contaMaiorValor, cliente.CarregarContaMaiorValorJaPaga());
        }

        [Test]
        public void TestRetornarContaMaisCaraPagaClienteSemContas()
        {
            var cliente = new Cliente("97144750070");

            Assert.IsNull(cliente.CarregarContaMaiorValorJaPaga());

            var unidade = new Unidade(Guid.NewGuid());
            cliente.AdicionarUnidade(unidade);

            Assert.IsNull(cliente.CarregarContaMaiorValorJaPaga());
        }

    }
}
