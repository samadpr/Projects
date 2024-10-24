﻿using System.ComponentModel.DataAnnotations;

namespace JobPortalSystem_Exercise.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } = false;
    }
}
