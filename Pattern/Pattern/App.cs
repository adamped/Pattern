using Pattern.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pattern
{
	public interface IWorkflow
	{
		Task Navigate(Page page, string state, object parameter);
	}

	public class App : Application, IWorkflow
	{
		public App()
		{
			MainPage = new LoginPage(this);
		}

		public async Task Navigate(Page page, string state, object parameter)
		{
			if (page is LoginPage && state == "Authenticated")
				MainPage = new MainPage(this);
		}

	}
}