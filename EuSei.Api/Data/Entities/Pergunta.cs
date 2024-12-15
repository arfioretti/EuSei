using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuSei.Api.Data.Entities
{
    public class Pergunta
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Descricao { get; set; }
        public IEnumerable<Opcao> Opcaos { get; set; }

        [ForeignKey(nameof(QuestionarioId))]
        public int QuestionarioId { get; set; }
        public virtual Questionario Questionario { get; set; }

    }
}
