using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
	public class LoginViewModel : Screen
    {
		private string _userName;
		private string _password;
		private IAPIHelper _apiHelper;
		private string _errorMessage;

		public LoginViewModel(IAPIHelper apiHelper)
		{
			_apiHelper = apiHelper;
		}

		/// <summary>
		/// A UserName
		/// </summary>
		public string UserName
		{
			get { return _userName; }
			set {
				_userName = value;
				NotifyOfPropertyChange(() => UserName);
			}
		}

		/// <summary>
		/// A User Password
		/// </summary>
		public string Password
		{
			get { return _password; }
			set {
				_password = value;
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		/// <summary>
		/// Computed property to define if the log in button is available or not.
		/// It's wired up with the button by conventions stablished by Caliburn Micro.
		/// </summary>
		public bool CanLogIn
		{
			get
			{
				bool output = false;

				if (UserName?.Length > 0 && Password?.Length > 0)
				{
					output = true;
				}

				return output;
			}
		}

		/// <summary>
		/// Computed property to define if an error message is visible or not.
		/// </summary>
		public bool IsErrorVisible
		{
			get
			{
				bool output = false;

				if (ErrorMessage?.Length > 0)
				{
					output = true;
				}

				return output;
			}
		}		

		/// <summary>
		/// Representes an error message (observable)
		/// </summary>
		public string ErrorMessage
		{
			get { return _errorMessage; }
			set 
			{
				_errorMessage = value;
				NotifyOfPropertyChange(() => IsErrorVisible);
				NotifyOfPropertyChange(() => ErrorMessage);				
			}
		}

		

		/// <summary>
		/// Triggers an HTTP request to our API in order to make an authentication usgin the given UserName and Password.
		/// </summary>
		/// <returns></returns>
		public async Task LogIn()
		{
			try
			{
				ErrorMessage = "";
				var result = await _apiHelper.Authenticate(UserName, Password);

				//Capture more information about the user
				await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}

	}
}
