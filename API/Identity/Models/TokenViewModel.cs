using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public class TokenViewModel
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string UserName { get; set; }
        public string NAME { get; internal set; }
        public bool TwoFactorEnabled { get; set; }
        public string ImagePath { get; set; }
        public IList<string> Roles { get; internal set; }
        public string Role { get; internal set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public bool PasswordChanged { get; set; }
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? FavLinks { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsFirstTimeProfileAdded { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
