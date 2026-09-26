using CalculadoraDescontos.App.Services;
namespace CalculadoraDescontos.Tests.Tests;

public class DescontoServiceTests
{
    private readonly DescontoService _service;

    public DescontoServiceTests()
    {
        _service = new DescontoService();
    }

    // --- TESTE PARAMETRIZADO COM RETORNO STRING ---
    [Theory]
    [InlineData(0, "BRONZE")]
    [InlineData(4, "BRONZE")]
    [InlineData(5, "PRATA")]
    [InlineData(10, "PRATA")]
    [InlineData(11, "OURO")]
    [InlineData(50, "OURO")]
    public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta_ParaDiferentesQuantidadesDeCompras(
        int totalCompras,
        string categoriaEsperada)
    {
        // Act
        string resultado = _service.ObterCategoriaCliente(totalCompras);

        // Assert
        Assert.Equal(categoriaEsperada, resultado);
    }

    // --- TESTE PARAMETRIZADO COM RETORNO INT ---
    [Theory]
    [InlineData(100, 10, 90)]   // 10% de 100 = 10 -> Sobra 90
    [InlineData(200, 20, 160)]  // 20% de 200 = 40 -> Sobra 160
    [InlineData(50, 0, 50)]     // 0% de desconto -> Sobra 50
    [InlineData(100, 100, 0)]   // 100% de desconto -> Sobra 0
    public void CalcularDescontoPorPercentual_DeveCalcularValorFinalCorretamente(
        int valorOriginal,
        int percentualDesconto,
        int valorEsperado)
    {
        // Act
        int resultado = _service.CalcularDescontoPorPercentual(valorOriginal, percentualDesconto);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    // --- TESTE PARAMETRIZADO COM RETORNO BOOL ---
    [Theory]
    [InlineData(20, false, true)]  // Maior de idade, não é 1ª compra -> Elegível (true)
    [InlineData(16, true, true)]   // Menor de idade, é 1ª compra -> Elegível (true)
    [InlineData(18, true, true)]   // Maior de idade e 1ª compra -> Elegível (true)
    [InlineData(17, false, false)] // Menor de idade e não é 1ª compra -> Não elegível (false)
    public void EValidoParaCupom_DeveValidarElegibilidadeCorretamente(
        int idade,
        bool primeiraCompra,
        bool resultadoEsperado)
    {
        // Act
        bool resultado = _service.EValidoParaCupom(idade, primeiraCompra);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
}