namespace MicroservicesRebus.Core.Events
{
    public class EstoqueFinalizadoEvent: Message
    {
        public EstoqueFinalizadoEvent(int numeroPedido)
        {
            NumeroPedido = numeroPedido;
        }

        public int NumeroPedido {get; set; }
    }
}