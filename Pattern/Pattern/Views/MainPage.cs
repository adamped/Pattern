using Xamarin.Forms;

namespace Pattern.Views
{
	public class MainPage: TemplatePage
    {
		public MainPage(IWorkflow navigation) : base(navigation) { }
		
		protected override View BuildView()
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
