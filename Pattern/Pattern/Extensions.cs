using System;
using Xamarin.Forms;

namespace Pattern
{
	public static class Extensions
    {
		public static Entry TextUpdated(this Entry entry, Action<string> process)
		{
			entry.TextChanged += (s, e) => { process(e.NewTextValue); };
			return entry;
		}
	}
}
