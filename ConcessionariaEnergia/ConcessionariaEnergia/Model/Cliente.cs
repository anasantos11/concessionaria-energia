using ConcessionariaEnergia.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConcessionariaEnergia.Model
{
    public class Cliente
    {
        public Cliente(string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(cpfCnpj))
            {
                throw new ArgumentException("O CPF/CNPJ não foi informado.");
            }

            if (!cpfCnpj.IsCpfCnpjValid())
            {
                throw new ArgumentException("O CPF/CNPJ informado é inválido.");
            }
            this.CpfCnpj = cpfCnpj;
            this.Unidades = new List<Unidade>();
        }

        public string CpfCnpj { get; }

        public List<Unidade> Unidades { get; }

        public void AdicionarUnidade(Unidade unidade)
        {
            if (unidade == null)
            {
                throw new ArgumentException("A unidade não foi informada.");

            }

            if (this.Unidades.Contains(unidade))
            {
                throw new ArgumentException("A unidade informada já existe no cliente.");
            }

            this.Unidades.Add(unidade);
        }

        public Conta CarregarContaMaiorValorJaPaga()
        {
            return this.Unidades
                 .SelectMany(unidade => unidade.ContasMensais)
                 .OrderByDescending(conta => conta.ValorPagar)
                 .FirstOrDefault();
        }
    }
}
