using CalculadoraDescontos.App.Services;

DescontoService descontoService = new();
var categoria = descontoService.ObterCategoriaCliente(5);

Console.WriteLine($"Categoria do cliente: {categoria}");
