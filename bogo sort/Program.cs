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
			ShowInfo();
			do
			{
				bogo = new Bogo(InpMass()); //new int[] { 20, 19, 5, 1, 265, 246, 22, 272, 2, 1346, 26, 7, 54, 3 }
				bogo.Start();
				Console.Write("restart? y/n");
				do { key = Console.ReadKey(true); } while (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N);
				Console.WriteLine();
			} while (key.Key == ConsoleKey.Y);
		}
		/// <summary>
		/// вывод информации о программе в консоль.
		/// </summary>
		private static void ShowInfo() 
		{
			Console.Write("\tсортировка \"");
			WriteBogo();
			Console.WriteLine("\"!\n");
			Console.Write("что такое сортировка ");
			WriteBogo();
			Console.WriteLine("? а ты что, не умеешь искать в инете?\nладно, расскажу.\n");
			Console.WriteLine("Bogo проверяет массив, на то, как он рассортирован.");
			Console.WriteLine("если в массиве окажется элемент не по порядку возрастания, ");
			Console.WriteLine("то Bogo перемешивает массив случайным образом, и снова пытается его проверить.");
			Console.WriteLine("повторять это он будет до тех пор, пока ему не выпадет случайно рассортированный массив.\n\n");
		}
		/// <summary>
		/// ввод массива из консоли.
		/// </summary>
		/// <returns>массив введённый в консоли типа <see cref="int"/>.</returns>
		public static int[] InpMass()
		{
			int length;
			int[] massive;
			do { Console.Write("введите размер массива: "); } while (!int.TryParse(Console.ReadLine(), out length));
			massive = new int[length];
			Console.WriteLine("введите элементы массива.");
			for (int i = 0; i < massive.Length; i++)
			{
				while (true)
				{
					try
					{
						if (i == massive.Length - 1) Console.WriteLine("последний элемент. после него сразу же запустится сортировка введённого массива.");
						Console.Write($"элемент #{i}: ");
						massive[i] = int.Parse(Console.ReadLine());
						break;
					}
					//catch (FormatException ex)
					//{
					//	Console.Write("для кого были созданы цифры?\nя, конечно, не уверен, но мне кажется в ");
					//	WriteBogo();
					//	Console.WriteLine(" можно применять массивы с числами.\n" + ex.Message);
					//	continue;
					//}
					catch (OverflowException ex)
					{
						Console.WriteLine("не, ну, хотя бы за рамки типа int не выходи...\n"); //ex.Message
						continue;
					}
					catch //(Exception ex)
					{
						//Console.WriteLine("поздравляю. ты каким-то образом вызвал эту ошибку.\n" + ex.Message);
						continue;
					}
				}
			}

			return massive;
		}
		/// <summary>
		/// вывод словосочетания <see cref="Bogo">Bogo Sort</see> определённого цвета.
		/// </summary>
		public static void WriteBogo()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("Bogo Sort");
			Console.ResetColor();
		}
		/// <summary>
		/// вывод словосочетания <see cref="Bogo">Bogo Sort</see> цвета из параметров.
		/// </summary>
		/// <param name="color">цвет словосочетания.</param>
		public static void WriteBogo(ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write("Bogo Sort");
			Console.ResetColor();
		}
	}
}