using Xamarin.Forms;

namespace Pattern.Views
{
	public class LoginPage : ContentPage
	{
		readonly IWorkflow _navigation;

		// Build UI
		public LoginPage(IWorkflow navigation)
		{
			_navigation = navigation;
			Build();
		}
		void Build()
		{
			Validate();
			Content = BuildView();
		}

		void Validate()
		{
			_isValid = _count > 10;
		}

		// Reactive
		Command IncrementCommand => new Command(async () =>
		{
			_count++;
			Build();

			if (_isValid)
				await _navigation.Navigate(this, "Login", null);
		});

		// State
		int _count = 0;
		bool _isValid = false;

		View BuildView()
		{
			return new StackLayout()
			{
				Children = {
					new Label() { Text = _count.ToString(), AutomationId="Count" },
					new Label() { Text = _isValid.ToString() },
					new Button() { Text = "Increment", Command=IncrementCommand }
				}
			};
		}
	}
}