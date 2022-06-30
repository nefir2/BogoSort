using System;
namespace bogo_sort
{
	internal class Program
	{
		/// <summary>
		/// точка входа программы.
		/// </summary>
		private static void Main()
		{
			ConsoleKeyInfo key;
			Bogo bogo;
			//int[] x = new int[10];
			//x[11] = 0;
			do
			{
				bogo = new Bogo(new long[] { 20, 19, 5, 1, 265, 246, 22, 272, 2, 1346, 26, 7, 54, 3 }); //6 000 000 попыток потратил на то чтобы рассортировать это как надо.
				bogo.Start();
				Console.Write("restart?\n1.yes\n2.no\nchoice: ");
				do { key = Console.ReadKey(true); } while (key.KeyChar != '1' && key.KeyChar != '2');
				Console.WriteLine();
			} while (key.KeyChar == '1');
		}
	}
}