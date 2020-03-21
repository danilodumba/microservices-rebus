using System.Collections.Generic;
using MicroservicesRebus.Core;

namespace MicroservicesRebus.Core
{
  public class RemoverEstoqueEvent: Message
    {
        public RemoverEstoqueEvent()
        {
            Itens = new List<RemoverEstoqueItem>();
        }

        public RemoverEstoqueEvent(int numeroPedido)
        {
            NumeroPedido = numeroPedido;
            Itens = new List<RemoverEstoqueItem>();
        }

        public int NumeroPedido { get; set; }
        public List<RemoverEstoqueItem> Itens { get; set; }
    }

    public class RemoverEstoqueItem
    {
        public RemoverEstoqueItem()
        {
            
        }
        public RemoverEstoqueItem(int produtoID, int quantidade)
        {
            ProdutoID = produtoID;
            Quantidade = quantidade;
        }

        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
    }
}