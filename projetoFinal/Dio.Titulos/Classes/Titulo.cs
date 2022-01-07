using System;

namespace Dio.Titulos
{
    public class Titulo : EntidadeBase
    {
        // Atributos
        private Genero Genero { get; set; }
        private string Nome { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private Formato Formato { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Titulo(int id, Genero genero, string nome, string descricao, int ano, Formato formato)
        {
            this.Id = id;
            this.Genero = genero;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Formato = formato;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Formato: " + this.Formato + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Nome;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}