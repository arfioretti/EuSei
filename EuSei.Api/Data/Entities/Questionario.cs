using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuSei.Api.Data.Entities
{
    public class Questionario
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Descricao { get; set; }
        public int TotalMinutos { get; set; }
        public bool  IsActive { get; set; }
        public IEnumerable<Pergunta> Perguntas { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
