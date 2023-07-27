using Banking.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.BLL.Interface
{
    public interface IAuthService
    {
        string GenerateToken(UserViewModel userViewModel);
    }
}
