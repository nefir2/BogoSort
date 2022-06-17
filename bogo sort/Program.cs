namespace bogo_sort
{
	public  class Program
	{
		/// <summary>
		/// точка входа программы.
		/// </summary>
		static void Main()
		{
			Bogo bogo = new Bogo(new long[] {5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5}); //6 000 000 попыток потратил на то чтобы рассортировать это как надо.
			bogo.Start();
		}
	}
}