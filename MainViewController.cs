using System;
using System.Collections.Generic;
using System.IO;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TextRecognizer
{
	public partial class MainViewController : UIViewController
	{
		private string _pathToDatabase;
		int[,] currentMatrix;
		public MainViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
		{
		}

		protected MainViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			InitViewObjects();
			InitDataBase();
		}

		private void InitDataBase()
		{
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			_pathToDatabase = Path.Combine(documents, "db_sqlite-net.db");
			currentMatrix = new int[,] { };
		}

		private void InitViewObjects()
		{
			LabelHolder.Layer.CornerRadius = 10;
			LabelHolder.Layer.BorderWidth = 1;
			LabelHolder.Layer.BorderColor = UIColor.FromRGB(110, 120, 235).CGColor;

			DrawHolder.Layer.CornerRadius = 20;
			DrawHolder.Layer.BorderWidth = 2;
			DrawHolder.Layer.BorderColor = UIColor.FromRGB(110, 120, 235).CGColor;

			RecognizeButton.Layer.CornerRadius = 10;
			RecognizeButton.Layer.BorderWidth = 1;
			RecognizeButton.Layer.BorderColor = UIColor.FromRGB(110, 120, 235).CGColor;

			LearnButton.Layer.CornerRadius = 10;
			LearnButton.Layer.BorderWidth = 1;
			LearnButton.Layer.BorderColor = UIColor.FromRGB(110, 120, 235).CGColor;
		}

		partial void ClearButtonClick(Foundation.NSObject sender)
		{
			DrawHolder.Path = new CGPath();
			DrawHolder.CurrentPoint = new CGPoint();
			DrawHolder.SetNeedsDisplay();
		}

		partial void LearnButtonClick(Foundation.NSObject sender)
		{
			var letter = new LetterPattern {};
			var a=ConvertArrayToString(currentMatrix);
			ConvertStringToArray(a,10);
			//using (var db = new SQLite.SQLiteConnection(_pathToDatabase))
			//{
			//	//db.Insert(person);
			//}
		}

		partial void RecognizeButtonClick(Foundation.NSObject sender)
		{
			currentMatrix = SimplifyImage((int)DrawHolder.Frame.Width, (int)DrawHolder.Frame.Height, 60, DrawHolder.AllPoints);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		private int[,] SimplifyImage(int width, int height, int step, IEnumerable<CGPoint> points)
		{
			int[,] matrix = new int[width / step, height / step];

			for (int i = step; i <= width; i += step)
			{
				for (int a = step; a <= height; a += step)
				{
					foreach (var point in points)
					{
						if (point.X < i && point.X >= i - step && point.Y < a && point.Y >= a - step)
						{
							matrix[(a / step) - 1, (i / step) - 1] = 1;
							break;
						}
					}
				}
			}
			return matrix;
		}

		private string ConvertArrayToString(int[,] array)
		{
			string s="";
			foreach (var item in array)
			{
				s += item.ToString();
			}
			return s;
		}

		private int[,] ConvertStringToArray(string s, int step)
		{
			int[,] matrix = new int[step, step];
			int index = 0;
			for (int i = 0; i < step; i++)
			{
				for (int a = 0; a < step; a++)
				{
					matrix[i, a] = Int32.Parse(s[index].ToString());
					index++;
				}
			}
			return matrix;
		}
	}
}

