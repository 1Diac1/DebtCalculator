namespace DebtCalculator.Api.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Auth
        {
            public const string Login = Base + "/auth/login";
            public const string Register = Base + "/auth/signup";
        }

        public static class Debt
        {
            public const string GetAllFromUser = Base + "/debts/get-all-from-user";
            public const string Add = Base + "/debts/add";
        }
    }
}