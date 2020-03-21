namespace MicroservicesRebus.Core
{
    public class EstoqueInconsistenteEvent: Message
    {
        public EstoqueInconsistenteEvent(int numeroPedido, string motivoCancelamento)
        {
            NumeroPedido = numeroPedido;
            MotivoCancelamento = motivoCancelamento;
        }

        public int NumeroPedido {get; set; }
        public string MotivoCancelamento { get; set; }
    }
}