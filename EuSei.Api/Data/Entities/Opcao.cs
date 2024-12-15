using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuSei.Api.Data.Entities
{
    public class Opcao
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey(nameof(PerguntaId))]
        public int PerguntaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }
    }
}
