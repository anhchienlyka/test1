using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityMvc.Models
{
    public class TwoFactorAuthenticationViewModel
    {
        //user to login
        public string Code { get; set; }

        //used to register/ signup
        public string Token { get; set; }

        public string QRCodeUrl { get; set; }
    }
}
