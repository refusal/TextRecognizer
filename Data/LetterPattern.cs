using System;
using SQLite;

namespace TextRecognizer
{
	public class LetterPattern
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int[,] Pattern { get; set; }
	}
}
