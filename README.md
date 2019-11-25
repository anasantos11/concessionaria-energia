# Concessionária de Energia - Aplicação em .Net Core 2.1.0, C# e NUnit

***Problema-base:***

Uma concessionária de energia necessita armazenar dados de seus clientes e das contas mensais geradas para eles. As contas estão inicialmente associadas unidades faturadas (imóveis), as quais têm um identificador único. As unidades faturadas estão ligadas aos clientes por meio de CPF ou CNPJ - um cliente pode ser o titular de mais de uma unidade (em caso de possuir mais de um imóvel, ou possuir um imóvel e ser o titular da conta de uma loja, por exemplo).

Para cada unidade faturada, é gerada uma conta mensal. Além do mês de referência, cada conta armazena seu consumo, em kWh, e o valor a ser pago, em reais. O valor a ser pago é a multiplicação do consumo pela tarifa fixa determinada para a concessionária, mais um valor fixo a título de iluminação pública, mais 30% de impostos em cima da soma dos valores anteriores.

A versão inicial do sistema necessita armazenar, para um cliente, todas as suas unidades associadas e, para cada uma delas, todas as suas contas mensais. Também precisa responder o valor a pagar de uma conta de um cliente, bem como mostrar a conta de maior valor paga por um cliente.

***Objetivo:***

Usando o processo de TDD, criar os testes e as classes para demonstrar a realização correta das tarefas listadas no problema-base.

***Pré-requisitos para execução do projeto no Visual Studio:***

  - Visual Studio 2017 ou posterior com a carga de trabalho ".NET Core cross-platform development" instalada.
  - SDK do .NET Core 2.1.0.
