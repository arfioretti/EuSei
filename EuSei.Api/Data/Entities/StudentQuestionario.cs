using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuSei.Api.Data.Entities
{
    public class StudentQuestionario
    {
        [Key]
        public int Id { get; set; }

        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }

        public int Acertos { get; set; }

        [ForeignKey(nameof(QuestionarioId))]
        public int QuestionarioId { get; set; }
        public virtual Questionario Questionario { get; set; }
    }   
}

