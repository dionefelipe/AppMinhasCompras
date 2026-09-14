using SQLite;

namespace AppMinhasCompras.Models
{
    public class Produto
    {
        string descricao;
        string categoria;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { 
            get => descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("A descrição não pode ser vazia.");
                }
                descricao = value;
            } 
        }
        public string Categoria { 
            get => categoria;
            set
            {
                if (value == null)
                {
                    throw new Exception("A categoria não pode ser vazia.");
                }
                 categoria = value;
            } 
        }
        
        public double Preco { get; set; }
        public double Quantidade { get; set; }
        public double Total { get=> Preco * Quantidade;}
    }
}
