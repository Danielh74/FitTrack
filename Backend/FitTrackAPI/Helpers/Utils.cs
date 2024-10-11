namespace FitTrackAPI.Helpers
{
	public class Utils
	{
		public static double BodyFatPercentage(double waist, double hips, double neck, int height, string gender)
		{
			double result;
			if (gender == "Male")
			{
				result =  (86.010 * Math.Log10(waist - neck)) - (70.041 * Math.Log10(height)) + 36.76;
			}
			else
			{
				result = (163.205 * Math.Log10(waist + hips - neck)) - (97.684 * Math.Log10(height)) - 78.387;
			}

			return Math.Round(result,2);
		}

		public static string UserFullName(string firstName, string lastName)
		{
			return string.Join(" ", firstName,lastName);
		}
	}
}
