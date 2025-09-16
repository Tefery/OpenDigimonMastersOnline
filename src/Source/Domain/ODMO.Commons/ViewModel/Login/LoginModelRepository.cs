using ODMO.Commons.ViewModel;
using System.Collections.Generic;

namespace ODMO.Commons.ViewModel.Login
{
    public class LoginModelRepository
    {
        public List<LoginViewModel> Logins { get; set; }

        public LoginModelRepository()
        {
            Logins = new();
        }
    }
}
