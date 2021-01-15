using System.Collections.Generic;
using EPlayers_ASPNETCore.Models;

namespace EPlayers_ASPNETCore.Interfaces
{
    public interface IJogador
    {
        void Create(Jogador j);

        List<Jogador> ReadAll();

        void Update(Jogador j);

        void Delete (int id);
    }
}