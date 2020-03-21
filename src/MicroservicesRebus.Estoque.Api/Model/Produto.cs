using System.Collections.Generic;

namespace MicroservicesRebus.Estoque.Api.Model
{
    public class Produto
    {
        public Produto(int id, string nome, int quantidadeEstoque, decimal valor)
        {
            Id = id;
            Nome = nome;
            QuantidadeEstoque = quantidadeEstoque;
            Valor = valor;

            if (this.Erros == null) this.Erros = new List<string>();
        }

        protected Produto() 
        {
             if (this.Erros == null) this.Erros = new List<string>();
        }

        public int Id {get; private set; }
        public string Nome {get; private set; }
        public int QuantidadeEstoque {get; private set; }
        public decimal Valor {get; private set; }
        public List<string> Erros { get; private set; }

        public void DiminuirQuantidadeEstoque(int quantidade)
        {
            QuantidadeEstoque -= quantidade;

            if (QuantidadeEstoque < 0)
            {
                AddErros($"Quantidade insuficiente do produto {Nome} em estoque.");
            }
        }

        public bool EhValido()
        {
            return this.Erros.Count == 0;
        }
        private void AddErros(string erro)
        {
            this.Erros.Add(erro);
        }
    }
}