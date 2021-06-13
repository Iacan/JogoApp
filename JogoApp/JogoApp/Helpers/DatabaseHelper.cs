using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using JogoApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace JogoApp.Helpers
{
    public class DatabaseHelper
    {
        //defina uma conexao e o  nome do banco de dados
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "JogosDB.db";

        public DatabaseHelper()
        {
            //cria uma pasta base local para o dispositivo
            var pasta = new LocalRootFolder();
            //cria o arquivo
            var arquivo = pasta.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);
            //abre o BD
            sqliteconnection = new SQLiteConnection(arquivo.Path);
            //cria a tabela no BD
            sqliteconnection.CreateTable<Jogo>();
        }

        //Pegar todos os dados  
        public List<Jogo> GetAllJogosData()
        {
            return (from data in sqliteconnection.Table<Jogo>()
                    select data).ToList();
        }

        //Pegar dados especifico por id
        public Jogo GetJogoData(int id)
        {
            return sqliteconnection.Table<Jogo>().FirstOrDefault(t => t.Id == id);
        }

        // Deletar todos os dados
        public void DeleteAllJogos()
        {
            sqliteconnection.DeleteAll<Jogo>();
        }

        // Deletar um dado especifico por id
        public void DeleteJogo(int id)
        {
            sqliteconnection.Delete<Jogo>(id);
        }

        // Inserir dados
        public void InsertJogo(Jogo Jogo)
        {
            sqliteconnection.Insert(Jogo);
        }

        // Atualizar dados
        public void UpdateJogo(Jogo Jogo)
        {
            sqliteconnection.Update(Jogo);
        }
    }
}
