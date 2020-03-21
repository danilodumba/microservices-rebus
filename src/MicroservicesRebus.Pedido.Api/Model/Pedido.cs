using System;
using System.Collections.Generic;

namespace MicroservicesRebus.Pedido.Api.Model
{
    public class Pedido
    {
        public Pedido()
        {
            Data = DateTime.Now;
            Status = StatusPedido.Aberto;
        }

        public int Numero { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public StatusPedido Status { get; set; }
        public string MotivoCancelamento {get; set; }
        public ICollection<ItemPedido> Itens { get; set; }

        public void AddItens(ItemPedido item)
        {
            this.Itens.Add(item);
        }
        
        public void Cancelar(string motivo)
        {
            this.Status = StatusPedido.Cancelado;
            this.MotivoCancelamento = motivo;
        }

        public void Finalizar()
        {
            this.Status = StatusPedido.Finalizado;
        }
    }
}