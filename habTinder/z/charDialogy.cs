using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habTinder {
	public class charDialogy : Frame {
		private Label _label;

		public charDialogy(string text) {
			_label = new Label { //vlastnosti textu
				FontFamily = "comic",
				FontSize = 20,
				BackgroundColor = Color.FromRgba("#f76da7"),
				Margin = new Thickness(25, 10, 25, 10),
				Text = text,
				TextColor = Color.FromRgba("#ffffff")
			};

			this.BorderColor = Color.FromArgb("#f76da7"); //vlastnosti rámečku
			this.CornerRadius = 45;
			this.Padding = new Thickness(10);
			this.Margin = new Thickness(10, 0, 100, 5);
			this.BackgroundColor = Color.FromArgb("#f76da7");

			this.Content = _label;
		}

		public string Text {
			get { return _label.Text; }
			set { _label.Text = value; }
		}
	}
}
