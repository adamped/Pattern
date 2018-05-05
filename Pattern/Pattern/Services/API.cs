using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Services
{
	public interface IAPI
	{
		string GetData();
	}

	public class API : IAPI
	{
		public string GetData()
		{
			return "Some fake data";
		}
	}
}
