using System;
using System.Collections.Generic;

namespace ConcessionariaEnergia.Model
{
    public class Unidade
    {
        public Unidade(Guid identificador)
        {
            this.ContasMensais = new List<Conta>();
            this.Identificador = identificador;
        }

        public List<Conta> ContasMensais { get; set; }
        public Guid Identificador { get; }

        public void AdicionarContaMensal(Conta conta)
        {
            if (conta == null)
            {
                throw new ArgumentException("A conta não foi informada.");
            }

            if (this.ContasMensais.Contains(conta))
            {
                throw new ArgumentException("A conta informada já existe na unidade.");
            }

            this.ContasMensais.Add(conta);
        }
        
        public override bool Equals(object objeto)
        {
            if (objeto == null || !this.GetType().Equals(objeto.GetType()))
            {
                return false;
            }

            var conta = (Unidade)objeto;
            return this.Identificador == conta.Identificador;
        }
    }
}
