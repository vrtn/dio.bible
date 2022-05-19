using System;
using System.Collections.Generic;
using DIO.Bible.src.Entities.Interfaces;

namespace DIO.Bible
{
    public class LivroRepositorio : IRepositorio<Livro>
    {
        private List<Livro> listaLivros = new List<Livro>();
        public void Atualiza(int id, Livro entidade)
        {
            listaLivros[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaLivros[id].Exclui();
        }

        public void Insere(Livro entidade)
        {
            listaLivros.Add(entidade);
        }

        public List<Livro> Lista()
        {
            return listaLivros;
        }

        public int ProximoId()
        {
            return listaLivros.Count;
        }

        public Livro RetornaPorId(int id)
        {
            return listaLivros[id];
        }
    }
}