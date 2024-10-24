using JobPortalSystem_Exercise.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace JobPortalSystem_Exercise.Dtos
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Location { get; set; }
        public long? Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select a role.")]
        public Roles? Role { get; set; }
        public UserDto()
        {

        }
        public UserDto(string firstName, string lastName, string email, string gender, string? location, long phone, string password, Roles role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Location = location;
            Phone = phone;
            Password = password;
            Role = role;
        }
    }
}
