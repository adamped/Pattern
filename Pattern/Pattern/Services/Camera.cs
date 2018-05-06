namespace Pattern.Services
{
	// Hardware Services

	public interface ICamera
	{
		byte[] TakePicture();
	}

    public class Camera: ICamera
    {
		public byte[] TakePicture()
		{
			throw new System.NotImplementedException();
		}
	}
}
