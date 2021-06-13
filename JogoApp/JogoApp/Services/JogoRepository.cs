using JogoApp.Helpers;
using JogoApp.Models;
using System.Collections.Generic;

namespace JogoApp.Services
{
    //implementa o repositorio
    public class JogoRepository : IJogoRepository
    {
        DatabaseHelper _databaseHelper;
        public JogoRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public void DeleteAllJogos()
        {
            _databaseHelper.DeleteAllJogos();
        }

        public void DeleteJogo(int JogoID)
        {
            _databaseHelper.DeleteJogo(JogoID);
        }

        public List<Jogo> GetAllJogosData()
        {
            return _databaseHelper.GetAllJogosData();
        }

        public Jogo GetJogoData(int JogoID)
        {
            return _databaseHelper.GetJogoData(JogoID);
        }

        public void InsertJogo(Jogo Jogo)
        {
            _databaseHelper.InsertJogo(Jogo);
        }

        public void UpdateJogo(Jogo Jogo)
        {
            _databaseHelper.UpdateJogo(Jogo);
        }
    }
}
