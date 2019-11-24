namespace ConcessionariaEnergia.Model
{
    public class Conta
    {
        #region Constantes
        private const double ValorQuilowattHora = 0.7;
        private const double ValorIluminacaoPublica = 3.5;
        private const double ValorImposto = 1.30;
        #endregion

        public Conta(int consumo, byte mesReferencia, short anoReferencia)
        {
            this.Consumo = consumo;
            this.MesReferencia = mesReferencia;
            this.AnoReferencia = anoReferencia;
        }

        public int Consumo { get; }
        public double ValorPagar => ((this.Consumo * ValorQuilowattHora) + ValorIluminacaoPublica) * ValorImposto;
        private byte MesReferencia { get; }
        private short AnoReferencia { get; }
        public string MesAnoReferencia => this.MesReferencia + "/" + this.AnoReferencia;

        public override bool Equals(object objeto)
        {
            if (objeto == null || !this.GetType().Equals(objeto.GetType()))
            {
                return false;
            }

            var conta = (Conta)objeto;
            return this.MesAnoReferencia == conta.MesAnoReferencia && this.Consumo == conta.Consumo;
        }
    }
}
