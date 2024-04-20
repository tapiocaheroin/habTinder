using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habTinder.z
{
	public class hudbaCas : INotifyPropertyChanged {
		private double currentPosition;

		public double CurrentPosition {
			get => currentPosition; //vrací aktuální hodnotu
			set {
				if (currentPosition != value) { //ověřuje zda se hodnota změnila
					currentPosition = value; //nová hodnota
					OnPropertyChanged(nameof(CurrentPosition)); //aktualizace hodnoty
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged; //definice události

		protected virtual void OnPropertyChanged(string propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //vyvolání událostí o změně 
		}
	}
}
