using System.Collections.Generic;
using EPlayers_ASPNETCore.Models;

namespace EPlayers_ASPNETCore.Interfaces
{
    public interface INoticia
    {
         void Create(Noticia n);

        List<Noticia> ReadAll();

        void Update(Noticia n);

        void Delete (int id);
    }
}