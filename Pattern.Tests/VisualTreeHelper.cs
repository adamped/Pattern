using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Pattern.Tests
{
    public static class VisualTreeHelper
    {
		public static T GetElementByName<T>(this View view, string name) where T : View
		{
			if (view.AutomationId == name && view is T)
				return (T)view;

			if (view is Layout<View> layout)
				foreach (var element in layout.Children)
				{
					var e = element.GetElementByName<T>(name);
					if (e != null)
						return e;
				}

			return null;
		}

    }
}
