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
		#region Show
		/// <summary>
		/// вывод массива <see cref="array"/> в консоль.
		/// </summary>
		public void Show()
		{
			for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " "); //вывод всего массива в строку.
			Console.WriteLine(); //перемещение курсора на следующую строку при выводе всего массива.
		}
		/// <summary>
		/// вывод массива указанного в параметрах в консоль.
		/// </summary>
		/// <param name="array">массив который надо вывести на экран.</param>
		public static void Show(long[] array)
		{
			for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " "); //вывод всего массива в строку.
			Console.WriteLine(); //перемещение курсора на следующую строку при выводе всего массива.
		}
        #endregion
        #region NewArr
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
		/// <summary>
		/// создание нового массива и его элементов.
		/// </summary>
		/// <remarks>
		/// размер массива и его элементы случайны.
		/// </remarks>
		/// <param name="maxLength">максимальное количество элементов массива.</param>
		/// <param name="maxElement">максимальное значение элементов массива.</param>
		/// <returns></returns>
		public long[] NewArr(int maxLength, long maxElement)
		{
			array = new long[random.Next(maxLength)]; //создание нового массива случайного размера.
			for (int i = 0; i < array.Length; i++) array[i] = random.NextInt64(maxElement); //установка случайных элементов массива.
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
				Console.Write($"попытка рассортировать массив #{Iteration, 6}: ");
				Show(); //вывод массива.
				Shuffle(); //получение новоой расстановки массива.
				Iteration++; //установка следующей итерации.
			}
			Console.Write($"попытка рассортировать массив #{Iteration, 6}: "); //вывод сообщения удачной сортировки.
			Show(); //вывод сортированного массива.
			Console.WriteLine($"\nBogo Sort рассортировал все элементы с {Iteration} попытки."); //вывод окончательного сообщения.
		}
		#endregion
		#region changer
		#region Shuffle
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
		/// перестановка всех элементов массива указанного в параметрах случайным образом.
		/// </summary>
		/// <param name="array">массив, в котором надо осуществить перестановку.</param>
		/// <returns>перемешанный массив.</returns>
		public static long[] Shuffle(long[] array)
		{
			Random rnd = new Random(); //создание объекта рандома.
			for (int i = 0; i < array.Length; i++) //цикл по массиву.
			{
				int second = rnd.Next(array.Length); //получение случайной второй позиции.
				Swapper(ref array, i, second); //смена элементов на указанных позициях.
			}
			return array; //возврат перемешанного массива.
		}
		#endregion
		#region Swapper
		/// <summary>
		/// метод меняющий местами элементы в массиве <see cref="array"/>.
		/// </summary>
		/// <param name="pos1">первый элемент, который надо поменять местами со вторым элементом.</param>
		/// <param name="pos2">второй элемент, который надо поменять местами с первым элементом.</param>
		/// <exception cref="IndexOutOfRangeException"
		private void Swapper(int pos1, int pos2)
		{
			if (pos1 > array.Length || pos2 > array.Length || pos1 < 0 || pos2 < 0) throw new IndexOutOfRangeException(); //если позиции вышли за рамки массива - выбрасывание исключения.
			(array[pos2], array[pos1]) = (array[pos1], array[pos2]); //смена позиций массива.
		}
		/// <summary>
		/// метод меняющий местами элементы в массиве указанном в параметрах.
		/// </summary>
		/// <param name="array">массив в котором надо поменять местами элементы.</param>
		/// <param name="pos1">первый элемент, который надо поменять местами со вторым элементом.</param>
		/// <param name="pos2">второй элемент, который надо поменять местами с первым элементом.</param>
		/// <exception cref="IndexOutOfRangeException"/>
		public static void Swapper(ref long[] array, int pos1, int pos2)
		{
			if (pos1 > array.Length || pos2 > array.Length || pos1 < 0 || pos2 < 0) throw new IndexOutOfRangeException(); //если позиции вышли за рамки массива - выбрасывание исключения.
			(array[pos2], array[pos1]) = (array[pos1], array[pos2]); //смена позиций массива.
			
			//return array;
		}
		/// <summary>
		/// метод меняющий местами элементы в массиве указанном в параметрах.
		/// </summary>
		/// <param name="array">массив в котором надо поменять местами элементы.</param>
		/// <param name="pos1">первый элемент, который надо поменять местами со вторым элементом.</param>
		/// <param name="pos2">второй элемент, который надо поменять местами с первым элементом.</param>
		/// <exception cref="IndexOutOfRangeException"/>
		public static long[] Swapper(long[] array, int pos1, int pos2)
		{
			if (pos1 > array.Length || pos2 > array.Length || pos1 < 0 || pos2 < 0) throw new IndexOutOfRangeException(); //если позиции вышли за рамки массива - выбрасывание исключения.
			(array[pos2], array[pos1]) = (array[pos1], array[pos2]); //смена позиций массива.
			return array;
		}
		#endregion
		#endregion
		#endregion
	}
}