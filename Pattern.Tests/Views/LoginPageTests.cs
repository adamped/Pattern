using Moq;
using Pattern.Views;
using Xamarin.Forms;
using Xunit;

namespace Pattern.Tests.Views
{
	public class LoginPageTests
	{
		readonly Mock<IWorkflow> _workflowMock;
		readonly LoginPage _loginPage;
		public LoginPageTests()
		{
			XamarinFormsMock.Init();
			_workflowMock = new Mock<IWorkflow>();
			_loginPage = new LoginPage(_workflowMock.Object);
		}

		readonly string UsernameEntry = "UsernameEntry";
		readonly string PasswordEntry = "PasswordEntry";
		readonly string LoginButton = "LoginButton";

		[Theory]
		[InlineData("12345678", "Password", true)]
		public void Validate_Username(string username, string password, bool isValid)
		{
			// Valid - configuration
			// Username - Min 8 characters
			// Password = Min 8 characters

			var view = _loginPage.Content;

			var usernameEntry = view.GetElementByName<Entry>(UsernameEntry);
			var passwordEntry = view.GetElementByName<Entry>(PasswordEntry);
			var buttonEntry = view.GetElementByName<Button>(LoginButton);

			// Initial Checks
			Assert.False(buttonEntry.IsEnabled);
			Assert.True(passwordEntry.IsPassword);
			Assert.Null(usernameEntry.Text);
			Assert.Null(passwordEntry.Text);

			// Act
			usernameEntry.Text = username;
			passwordEntry.Text = password;

			// Get new UI (this is only applicable because I'm not using Frank's Immutable UI)
			view = _loginPage.Content;
			buttonEntry = view.GetElementByName<Button>(LoginButton);

			// Assert
			Assert.Equal(isValid, buttonEntry.IsEnabled);

		}

		[Fact]
		public void Validate_Navigation()
		{
			var view = _loginPage.Content;

			// Valid Page
			var usernameEntry = view.GetElementByName<Entry>(UsernameEntry);
			var passwordEntry = view.GetElementByName<Entry>(PasswordEntry);
			usernameEntry.Text = "12345678";
			passwordEntry.Text = "12345678";

			var buttonEntry = view.GetElementByName<Button>(LoginButton);
			buttonEntry.Command.Execute(null);

			_workflowMock.Verify(x => x.Navigate(_loginPage, "Authenticated", null));
		}
	}
}