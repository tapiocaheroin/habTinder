using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habTinder.z {
	public class uzivatelDialogy : Frame {
		private Label _label;

		public uzivatelDialogy(string text) {
			_label = new Label {
				FontFamily = "comic",
				FontSize = 20,
				BackgroundColor = Color.FromRgba("#6DF7BD"),
				Margin = new Thickness(25, 10, 25, 10),
				Text = text,
				TextColor = Color.FromRgba("#ffffff")
			};

			this.BorderColor = Color.FromArgb("#6DF7BD");
			this.CornerRadius = 45;
			this.Padding = new Thickness(10);
			this.Margin = new Thickness(100, 0, 10, 5);
			this.BackgroundColor = Color.FromArgb("#6DF7BD");

			this.Content = _label;
		}

		public string Text {
			get { return _label.Text; }
			set { _label.Text = value; }
		}
	}
}
