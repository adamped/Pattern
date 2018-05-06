using Xamarin.Forms;

namespace Pattern.Views
{
	public abstract class TemplatePage: ContentPage
    {
		protected readonly IWorkflow _navigation;

		public TemplatePage(IWorkflow navigation)
		{
			_navigation = navigation;
			Build();
		}

		protected virtual void Build()
		{
			Content = BuildView();
		}

		protected abstract View BuildView();
	}
}
