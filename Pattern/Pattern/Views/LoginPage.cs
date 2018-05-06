using Xamarin.Forms;

namespace Pattern.Views
{
	public class LoginPage : TemplatePage
	{
		public LoginPage(IWorkflow navigation) : base(navigation) { }

		protected override void Build()
		{
			Validate();
			base.Build();
		}

		void Validate()
		{
			_isValid = _username?.Length >= 8
						&& _password?.Length >= 8;
		}

		Command LoginCommand => new Command(async () =>
		{
			Build();

			if (_isValid)
				await _navigation.Navigate(this, "Authenticated", null);
		});

		void UpdateEntry(string value)
		{
			_username = value;
			Build();
		}
		void PasswordEntry(string value)
		{
			_password = value;
			Build();
		}

		// State
		string _username = null;
		string _password = null;
		bool _isValid = false;

		protected override View BuildView()
		{
			return new StackLayout()
			{
				Children = {
					new Entry() { AutomationId="UsernameEntry", Text=_username }.TextUpdated(UpdateEntry),
					new Entry() { AutomationId="PasswordEntry", IsPassword = true, Text=_password }.TextUpdated(PasswordEntry),
					new Button() { Text = "Login", Command=LoginCommand, AutomationId="LoginButton", IsEnabled = _isValid }
				}
			};
		}
	}
}