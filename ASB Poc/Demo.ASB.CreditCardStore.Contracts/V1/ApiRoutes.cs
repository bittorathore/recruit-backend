
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ASB.CreditCardStore.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class CreditCards
        {
            public const string Get = Base + "/creditCards/{id}";
            public const string GetAll = Base + "/creditCards";
            public const string Create = Base + "/creditCards";
            public const string Update = Base + "/creditCards/{id}";
            public const string Delete = Base + "/creditCards/{id}";
        }

        public static class CardHolders
        {
            public const string Get = Base + "/cardHolder/{id}";
            public const string GetAll = Base + "/creditCards";
            public const string Create = Base + "/creditCards";
            public const string Update = Base + "/creditCards/{id}";
            public const string Delete = Base + "/creditCards/{id}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";

        }
    }
}
