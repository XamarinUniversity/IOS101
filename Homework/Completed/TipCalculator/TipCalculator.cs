namespace TipCalculator
{
	public static class TipCalculator
	{
		public static double GetTip(double amount, double percentage)
		{
			return amount * percentage / 100.0;
		}
	}
}