using SQLite;

namespace JogoApp.Models
{
    [Table("Jogos")]
    public class Jogo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal RM { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
    }
}
