using System;

namespace vendaQuitanda
{
    public class Alimento : Produto
    {
        private string Nome { get; set; }
        private int Calorias { get; set; }
        private TipoAlimento TipoAlimento { get; set; }
        private double Preco { get; set; }
        private string UnidadeMedida { get; set; }
        private double ValorTotalItem { get; set; }
        private double Quantidade { get; set; }
        private bool Excluido { get; set; }
        private int Id { get; set; }

        public Alimento (string nome, int caloria, double preco, string unidadeMedida, int id, TipoAlimento tipoAlimento, int calorias)
        {
            this.Nome = nome;
            this.Calorias = caloria;
            this.Preco = preco;
            this.UnidadeMedida = unidadeMedida;
        }

        public Alimento(int id, TipoAlimento tipoAlimento, string nome, int caloria, string unidadeMedida, double preco)
        {
            this.id = id;
            this.TipoAlimento = tipoAlimento;
            Nome = nome;
            this.Calorias = caloria;
            this.UnidadeMedida = unidadeMedida;
            Preco = preco;
        }

        public void AtualizarValor(int quantidade)
        {
            Quantidade = Convert.ToDouble(quantidade);
            ValorTotalItem = Preco * quantidade;
        }
        public void AtualizarValor(double peso)
        {
            Quantidade = peso;
            ValorTotalItem = Preco * peso;
        }

        public void Imprimir()
        {
            Console.WriteLine($"Item: {Nome}\n" +
                $"Calorias: {Calorias}\n" +
                $"Preço ({UnidadeMedida}): {Preco:0.00}\n" +
                $"Quantidade ({UnidadeMedida}): {Quantidade:0.0}\n" +
                $"Valor: {ValorTotalItem:0.00}\n");
        }
        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.id;
        }
        public bool isExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo do Alimento: " + this.TipoAlimento + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Calorias: " + this.Calorias + Environment.NewLine;
            retorno += "Preço: " + this.Preco + Environment.NewLine;
            retorno += "Unidade de medida: " + this.UnidadeMedida + Environment.NewLine;
            return retorno;
        }

    }
}
    

