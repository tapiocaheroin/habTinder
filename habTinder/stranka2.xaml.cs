using Plugin.Maui.Audio;
using habTinder;
using habTinder.z;
using System.Diagnostics;

namespace habTinder;

public partial class stranka2 : ContentPage {
	
	private Jmeno mojeJmeno;
	private readonly IAudioManager audioManager;
	private IAudioPlayer player;
	private IAudioPlayer player1;
	private hudbaCas viewModel;

	int klikac = 0;

	public stranka2(Jmeno jmeno, IAudioManager audioManager, double CurrentPosition)
	{
		InitializeComponent();
		mojeJmeno = jmeno;
		this.audioManager = audioManager;
		viewModel = new hudbaCas();

	}
	protected async override void OnAppearing() {
		base.OnAppearing();

		double currentPosition = viewModel.CurrentPosition;

		player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("theme.wav"));
		player.Loop = true;
		player.Seek(currentPosition);

		entry1.Placeholder = mojeJmeno.jmeno;

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

	private async void dislike_Clicked(object sender, EventArgs e) {
		if (klikac == 0) {

			await dislike.ScaleTo(1.2, 100);
			await dislike.ScaleTo(1, 100);

			klikac = 1;


			await char1.FadeTo(0, 1000);


			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();
		} 
		else if (klikac == 1){
			klikac++;

			await layout1.FadeTo(0.5, 1000);
			await text1.FadeTo(1, 1000);
			layout1.IsEnabled = true;
			await Task.Delay(1000);
			await text1.FadeTo(0, 1000);
			await layout1.FadeTo(0, 1000);
			layout1.IsEnabled = false;

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();
		}
		else if (klikac == 2) {
			klikac++;

			await layout1.FadeTo(0.5, 1000);
			await text2.FadeTo(1, 1000);
			layout1.IsEnabled = true;
			await Task.Delay(1000);

			await layout1.FadeTo(0, 1000);
			await text2.FadeTo(0, 1000);

			layout1.IsEnabled = false;

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();
		} else{

			await layout1.FadeTo(0.5, 1000);
			await text3.FadeTo(1, 1000);

			layout1.IsEnabled = true;
			await Task.Delay(1000);

			await layout1.FadeTo(0, 1000);
			await text3.FadeTo(0, 1000);

			layout1.IsEnabled = false;

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();

		}
	}

	private async void like_Clicked(object sender, EventArgs e) {
		if (klikac == 0) {

			await like.ScaleTo(1.2, 100);
			await like.ScaleTo(1, 100);

			klikac = 1;
			await char1.FadeTo(0, 1000);



			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();
		} else {

			await like.ScaleTo(1.2, 100);
			await like.ScaleTo(1, 100);

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();

			await layout1.FadeTo(0.5, 1000);
			await layout2.FadeTo(1, 1000);
			await kolo1.FadeTo(0, 1000);

			heart.IsEnabled = true;
			icon.IsEnabled = true;
			dislike.IsEnabled = false;
			like.IsEnabled = false;
			layout1.IsEnabled = true;
			layout2.IsEnabled = true;
			kolo1.IsVisible = false;

			Vibration.Vibrate();

		}
	}

	private async void icon_Clicked(object sender, EventArgs e) {
		stranka3 stranka3 = new stranka3(mojeJmeno, audioManager, CurrentPosition);
		await Navigation.PushAsync(stranka3);


	}

	private async void heart_Clicked(object sender, EventArgs e) {
		stranka3 stranka3 = new stranka3(mojeJmeno, audioManager, CurrentPosition);
		await Navigation.PushAsync(stranka3);
	}

	private async void kolo_Clicked(object sender, EventArgs e) {
		kolo1.IsEnabled=false;
		kolo1.Opacity = 0;
		kolo1.IsVisible=false;
		nastaveni2.IsVisible = true;
		nastaveni2.Opacity = 1;
		nastaveni2.IsEnabled=true;
		nastaveni1.Opacity = 1;
		nastaveni1.IsEnabled=true;
		scrollView.IsEnabled=true;
		scrollView.Opacity = 1;
		obrazky.IsEnabled=true;
		entry2.IsEnabled=true;
		entry3.IsEnabled=true;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();
	}

	private async void kolo2_Clicked(object sender, EventArgs e) {
		kolo1.IsEnabled = true;
		kolo1.Opacity = 1;
		kolo1.IsVisible = true;

		nastaveni2.IsVisible=true;

		nastaveni2.Opacity = 0;
		nastaveni2.IsEnabled = false;
		nastaveni1.Opacity = 0;
		nastaveni1.IsEnabled = false;
		scrollView.IsEnabled = false;
		scrollView.Opacity = 0;
		obrazky.IsEnabled = false;
		entry2.IsEnabled = false;
		entry3.IsEnabled = false;
		like.IsEnabled = true;
		dislike.IsEnabled = true;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();
	}

	private async void obrazky_Clicked(object sender, EventArgs e) {
		var vysledek = await MediaPicker.PickPhotoAsync();
		{
			if (vysledek == null) {
				return;
			}
			ImageSource imageSource = ImageSource.FromStream(() => vysledek.OpenReadAsync().Result);
			this.vybrany.Source = imageSource;
			this.vybrany.IsVisible = true;

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();
		}

	}
}
