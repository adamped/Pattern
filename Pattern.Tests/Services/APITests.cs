using Pattern.Services;
using Xunit;

namespace Pattern.Tests.Services
{
	public class APITests
    {
		// Services are easy to test, you get the idea.

		[Fact]
		public void Authenticate()
		{
			var api = new API();
			Assert.True(api.Authenticate("test", "test"));
		}

    }
}
