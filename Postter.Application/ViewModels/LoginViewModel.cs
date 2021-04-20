using System.ComponentModel.DataAnnotations;
namespace Postter.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "не указан Никнейм")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
         
        public string ReturnUrl { get; set; }
    }
}