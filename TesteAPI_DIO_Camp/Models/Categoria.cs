using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPI_DIO_Camp.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor informar a descrição da categoria")]
        [Display(Name = "Categorias")]
        public string Descricao { get; set; }
        public List<Produto> Produto { get; set; }
    }
}
