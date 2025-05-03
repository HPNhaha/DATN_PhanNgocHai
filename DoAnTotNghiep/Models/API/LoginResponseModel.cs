namespace DoAnTotNghiep.Models.API
{
    public class LoginResponseModel
    {
        public string? userName { get; set; }
        public string? accessToken { get; set; }

        public int expiresIn { get; set; }
        public bool success { get; set; }
        public string message {  get; set; }
    }
}
