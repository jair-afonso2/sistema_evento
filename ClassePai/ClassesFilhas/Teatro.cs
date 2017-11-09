using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Teatro : Evento
    {
        public string Diretor { get; set; }
        public string[] Elenco { get; set; }

        public Teatro()
        {

        }

        public Teatro(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string Diretor, string[] Elenco)
        {
            base.Titulo = base.Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;

            this.Diretor = Diretor;
            this.Elenco = Elenco;
        }

        public override bool Cadastrar()
        {
            bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                string stringElenco = "";
                foreach (String var in Elenco)
                {
                    stringElenco += var + " ";
                }

                arquivo = new StreamWriter("teatro.csv", true);
                arquivo.WriteLine(Titulo + ";" + Local + ";" + Duracao + ";" + Data + ";" + Diretor + ";" + stringElenco + ";" + Lotacao + ";" + Classificacao);
                efetuado = true;
            }
            catch (Exception ex)
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
                ler = new StreamReader("teatro.csv", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');

                    if (dados[0] == Titulo)
                    {
                        resultado = linha;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "Erro ao tentar ler o arquivo " + ex.Message;
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
                ler = new StreamReader("teatro.csv", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');

                    if (dados[3] == Data.ToString())
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