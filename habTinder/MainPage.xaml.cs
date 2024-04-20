using habTinder.z;
using Plugin.Maui.Audio;
using System.Security.Cryptography.X509Certificates;

namespace habTinder {
	public partial class MainPage : ContentPage {

		private readonly IAudioManager audioManager;
		private IAudioPlayer player; 
		private IAudioPlayer player1; 

		private hudbaCas viewModel;

		public MainPage(IAudioManager audioManager) {
			InitializeComponent();

			this.audioManager = audioManager;
			viewModel = new hudbaCas();
		}

		protected async override void OnAppearing(){
        base.OnAppearing();

			if(player == null) {
				player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("theme.wav"));
				player.Loop = true;
				player.Play();
			} else {

			}


		}
		bool isPositionChangeSystemDriven;
		public double CurrentPosition {
			get => player?.CurrentPosition ?? 0;
			set {
				if (player is not null &&
					player.CanSeek &&
					isPositionChangeSystemDriven is false) {
					player.Seek(value);
				}
			}
		}



		private async void Button_Clicked(object sender, EventArgs e) {
			stranka1 stranka1 = new stranka1(audioManager, CurrentPosition);
			await Navigation.PushAsync(stranka1);

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();

			double currentPosition = CurrentPosition;



		}

		private async void Button_Clicked_1(object sender, EventArgs e) {
			System.Environment.Exit(0);

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();

		}
	}
}