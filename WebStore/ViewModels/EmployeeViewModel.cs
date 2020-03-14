using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Длинна строки от 2 до 20")]
        [RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Ошибка формата - либо кириллица, латиница")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательным")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Длинна строки от 2 до 20")]
        [RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Ошибка формата - либо кириллица, латиница")]
        public string SecondName { get; set; }

        [Display(Name = "Отчество")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Отчество является обязательным")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Длинна строки от 2 до 20")]
        [RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Ошибка формата - либо кириллица, латиница")]
        public string Patronymic { get; set; }
        
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(18, 75, ErrorMessage = "Интервал возраста от 18 до 75 лет")]
        public int Age { get; set; }
    }
}
