namespace bogo_sort
{
	public  class Program
	{
		/// <summary>
		/// точка входа программы.
		/// </summary>
		static void Main()
		{
			Bogo bogo = new Bogo(new long[] {2, 1, 3, 4, 5}); //6 000 000 попыток потратил на то чтобы рассортировать это как надо.
			bogo.Start();
		}
	}
}