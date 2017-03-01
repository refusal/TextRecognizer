// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TextRecognizer
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		TextRecognizer.DrawView DrawHolder { get; set; }

		[Outlet]
		UIKit.UIView LabelHolder { get; set; }

		[Outlet]
		UIKit.UIButton LearnButton { get; set; }

		[Outlet]
		UIKit.UIButton RecognizeButton { get; set; }

		[Outlet]
		UIKit.UITextField StudingLetterTextField { get; set; }

		[Outlet]
		UIKit.UILabel TextLabel { get; set; }

		[Action ("ClearButtonClick:")]
		partial void ClearButtonClick (Foundation.NSObject sender);

		[Action ("LearnButtonClick:")]
		partial void LearnButtonClick (Foundation.NSObject sender);

		[Action ("RecognizeButtonClick:")]
		partial void RecognizeButtonClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (DrawHolder != null) {
				DrawHolder.Dispose ();
				DrawHolder = null;
			}

			if (LabelHolder != null) {
				LabelHolder.Dispose ();
				LabelHolder = null;
			}

			if (LearnButton != null) {
				LearnButton.Dispose ();
				LearnButton = null;
			}

			if (RecognizeButton != null) {
				RecognizeButton.Dispose ();
				RecognizeButton = null;
			}

			if (TextLabel != null) {
				TextLabel.Dispose ();
				TextLabel = null;
			}

			if (StudingLetterTextField != null) {
				StudingLetterTextField.Dispose ();
				StudingLetterTextField = null;
			}
		}
	}
}
