using JogoApp.Models;
using System.Collections.Generic;

namespace JogoApp.Services
{
    public interface IJogoRepository
    {
        List<Jogo> GetAllJogosData();

        //Obtem um dado especifico por id
        Jogo GetJogoData(int JogoID);

        // deleta todos os dados
        void DeleteAllJogos();

        // Deleta um dado especifico
        void DeleteJogo(int JogoID);

        // Insere um novo dado no BD
        void InsertJogo(Jogo Jogo);

        // Atualiza os dados
        void UpdateJogo(Jogo Jogo);
    }
}
