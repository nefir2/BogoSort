using System;
namespace bogo_sort
{
	/// <summary>
	/// представление сортировщика Bogo.
	/// </summary>
	public class Bogo
	{
		#region fields
		/// <summary>
		/// объект случайного числа.
		/// </summary>
		private readonly Random random = new Random();
		/// <summary>
		/// поле с массивом.
		/// </summary>
		private long[] array;
		#endregion
		#region properties
		/// <summary>
		/// количество итераций сделанных Bogo Sort.
		/// </summary>
		public int Iteration { get; private set; } = 1;
		#endregion
		#region constructors
		/// <summary>
		/// создание нового массива в поле <see cref="array"/>.
		/// </summary>
		public Bogo()
		{
			array = NewArr(); //инициализация массива.
		}
		/// <summary>
		/// установка массива через параметры в поле <see cref="array"/>.
		/// </summary>
		/// <param name="array"></param>
		public Bogo(long[] array)
		{
			this.array = array; //установка указанного массива в поле класса.
		}
		#endregion
		#region methods
		#region outp
		/// <summary>
		/// вывод массива <see cref="array"/> в консоль.
		/// </summary>
		public void Show()
		{
			for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " "); //вывод всего массива в строку.
			Console.WriteLine(); //перемещение курсора на следующую строку при выводе всего массива.
		}
		#endregion
		#region array init
		/// <summary>
		/// создание нового массива и его элементов.
		/// </summary>
		/// <remarks>
		/// размер массива и его элементы случайны.
		/// </remarks>
		public long[] NewArr()
		{
			array = new long[random.Next(100)]; //создание нового массива случайного размера.
			for (int i = 0; i < array.Length; i++) array[i] = random.Next(1000); //установка случайных элементов массива.
			return array;
		}
		#endregion
		#region bogo
		/// <summary>
		/// проверка на то, совпала ли позиция каждого элемента массива относительно других элементов.
		/// </summary>
		/// <returns>
		/// возвращается <see langword="true"/>, если все элементы массива расставлены в правильном порядке, иначе возвращается <see langword="false"/>.
		/// </returns>
		public bool BogoCheck()
		{
			for (int i = 0; i < array.Length - 1; i++) //цикл по массиву.
			{
				if (array[i] > array[i + 1]) return false; //если нынешний элемент оказался больше следующего, выход из метода с возвратом false.
			}
			return true; //если цикл прошёл успешно, возврат true.
		}
		/// <summary>
		/// метод старта сортировки.
		/// </summary>
		public void Start()
		{
			while (!BogoCheck()) //проверка бого.
			{
				Console.Write($"попытка рассортировать массив #{Iteration}: ");
				Show(); //вывод массива.
				Shuffle(); //получение новоой расстановки массива.
				Iteration++; //установка следующей итерации.
			}
			Console.Write($"попытка рассортировать массив #{Iteration}: "); //вывод сообщения удачной сортировки.
			Show(); //вывод сортированного массива.
			Console.WriteLine($"\nBogo Sort рассортировал все элементы с {Iteration} попытки."); //вывод окончательного сообщения.
		}
		#endregion
		#region changer
		/// <summary>
		/// перестановка всех элементов массива <see cref="array"/> случайным образом.
		/// </summary>
		/// <returns>перемешанный массив.</returns>
		public void Shuffle()
		{
			for (int i = 0; i < array.Length; i++) //цикл по массиву.
			{
				int second = random.Next(array.Length); //получение случайной второй позиции.
				Swapper(i, second); //смена элементов на указанных позициях.
			}
			//return array; //возврат перемешанного массива.
		}
		/// <summary>
		/// метод меняющий местами элементы в массиве <see cref="array"/>.
		/// </summary>
		/// <param name="pos1">первый элемент, который надо поменять местами со вторым элементом.</param>
		/// <param name="pos2">второй элемент, который надо поменять местами с первым элементом.</param>
		private void Swapper(int pos1, int pos2)
		{
			if (pos1 > array.Length || pos2 > array.Length || pos1 < 0 || pos2 < 0) return; //если позиции вышли за рамки массива - выход из метода.
			(array[pos2], array[pos1]) = (array[pos1], array[pos2]); //смена позиций массива.
		}
		#endregion
		#endregion
	}
}