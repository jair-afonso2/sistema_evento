using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Show : Evento
    {
        public string Artista { get; set; }
        public string GeneroMusical { get; set; }

        public Show()
        {
        }

        public Show(string Titulo, string Local, int Lotacao, string Duracao, 
                        int Classificacao, DateTime Data, string Artista, string GeneroMusical)
        {

            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;

            this.Artista = Artista;
            this.GeneroMusical = GeneroMusical;

        }

        public override bool Cadastrar()
        {

            bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("show.csv", true);
                arquivo.WriteLine(Titulo + ";" + Local + ";" + Duracao + ";" + Data.ToShortDateString() + ";" + Artista + ";" 
                                    + GeneroMusical + ";" + Lotacao + ";" + Classificacao);
                efetuado = true;
            }
            catch (Exception ex)
            {
                throw new Exception("\nErro ao tentar gravar arquivo " + ex.Message);
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
                ler = new StreamReader("show.csv", Encoding.Default);
                string linha = "";
                while ((linha = ler.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');

                    if (dados[0].ToUpper() == Titulo.ToUpper())
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
                ler = new StreamReader("show.csv", Encoding.Default);
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