using System;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Collections.Generic;

namespace TextRecognizer
{
	[Register("DrawView")]
	public class DrawView : UIView
	{
		public CGPath Path;
		public CGPoint CurrentPoint;
		public CGPoint FirstPoint;
		public List<CGPoint> AllPoints = new List<CGPoint>();

		bool IsMove;

		public DrawView(IntPtr handle) : base(handle)
		{
			InitViewObjects();
		}

		public DrawView(NSCoder coder) : base(coder)
		{
			InitViewObjects();
		}

		public DrawView(CGRect rect) : base(rect)
		{
			InitViewObjects();
		}

		public DrawView()
		{
			InitViewObjects();
		}

		void InitViewObjects()
		{
			BackgroundColor = UIColor.White;
			Path = new CGPath();
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			IsMove = false;
			if (touch != null)
			{
				FirstPoint = touch.LocationInView(this);
			}
		}

		public override void TouchesMoved(NSSet touches, UIEvent evt)
		{
			base.TouchesMoved(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			IsMove = true;
			if (touch != null)
			{
				CurrentPoint = touch.LocationInView(this);
				SetNeedsDisplay();
			}
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			if (!IsMove)
			{
				CurrentPoint = FirstPoint;
				SetNeedsDisplay();
			}
		}

		public override void Draw(CGRect rect)
		{
			base.Draw(rect);

			using (CGContext g = UIGraphics.GetCurrentContext())
			{
				UIGraphics.BeginImageContext(new CGSize(this.Frame.Width, this.Frame.Height));

				CGPath currentPath = new CGPath();
				if (!CurrentPoint.IsEmpty)
				{
					currentPath.MoveToPoint(FirstPoint.X, FirstPoint.Y);
					currentPath.AddLineToPoint(CurrentPoint.X, CurrentPoint.Y);
					Path.AddPath(currentPath);
					AllPoints.Add(CurrentPoint);
				}

				UIColor.Black.SetStroke();
				g.SetLineWidth(10);
				g.SetLineCap(CGLineCap.Round);
				g.SetBlendMode(CGBlendMode.Normal);
				g.AddPath(Path);
				g.DrawPath(CGPathDrawingMode.FillStroke);

				UIGraphics.EndImageContext();
				FirstPoint = CurrentPoint;
			}
		}
	}
}
