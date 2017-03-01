using System;
namespace TextRecognizer
{
	public class Neuron
	{
		public int[,] Weight;
		public int limit = 100;
		public int Sum;

		public void SetPattern(int[,] pattern)
		{
			Weight = new int[pattern.GetLength(0), pattern.GetLength(1)];
		}

		public void Study(int[,] input)
		{
			for (int i = 0; i < input.GetLength(0); i++)
			{
				for (int a = 0; a < input.GetLength(1); a++)
				{
					Weight[i, a] += input[i, a];
				}
			}
		}

		public void Recognize(int[,] input)
		{
			Sum = 0;
			for (int i = 0; i < input.GetLength(0); i++)
			{
				for (int a = 0; a < input.GetLength(1); a++)
				{
					Sum += input[i, a] * Weight[i, a];
				}
			}
		}
	}
}
