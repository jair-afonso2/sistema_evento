using System;

namespace ProjetoEvento.ClassePai
{
    public abstract class Evento
    {
        public string Titulo { get; set; }
        public string Local { get; set; }
        public int Lotacao { get; set; }
        public string Duracao { get; set; }
        public DateTime Data { get; set; }
        public int Classificacao { get; set; }

        public virtual bool Cadastrar()
        {
            return false;
        }

        public virtual string Pesquisar(DateTime DataEvento)
        {
            return null;
        }

        public virtual string Pesquisar(string TituloEvento)
        {
            return null;
        }

    }
}