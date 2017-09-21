using System;
using UIKit;
using CoreGraphics;

namespace TipCalculator
{
    public class MyViewController : UIViewController
    {
        UITextField totalAmount;
        UISegmentedControl tipAmount;
        UILabel resultLabel;

        public MyViewController()
        {
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.View.BackgroundColor = UIColor.Yellow;

            totalAmount = new UITextField(new CGRect(20, 28, View.Bounds.Width-40, 35)) {
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Enter Total Amount"
            };

            UIButton calcButton = new UIButton(UIButtonType.Custom) {
                Frame = new CGRect(20, 71, View.Bounds.Width - 40, 45),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),
            };
            calcButton.SetTitle("Calculate", UIControlState.Normal);

            // HOMEWORK: add Tip Amount
            tipAmount = new UISegmentedControl(new CGRect(20, 124, View.Bounds.Width - 40, 40));
            tipAmount.InsertSegment("10%", 0, false);
            tipAmount.InsertSegment("15%", 1, false);
            tipAmount.InsertSegment("20%", 2, false);
            tipAmount.InsertSegment("25%", 3, false);
            tipAmount.SelectedSegment = 2;
            // HOMEWORK

            resultLabel = new UILabel(new CGRect(0, 172, View.Bounds.Width, 40)) {
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(24),
                Text = "Tip is $0.00"
            };

            View.AddSubviews(totalAmount, calcButton, tipAmount, resultLabel);
            
            calcButton.TouchUpInside += CalculateTip;            
            tipAmount.ValueChanged += CalculateTip;
        }

        void CalculateTip(object sender, EventArgs e)
        {
            totalAmount.ResignFirstResponder();

            // HOMEWORK: get tip amount
            double tipPercent = (10f + (tipAmount.SelectedSegment * 5));

            double value = 0;
            Double.TryParse(totalAmount.Text, out value);
			resultLabel.Text = string.Format("Tip is {0:C}", TipCalculator.GetTip(value, tipPercent));
        }
    }
}