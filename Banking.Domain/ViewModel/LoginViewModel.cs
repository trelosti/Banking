using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
