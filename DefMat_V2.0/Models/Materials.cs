using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefMat_V2._0.Model
{
    class Materials
    {

        public int  Id { get; set; }

        [Required(ErrorMessage = "Не указан материал")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть в диапазоне от {2}-{1} символов ")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Не указана плотность")]
        [Range(1, 10000, ErrorMessage = "Плотность должна быть в диапазоне {1}-{2}")]
        public double Density { get; set; }

        [Required(ErrorMessage = "Не указана Толщина")]
        [Range(1, 10000, ErrorMessage = "Толщина должна быть в диапазоне {1}-{2}")]
        public double Thicksness { get; set; }

        public virtual ICollection<Results> Results { get; set; }
    }
}
