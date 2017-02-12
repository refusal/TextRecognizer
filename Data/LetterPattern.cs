using System;
using SQLite;

namespace TextRecognizer
{
	public class LetterPattern
	{
		[PrimaryKey]
		public string ID { get; set; }
		public string Pattern { get; set; }
	}
}
