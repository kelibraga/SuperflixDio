using System;
using System.Collections.Generic;
using Dio.Titulos.Interfaces;

namespace Dio.Titulos
{
    public class TituloRepositorio : IRepositorio<Titulo>
    {
        private List<Titulo> listaTitulo = new List<Titulo>();
        public void Atualiza(int id, Titulo objeto)
        {
            listaTitulo[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaTitulo[id].Excluir();
        }

        public void Insere(Titulo objeto)
        {
            listaTitulo.Add(objeto);
        }

        public List<Titulo> Lista()
        {
            return listaTitulo;
        }

        public int ProximoId()
        {
            return listaTitulo.Count;
        }

        public Titulo RetornaPorId(int id)
        {
            return listaTitulo[id];
        }
    }
}