using System.Collections.Generic;
using System.IO;
using EPlayers_ASPNETCore.Interfaces;

namespace EPlayers_ASPNETCore.Models
{
    public class Noticia : EPlayersBase , INoticia
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        
        private const string PATH = "Database/Noticia.csv";
        
        public Noticia(){
            CreateFolderAndFile(PATH);
        }

        private string Prepare(Noticia n){
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        public void Create(Noticia n)
        {
            string[] linhas = { Prepare(n) };
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            
            RewriteCSV(PATH, linhas);
        }

        public List<Noticia> ReadAll()
        {
            List<Noticia> noticias = new List<Noticia>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Noticia noticia = new Noticia();

                noticia.IdNoticia = int.Parse( linha[0] );
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }

            return noticias;
        }

        public void Update(Noticia n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());

            linhas.Add( Prepare(n) );

            RewriteCSV(PATH, linhas);
        }
    }
}