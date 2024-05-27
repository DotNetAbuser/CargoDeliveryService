namespace Shared.Contracts;

public class SignUpRequest
{
    [Required(ErrorMessage = "Поле фамилия пользователя не может быть пустым!")]
    public string LastName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле имя пользователя не может быть пустым!")] 
    public string FirstName { get; set; } = string.Empty;
    
    public string MiddleName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле эл. почта не может быть пустым!")]
    [EmailAddress(ErrorMessage = "Поле эл. почта не соответсвует маске(mail@example.com)")] 
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле номер телефона не может быть пустым!")]
    [Phone(ErrorMessage = "Поле номер телефона не соответвует маске(+7ххххххххххх)")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле пароль не может быть пустым!")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле подтверждение пароль не может быть пустым!")] 
    [Compare(nameof(Password),ErrorMessage = "Пароли не совпадают!")] 
    public string ConfirmPassword { get; set; } = string.Empty;
    
    public int RoleId { get; set; } = 1;
}