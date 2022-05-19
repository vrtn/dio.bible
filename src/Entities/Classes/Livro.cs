using System;

namespace DIO.Bible
{
    public class Livro : EntidadeBase
    {
        private string Nome { get; set; }
        private string Autor { get; set; }
        private int Versiculos { get; set; }
        private Testamento Testamento { get; set; }

        private bool Excluido { get; set; }

        public Livro(int id, Testamento testamento, string nome, string autor, int versiculos)
        {
            this.Id = id;
            this.Testamento = testamento;
            this.Nome = nome;
            this.Autor = autor;
            this.Versiculos = versiculos;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Testamento....:" + this.Testamento + Environment.NewLine;
            retorno += "Nome..........:" + this.Nome + Environment.NewLine;
            retorno += "Autor.........:" + this.Autor + Environment.NewLine;
            retorno += "Versículos(nº):" + this.Versiculos + Environment.NewLine;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}