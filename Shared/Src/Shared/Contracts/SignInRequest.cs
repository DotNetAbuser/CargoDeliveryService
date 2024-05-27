namespace Shared.Contracts;

public class SignInRequest
{
    [Required(ErrorMessage = "Поле номер телефона не может быть пустым!")] [Phone(ErrorMessage = "Поле номер телефона не соответвует маске(+7ххххххххххх)")] public string PhoneNumber { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле пароль не может быть пустым!")] public string Password { get; set; } = string.Empty;
}