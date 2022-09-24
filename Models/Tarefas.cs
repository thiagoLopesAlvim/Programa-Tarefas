using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programa_consultorio.Models
{
    [Table("Tarefas")]
    public class Tarefas
    {
        [Key]
        [Display(Name="Id da Tarefa")]
        [Column("Id_tarefa")]
        public int id_tarefa { get; set; }

        [Display(Name = "Nome da Tarefa")]
        [Column("nome_tarefa")]
        public string nome_tarefa { get; set; }

        [Display(Name = "Custo da Tarefa")]
        [Column("custo_tarefa")]
        public double custo_tarefa { get; set; }

        [Display(Name = "Data limite da Tarefa")]
        [Column("data_limite")]
        public DateTime data_limite { get; set; }

        [Display(Name = "Ordem de apresentação")]
        [Column("ordem_apres")]
        public int ordem_apres { get; set; }
    }
}
