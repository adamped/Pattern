using Pattern.Views;
using Xunit;

namespace Pattern.Tests
{
	public class AppTests
	{
		readonly App _app;
		readonly LoginPage _loginPage;

		public AppTests()
		{
			XamarinFormsMock.Init();
			_app = new App();
			_loginPage = new LoginPage(_app);
		}

		[Fact]
		public async void LoginPage_Navigation()
		{
			await _app.Navigate(_loginPage, "Authenticated", null);
			Assert.IsType<MainPage>(_app.MainPage);
		}
	}
}
