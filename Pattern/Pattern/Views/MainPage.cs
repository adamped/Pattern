using Xamarin.Forms;

namespace Pattern.Views
{
	public class MainPage: ContentPage
    {
		readonly IWorkflow _navigation;

		// Build UI
		public MainPage(IWorkflow navigation)
		{
			_navigation = navigation;
			Build();
		}
		void Build()
		{			
			Content = BuildView();
		}

		View BuildView()
		{
			return new StackLayout()
			{
				Children = {
					new Label() { Text = "Main", AutomationId="Count" },
					new Label() { Text = "Something" }
				}
			};
		}
	}
}
