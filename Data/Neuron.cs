using System;
namespace TextRecognizer
{
	public class Neuron
	{
		public int[,] mul;
		public int[,] weight;
		public int[,] input;
		public int limit = 9;
		public int sum;

		public Neuron(int sizex, int sizey, int[,] inP)
		{
			weight = new int[sizex, sizey];
			mul = new int[sizex, sizey];

			input = new int[sizex, sizey];
			input = inP;
		}

		public void mul_w()
		{
			for (int x = 0; x <= 9; x++)
			{
				for (int y = 0; y <= 9; y++)
				{
					mul[x, y] = input[x, y] * weight[x, y];
				}
			}
		}

		public void Sum()
		{
			sum = 0;
			for (int x = 0; x <= 9; x++)
			{
				for (int y = 0; y <= 9; y++)
				{
					sum += mul[x, y];
				}
			}
		}

		public bool Rez()
		{
			if (sum >= limit)
				return true;
			else return false;
		}
		public void incW(int[,] inP)
		{
			for (int x = 0; x <= 9; x++)
			{
				for (int y = 0; y <= 9; y++)
				{
					weight[x, y] += inP[x, y];
				}
			}
		}
		public void decW(int[,] inP)
		{
			for (int x = 0; x <= 9; x++)
			{
				for (int y = 0; y <= 9; y++)
				{
					weight[x, y] -= inP[x, y];
				}
			}
		}

	}
}
