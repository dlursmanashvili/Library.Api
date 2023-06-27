namespace Library.Models.AuthModels;
public class AuthResult
{
    public bool IsSuccess { get; set; }
    public string AccessToken { get; set; }
    public string SuccessMassage { get; set; }
}

