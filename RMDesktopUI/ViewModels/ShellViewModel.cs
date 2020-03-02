using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        //Constructor injection
        private LoginViewModel _loginVM;
        public ShellViewModel(LoginViewModel loginVM)
        {
            _loginVM = loginVM;
            ActivateItem(_loginVM);
        }
    }
}
