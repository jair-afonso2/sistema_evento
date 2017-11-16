using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema : Evento
    {
        public DateTime[] Sessao { get; set; }

        public string Genero { get; set; }

        public Cinema()
        {

        }

        public Cinema(string Titulo, string Local, int Lotacao, string Duracao, 
                        int Classificacao, DateTime Data, DateTime[] Sessao, string Genero)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;

            this.Genero = Genero;
            this.Sessao = Sessao;
        }

        public override bool Cadastrar()
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                string stringSessao = "";
                foreach (DateTime var in Sessao)
                {
                    stringSessao += var.ToShortTimeString() + " ";
                }

                stringSessao = stringSessao.Remove(stringSessao.Length - 1);

                arquivo = new StreamWriter("cinema.csv", true);

                arquivo.WriteLine(Titulo + ";" + Local + ";" + Duracao + ";" + Data.ToShortDateString() + ";"
                                 + Lotacao + ";" + Classificacao + ";" + Genero + ";" + stringSessao);
                
                efetuado = true;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao tentar gravar arquivo " + ex.Message);
            }
            finally
            {
                arquivo.Close();
            }
            
            return efetuado;
        }

        public override string Pesquisar(string Titulo)
        {
            string resultado = "Título não encontrado.";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("cinema.csv", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');

                    if (dados[0].ToLower() == Titulo.ToLower())
                    {
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                resultado = "\nErro ao tentar ler o arquivo " + ex.Message;
            }
            finally
            {
                ler.Close();
            }

            return resultado;
        }

        public override string Pesquisar(DateTime Data)
        {
            string resultado = "";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("cinema.csv", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');

                    if (dados[3] == Data.ToShortDateString())
                    {
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                resultado = "Erro ao ler o arquivo " + ex.Message;
            }
            finally
            {
                ler.Close();
            }

            return resultado;
        }
    }
}