using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maui.Dispatching;

namespace habTinder.z {
	public class hudba {
		private static readonly AudioManager instance = new AudioManager(); //deklarace AudioManager do třídy

		public IAudioPlayer AudioPlayer { get; private set; } //přístup k přehrávání hudby

		static hudba() { }

		private hudba() {
			IAudioManager audioManager = AudioManager.Current; 
			AudioPlayer = audioManager.CreatePlayer("theme.wav");
		}

		public static AudioManager Instance { //přístup k instanci
			get { return instance; }
		}
	} 
}