using System;


namespace Ritmodelanoche
{
	 class ValidateTouch
	{

		public ValidateTouch ()
		{
			

		}

		public static int Timercorrect ()
		{
			Random random = new Random();
			int numcorrect = (int)Math.Round(random.NextDouble() * 3);
			return numcorrect;
		}


	}
}

