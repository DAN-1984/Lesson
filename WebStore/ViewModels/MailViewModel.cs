using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class MailViewModel
    {
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [MaxLength(50)]
        public string Subject { get; set; } // Тема письма
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [MaxLength(500)]
        public string Message { get; set; } // Письмо
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [MaxLength(20)]
        public string Name { get; set; } // Имя
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [MaxLength(30)]
        public string Email { get; set; } // Email
    }
}
