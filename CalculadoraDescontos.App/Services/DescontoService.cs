namespace CalculadoraDescontos.App.Services;

public class DescontoService
{
    /// <summary>
    /// Retorna a categoria do cliente com base na quantidade de compras realizadas.
    /// </summary>
    public string ObterCategoriaCliente(int totalCompras)
    {
        if (totalCompras < 5)
            return "BRONZE";

        if (totalCompras <= 10)
            return "PRATA";

        return "OURO";
    }

    /// <summary>
    /// Aplica um percentual de desconto sobre o valor original e retorna o valor final.
    /// </summary>
    public int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
    {
        int valorDesconto = (valorOriginal * percentualDesconto) / 100;
        return valorOriginal - valorDesconto;
    }

    /// <summary>
    /// Verifica se o cliente tem direito ao cupom (Maior de 18 anos OU Primeira compra).
    /// </summary>
    public bool EValidoParaCupom(int idade, bool primeiraCompra)
    {
        return idade >= 18 || primeiraCompra;
    }
}