using System.Text.Json.Serialization;

namespace Manager.Services.DTO
{  
   public class UserDTO
   {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        
        [JsonIgnore]
        public string Cpf { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(long id, string name, string email, string password, string cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Cpf = cpf;
        }
    } 
}