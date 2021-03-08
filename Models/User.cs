namespace api.Models {
    public class User {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() {
            this.Id = 0;
            this.Email = "";
            this.Password = "";
        }

        public User(int id, string email, string password) {
            this.Id = id;
            this.Email = email;
            this.Password = password;
        }
    }
}