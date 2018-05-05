using Pattern.Views;
using Xamarin.Forms;
using Xunit;

namespace Pattern.Tests
{
	public class AppTests
	{

		[Fact]
		public async void LoginPageNavigation()
		{
			XamarinFormsMock.Init();
			App _app = new App();
			LoginPage _loginPage = new LoginPage(_app);

			await _app.Navigate(_loginPage, "Authenticated", null);

			Assert.IsType<MainPage>(_app.MainPage);
		}

	}
}
