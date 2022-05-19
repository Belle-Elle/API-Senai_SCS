using System.ComponentModel.DataAnnotations;

namespace APISenaiSCS.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Informe o NIF do usuário!")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string senha { get; set; }

    }
}
