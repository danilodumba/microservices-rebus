# Comunicação entre serviços (apis) usando REBUS e RabbitMQ.

Para iniciar o projeto é necessário ter o Docker instalado em sua máquina.

1. Va a pasta docker com o seu terminal e digite o codigo "docker-compose up". Isso irá subir o banco de dados MySql e o RabbitMQ.
2. Va a cada projeto Pedido.Api e Estoque.Api e rode o migrations "dotnet ef database update". Isso irá criar o banco de dados de cada projeto.
3. Rode os dois projetos e insira um pedido:
4. Faca um post na url http://localhost:5001/api/pedido

Pedido com sucesso
```json
{
	"NomeCliente": "Teste de Pedido",
	"Itens": [
		{"ProdutoID": 1, "NomeProduto":  "BMW X1", "Quantidade": 10, "ValorUnitario": 150000}
	]
}
```

Pedido com erro de estoque
```json
{
	"NomeCliente": "Teste de Pedido com erro de quantidade de estoque",
	"Itens": [
		{"ProdutoID": 2, "NomeProduto":  "BMW 320", "Quantidade": 1000, "ValorUnitario": 150000}
	]
}
```

Pedido com erro de produto nao encontrado
```json
{
	"NomeCliente": "Teste de Pedido com erro de produto nao encontrado",
	"Itens": [
		{"ProdutoID": 100, "NomeProduto":  "Mercedes AMG 230", "Quantidade": 1, "ValorUnitario": 150000}
	]
}
```