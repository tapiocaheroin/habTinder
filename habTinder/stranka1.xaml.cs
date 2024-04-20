using Plugin.Maui.Audio;
using habTinder;
using habTinder.z;
namespace habTinder;

public partial class stranka1 : ContentPage
{
	private readonly IAudioManager audioManager;
	private IAudioPlayer player;
	private IAudioPlayer player1; 

	private hudbaCas viewModel;

	public stranka1(IAudioManager audioManager, double CurrentPosition)
	{
		InitializeComponent();

		this.audioManager = audioManager;
		viewModel = new hudbaCas();


	}

	protected async override void OnAppearing() {
		base.OnAppearing();

		double currentPosition = viewModel.CurrentPosition; //ukládá èas ve kterém je hudba

		player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("theme.wav"));
		player.Loop = true;
		player.Seek(currentPosition); //naèítá èas ve kterém je hudba


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

	private Jmeno mojeJmeno = new Jmeno();

	private async void Entry_TextChanged(object sender, TextChangedEventArgs e) {

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();
		if(entry.Text.Length >= 3) {
			button.Opacity = 1;
			button.IsEnabled = true;
		} 
	}
	private async void Entry_Unfocused(object sender, FocusEventArgs e) {
		if (entry.Text.Length < 3) {
			await DisplayAlert("!!!", "Make sure your name is longer than three letters!!!", "OK!!!");
		}
	}

	private async void Button_Clicked(object sender, EventArgs e) {

		if(button.Opacity == 0) {
			await DisplayAlert("!!!", "Write your name please!!!", "OK!!!"); 

		}else{
			mojeJmeno.jmeno = entry.Text;
			stranka2 stranka2 = new stranka2(mojeJmeno, audioManager, CurrentPosition);
			await Navigation.PushAsync(stranka2);

			double currentPosition = CurrentPosition;

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();

		}

	}
}