
using System;
using System.Collections.Generic;

namespace vendaQuitanda
{
    public class QuitandaRepositorio : IRepositorio<Alimento>
    {
        private List<Alimento> listaAlimentos = new List<Alimento>();
        public void Atualizar(int id, Alimento entidade)
        {
            listaAlimentos[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaAlimentos[id].Excluir();
        }

        public void Inserir(Alimento entidade)
        {
            listaAlimentos.Add(entidade);
        }

        public List<Alimento> Listar()
        {
            return listaAlimentos;
        }

        public int ProximoId()
        {
            return listaAlimentos.Count;
        }

        public Alimento RetornarPorId(int id)
        {
            try {
                return listaAlimentos[id];
            }
            catch (ArgumentOutOfRangeException) {

                Console.WriteLine("Alimento não encontrado!");
            }

            return null;
        }
    }
}
