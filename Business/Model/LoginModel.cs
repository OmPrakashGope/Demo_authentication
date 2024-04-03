using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class LoginModel
    {
        [NotMapped]
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        [NotMapped]
        public string? RefreshToken { get; set; }
        [NotMapped]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
