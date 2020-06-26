using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway
{
    public class SecurityConstants
    {
        public static string Secret = "this_is_a_secret_key_for_signing_tokens";
        public static string Issuer = "MyApi";
        public static string Audience = "MyApi";
    }
}
