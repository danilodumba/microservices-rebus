namespace MicroservicesRebus.Pedido.Api.Model
{
    public class ItemPedido 
    {
        public ItemPedido()
        {
            
        }

        public int NumeroPedido {get; set; }
        public int ProdutoID {get; set; }
        public string NomeProduto {get; set; }
        public int Quantidade {get; set; }
        public decimal ValorUnitario {get; set; }
    }
}