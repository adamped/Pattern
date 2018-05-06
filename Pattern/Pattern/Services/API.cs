namespace Pattern.Services
{
	// Repository Services

	public interface IAPI
	{
		bool Authenticate(string username, string password);
	}

	public class API : IAPI
	{
		public bool Authenticate(string username, string password)
		{
			return true;
		}
	}
}
