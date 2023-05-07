namespace safezonesoftware_restapi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
