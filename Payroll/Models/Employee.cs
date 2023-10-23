using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Payroll.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de afiliação")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "O salário base é obrigatório")]
        [DisplayName("Salário base")]
        public double BaseSalary { get; set; }

        [Required(ErrorMessage = "O bonus é obrigatório")]
        [DisplayName("Bonus")]
        public double Bonus { get; set; }

        [Required(ErrorMessage = "As faltas são obrigatórias")]
        [DisplayName("Faltas")]
        public int Absence { get; set; }
    }
}
