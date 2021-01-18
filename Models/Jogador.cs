using System.Collections.Generic;
using System.IO;
using EPlayers_ASPNETCore.Interfaces;

namespace EPlayers_ASPNETCore.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        
        
        

        private const string PATH = "Database/Jogador.csv";

        public Jogador(){
            CreateFolderAndFile(PATH);
        }

        private string Prepare(Jogador j){
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha};{j.IdEquipe}";
        }

        public void Create(Jogador j)
        {
            j.IdJogador = ProximoCodigo();
            string[] linhas = { Prepare(j) };
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int idJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == idJogador.ToString());
            
            RewriteCSV(PATH, linhas);
        }

        public int ProximoCodigo(){

            var jogadores = ReadAll();

            if (jogadores.Count == 0)
            {
                return 1;
            }
            
            var id = jogadores[jogadores.Count - 1].IdJogador;

            id ++;
             
            return id;
        }

        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();

                jogador.IdJogador = int.Parse( linha[0] );
                jogador.Nome = linha[1];
                jogador.Email = linha[2];
                jogador.Senha = linha[3];
                jogador.IdEquipe = int.Parse( linha[4] );

                jogadores.Add(jogador);
            }

            return jogadores;
        }

        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());

            linhas.Add( Prepare(j) );

            RewriteCSV(PATH, linhas);
        }
        
    }
}