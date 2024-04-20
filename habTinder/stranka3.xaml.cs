using Plugin.Maui.Audio;
using habTinder;
using habTinder.z;
using System.Threading.Tasks.Dataflow;

namespace habTinder;

public partial class stranka3 : ContentPage {

	private Jmeno mojeJmeno;
	private readonly IAudioManager audioManager;
	private IAudioPlayer player;
	private IAudioPlayer player1;
	private hudbaCas viewModel;
	private dialogy dialogy = new dialogy();

	private bool isAnimating = false;
	private int spravne = 0;

	private DateTime startTime;
	private DateTime endTime;
	private DateTime startTime1;
	private DateTime endTime1;

	private TimeSpan animationDuration;
	private int steps;
	private int currentStep;

	private TimeSpan animationDuration1;
	private int steps1;
	private int currentStep1;

	private bool kockaP = false;
	private bool hlavaP = false;
	private bool oblekP = false;

	public stranka3(Jmeno jmeno, IAudioManager audioManager, double CurrentPosition) {
		InitializeComponent();
		mojeJmeno = jmeno;
		this.audioManager = audioManager;
		viewModel = new hudbaCas();

		AnimateLoadingText();
		scrollView.ScrollToAsync(0, double.MaxValue, true);

		startTime = DateTime.Parse("14:00");
		endTime = DateTime.Parse("19:00");
		startTime1 = DateTime.Parse("20:00");
		endTime1 = DateTime.Parse("1:00");
		animationDuration = TimeSpan.FromSeconds(5);
		steps = (int)(endTime - startTime).TotalSeconds;
		currentStep = 0;
		animationDuration1 = TimeSpan.FromSeconds(5);
		steps1 = (int)(endTime - startTime).TotalSeconds;
		currentStep1 = 0;

	}
	protected async override void OnAppearing() {
		base.OnAppearing();

		double currentPosition = viewModel.CurrentPosition;

		player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("theme.wav"));
		player.Loop = true;
		player.Seek(currentPosition);


	}




	private async void AnimateLoadingText() {
		while (true) {
			if (isAnimating) {
				loadingLabel.Text = ".";
				await Task.Delay(500);

				loadingLabel.Text = "..";
				await Task.Delay(500);

				loadingLabel.Text = "...";
				await Task.Delay(500);

				loadingLabel.Text = "";
				await Task.Delay(500);
			} else {
				await Task.Delay(100); 
			}
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




	private async void jedna(object sender, EventArgs e) {
		jednaa.IsVisible = false;
		jedna1.Opacity = 0;
		jedna2.Opacity = 0;
		jedna1.IsEnabled = false;
		jedna2.IsEnabled = false;
		dva1.Opacity = 0;
		dva1.IsEnabled = false;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j0);
		lejout.Children.Add(customFrame);

		await Task.Delay(2300);

		isAnimating = true;

		await Task.Delay(3600);

		isAnimating = false;

		charDialogy customFrame1 = new charDialogy(dialogy.nope);
		lejout.Children.Add(customFrame1);

		await Task.Delay(1000);

		Label newLabel1 = new Label {
			FontFamily = "comic",
			FontSize = 20,
			BackgroundColor = Color.FromRgba("#f76da7"),
			Margin = new Thickness(10, 0, -10, 0),
			Text = "You cannot reply to this conversation, sorry.",
			TextColor = Color.FromRgba("#ffffff")
		};
		Frame border1 = new Frame {
			BorderColor = Color.FromArgb("#f76da7"),
			CornerRadius = 45,
			Padding = new Thickness(10),
			Margin = new Thickness(10, 0, 10, 5),
			BackgroundColor = Color.FromArgb("#f76da7")
		};

		border1.Content = newLabel1;
		lejout.Children.Add(border1);

		await Task.Delay(5000);

		stranka3 stranka3 = new stranka3(mojeJmeno, audioManager, CurrentPosition);
		await Navigation.PushAsync(stranka3);

	}












	private async void dva(object sender, EventArgs e) {
		jednaa.IsVisible = false;
		jedna1.Opacity = 0;
		jedna2.Opacity = 0;
		jedna1.IsEnabled = false;
		jedna2.IsEnabled = false;
		dva1.Opacity = 0;
		dva1.IsEnabled = false;
		spravne++;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j1);
		lejout.Children.Add(customFrame);

		await Task.Delay(2300);

		isAnimating = true;

		await Task.Delay(2600);

		isAnimating = false;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct.mp3"));
		player1.Play();


		charDialogy customFrame1 = new charDialogy(dialogy.s1);
		lejout.Children.Add(customFrame1);

		await Task.Delay(1000);
		isAnimating = true;
		await hvezda.FadeTo(1, 1000);
		await hvezda.FadeTo(0, 1000);

		await Task.Delay(1500);

		isAnimating = false;

		charDialogy customFrame2 = new charDialogy(dialogy.s2);
		lejout.Children.Add(customFrame2);

		await Task.Delay(2000);

		uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j2);
		lejout.Children.Add(customFrame3);

		await Task.Delay(1000);
		isAnimating = true;

		await Task.Delay(3500);

		isAnimating = false;

		charDialogy customFrame4 = new charDialogy(dialogy.s3);
		lejout.Children.Add(customFrame4);

		await Task.Delay(2000);
		await tri1.FadeTo(1, 500);
		await ctyri1.FadeTo(1, 500);
		tri1.IsEnabled = true;
		ctyri1.IsEnabled = true;
		dvaa.IsVisible = true;
	}












	private async void ctyri1_Clicked(object sender, EventArgs e) {
		//await bar2.FadeTo(0, 500);
		dvaa.IsVisible=false;
		tri1.IsEnabled = false;
		ctyri1.IsEnabled = false;
		tri1.Opacity = 0;
		ctyri1.Opacity = 0;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j3);
		lejout.Children.Add(customFrame);

		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2000);

		charDialogy customFrame1 = new charDialogy(dialogy.nope2);
		lejout.Children.Add(customFrame1);

		await Task.Delay(2000);

		uzivatelDialogy customFrame2 = new uzivatelDialogy(dialogy.j10);
		lejout.Children.Add(customFrame2);

		isAnimating = false;
		await Task.Delay(1000);

		uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j11);
		lejout.Children.Add(customFrame3);
		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(1000);

		uzivatelDialogy customFrame5 = new uzivatelDialogy(dialogy.j5);
		lejout.Children.Add(customFrame5);
		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(1000);
		isAnimating = true;

		await Task.Delay(2500);
		isAnimating=false;

		charDialogy customFrame4 = new charDialogy(dialogy.s6);
		lejout.Children.Add(customFrame4);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		await sest1.FadeTo(1, 500);
		await pet1.FadeTo(1, 500);
		sest1.IsEnabled = true;
		pet1.IsEnabled = true;
		trii.IsVisible = true;

	}










	private async void tri1_Clicked(object sender, EventArgs e) {
		//await bar2.FadeTo(0, 500);

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		dvaa.IsVisible = false;
		spravne++;
		tri1.IsEnabled = false;
		ctyri1.IsEnabled = false;
		tri1.Opacity = 0;
		ctyri1.Opacity = 0;

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j4);
		lejout.Children.Add(customFrame);


		await Task.Delay(1000);

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct.mp3"));
		player1.Play();
		isAnimating = true;
		await hvezda.FadeTo(1, 1000);
		await hvezda.FadeTo(0, 1000);

		await Task.Delay(300);

		charDialogy customFrame1 = new charDialogy(dialogy.s4);
		lejout.Children.Add(customFrame1);

		await Task.Delay(2100);

		charDialogy customFrame2 = new charDialogy(dialogy.s5);
		lejout.Children.Add(customFrame2);

		await Task.Delay(100);

		isAnimating = false;

		await Task.Delay(900);

		uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j5);
		lejout.Children.Add(customFrame3);


		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2500);

		charDialogy customFrame4 = new charDialogy(dialogy.s6);
		lejout.Children.Add(customFrame4);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		await sest1.FadeTo(1, 500);
		await pet1.FadeTo(1, 500);
		sest1.IsEnabled = true;
		pet1.IsEnabled = true;
		trii.IsVisible = true;
	}

	private async void pet1_Clicked(object sender, EventArgs e) {
		trii.IsVisible=false;
		pet1.IsEnabled = false;
		sest1.IsEnabled = false;
		pet1.Opacity = 0;
		sest1.Opacity = 0;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j7);
		lejout.Children.Add(customFrame);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);


		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2300);

		charDialogy customFrame1 = new charDialogy(dialogy.s9);
		lejout.Children.Add(customFrame1);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2800);

		isAnimating = false;

		charDialogy customFrame2 = new charDialogy(dialogy.s10);
		lejout.Children.Add(customFrame2);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		await osm1.FadeTo(1, 500);
		await sedm1.FadeTo(1, 500);
		sedm1.IsEnabled = true;
		osm1.IsEnabled = true;
		trii.IsVisible = true;
		ctyrii.IsVisible = true;
	}










	private async void sest1_Clicked(object sender, EventArgs e) {
		trii.IsVisible = false;
		pet1.IsEnabled = false;
		sest1.IsEnabled = false;
		pet1.Opacity = 0;
		sest1.Opacity = 0;
		spravne++;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j6);
		lejout.Children.Add(customFrame);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);


		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2300);

		charDialogy customFrame1 = new charDialogy(dialogy.s7);
		lejout.Children.Add(customFrame1);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct.mp3"));
		player1.Play();
		await hvezda.FadeTo(1, 1000);
		await hvezda.FadeTo(0, 1000);


		await Task.Delay(800);

		isAnimating = false;

		charDialogy customFrame2 = new charDialogy(dialogy.s8);
		lejout.Children.Add(customFrame2);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		await osm1.FadeTo(1, 500);
		await sedm1.FadeTo(1, 500);

		sedm1.IsEnabled = true;
		osm1.IsEnabled = true;
		ctyrii.IsVisible = true;

	}





	private async void osm1_Clicked(object sender, EventArgs e) {
		ctyrii.IsVisible = false;
		sedm1.IsEnabled = false;
		osm1.IsEnabled = false;
		sedm1.Opacity = 0;
		osm1.Opacity = 0;
		spravne++;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j9);
		lejout.Children.Add(customFrame);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(3200);

		charDialogy customFrame1 = new charDialogy(dialogy.s12);
		lejout.Children.Add(customFrame1);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2200);
		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct.mp3"));
		player1.Play();


		charDialogy customFrame2 = new charDialogy(dialogy.s13);
		lejout.Children.Add(customFrame2);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		isAnimating = false;
		await hvezda.FadeTo(1, 1000);
		await hvezda.FadeTo(0, 1000);

		await Task.Delay(10);

		uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j15);
		lejout.Children.Add(customFrame3);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1200);
		isAnimating=true;

		await Task.Delay(1900);
		isAnimating=false;
		charDialogy customFrame4 = new charDialogy(dialogy.s11);
		lejout.Children.Add(customFrame4);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);
		uzivatelDialogy customFrame5 = new uzivatelDialogy(dialogy.j16);
		lejout.Children.Add(customFrame5);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);
		uzivatelDialogy customFrame6 = new uzivatelDialogy(dialogy.j17);
		lejout.Children.Add(customFrame6);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);

		uzivatelDialogy customFrame10 = new uzivatelDialogy(dialogy.j12);
		lejout.Children.Add(customFrame10);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2800);

		charDialogy customFrame11 = new charDialogy(dialogy.s14);
		lejout.Children.Add(customFrame11);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);
		charDialogy customFrame12 = new charDialogy(dialogy.s15);
		lejout.Children.Add(customFrame12);
		isAnimating = false;

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);

		uzivatelDialogy customFrame13 = new uzivatelDialogy(dialogy.j13);
		lejout.Children.Add(customFrame13);
		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2800);

		charDialogy customFrame14 = new charDialogy(dialogy.s16);
		lejout.Children.Add(customFrame14);
		isAnimating = false;

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		await layout1.FadeTo(0.5, 1000);
		await layout2.FadeTo(1, 1000);
		layout1.IsEnabled = true;
		layout2.IsEnabled = true;


		await Task.Delay(1000);

		Vibration.Vibrate();

		timeLabel.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration.TotalMilliseconds / steps), () => {
			if (currentStep < steps) {
				currentStep++;
				timeLabel.Text = startTime.AddSeconds(currentStep).ToString("HH:mm");
				return true;
			} else {
				timeLabel.Text = endTime.ToString("HH:mm");
				return false;
			}
		});

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(1000);
		await layout1.FadeTo(0, 1000);
		await layout2.FadeTo(0, 1000);

		await Task.Delay(1000);
		uzivatelDialogy customFrame15 = new uzivatelDialogy(dialogy.j14);
		lejout.Children.Add(customFrame15);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);
		isAnimating = true;

		await Task.Delay(2000);
		isAnimating = false;
		charDialogy customFrame16 = new charDialogy(dialogy.s17);
		lejout.Children.Add(customFrame16);
		isAnimating = false;

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		Image newImage2 = new Image {
			Source = ImageSource.FromFile("char3.png"),
			Margin = new Thickness(25, 10, 25, 10),
			Aspect = Aspect.AspectFit,

		};

		Frame border2 = new Frame {
			BorderColor = Color.FromArgb("#f76da7"),
			CornerRadius = 45,
			Padding = new Thickness(10),
			Margin = new Thickness(10, 0, 100, 5),
			BackgroundColor = Color.FromArgb("#f76da7"),
		};

		border2.Content = newImage2;
		lejout.Children.Add(border2);

		newImage2.GestureRecognizers.Add(new TapGestureRecognizer {
			Command = new Command(async () => {

				player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
				player1.Play();

				devet1.IsEnabled = false;
				deset1.IsEnabled = false;
				pett.IsVisible = false;
				obleceni.IsVisible = true;
				hlava.IsVisible = true;
				kocka.IsVisible = true;



				oblecenii.GestureRecognizers.Add(new TapGestureRecognizer {
					Command = new Command(async () => {

						oblekP = true;
						spravne++;

						obleceni.IsVisible = false;
						hlava.IsVisible = false;
						kocka.IsVisible = false;

						uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j43);
						lejout.Children.Add(customFrame);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame1 = new uzivatelDialogy(dialogy.j44);
						lejout.Children.Add(customFrame1);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1500);

						charDialogy customFrame5 = new charDialogy(dialogy.s47);
						lejout.Children.Add(customFrame5);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1250);

						charDialogy customFrame6 = new charDialogy(dialogy.s48);
						lejout.Children.Add(customFrame6);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						charDialogy customFrame7 = new charDialogy(dialogy.s49);
						lejout.Children.Add(customFrame7);

						isAnimating = false;

						await Task.Delay(1100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame8 = new uzivatelDialogy(dialogy.j45);
						lejout.Children.Add(customFrame8);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await layout1.FadeTo(0.5, 1000);
						await layout3.FadeTo(1, 1000);
						layout1.IsEnabled = true;
						layout3.IsEnabled = true;


						timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
							if (currentStep1 < steps1) {
								currentStep1++;
								timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
								return true;
							} else {
								timeLabel1.Text = endTime1.ToString("HH:mm");
								return false;
							}
						});

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(1000);
						await layout1.FadeTo(0, 1000);
						await layout3.FadeTo(0, 1000);

						await Task.Delay(1000);

						if (spravne >= 1 && spravne <= 4) {
							await jedenact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							sestt.IsVisible = true;
						} else {
							await jedenact1.FadeTo(1, 500);
							await dvanact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							dvanact1.IsEnabled = true;
							sestt.IsVisible = true;
						}
					})
				});

				hlavaa.GestureRecognizers.Add(new TapGestureRecognizer {
					Command = new Command(async () => {

						hlavaP = true;
						spravne++;

						obleceni.IsVisible = false;
						hlava.IsVisible = false;
						kocka.IsVisible = false;

						uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j46);
						lejout.Children.Add(customFrame);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1000);

						charDialogy customFrame1 = new charDialogy(dialogy.s50);
						lejout.Children.Add(customFrame1);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1600);

						charDialogy customFrame2 = new charDialogy(dialogy.s51);
						lejout.Children.Add(customFrame2);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(2000);

						charDialogy customFrame3 = new charDialogy(dialogy.s52);
						lejout.Children.Add(customFrame3);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						isAnimating = false;

						await Task.Delay(1000);

						uzivatelDialogy customFrame4 = new uzivatelDialogy(dialogy.j47);
						lejout.Children.Add(customFrame4);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(100);

						await layout1.FadeTo(0.5, 1000);
						await layout3.FadeTo(1, 1000);
						layout1.IsEnabled = true;
						layout3.IsEnabled = true;


						timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
							if (currentStep1 < steps1) {
								currentStep1++;
								timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
								return true;
							} else {
								timeLabel1.Text = endTime1.ToString("HH:mm");
								return false;
							}
						});

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(1000);
						await layout1.FadeTo(0, 1000);
						await layout3.FadeTo(0, 1000);

						await Task.Delay(1000);

						if (spravne >= 1 && spravne <= 4) {
							await jedenact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							sestt.IsVisible = true;
						} else {
							await jedenact1.FadeTo(1, 500);
							await dvanact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							dvanact1.IsEnabled = true;
							sestt.IsVisible = true;
						}

					})
				});

				kockaa.GestureRecognizers.Add(new TapGestureRecognizer {
					Command = new Command(async () => {

						kockaP= true;
						spravne++;

						obleceni.IsVisible = false;
						hlava.IsVisible = false;
						kocka.IsVisible = false;

						uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j39);
						lejout.Children.Add(customFrame);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);


						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(2300);

						charDialogy customFrame1 = new charDialogy(dialogy.s43);
						lejout.Children.Add(customFrame1);

						isAnimating = false;

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j40);
						lejout.Children.Add(customFrame3);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame4 = new uzivatelDialogy(dialogy.j41);
						lejout.Children.Add(customFrame4);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1800);

						charDialogy customFrame5 = new charDialogy(dialogy.s44);
						lejout.Children.Add(customFrame5);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1500);

						charDialogy customFrame6 = new charDialogy(dialogy.s45);
						lejout.Children.Add(customFrame6);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						charDialogy customFrame7 = new charDialogy(dialogy.s46);
						lejout.Children.Add(customFrame7);

						isAnimating = false;

						await Task.Delay(1100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame8 = new uzivatelDialogy(dialogy.j42);
						lejout.Children.Add(customFrame8);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(100);

						await layout1.FadeTo(0.5, 1000);
						await layout3.FadeTo(1, 1000);
						layout1.IsEnabled = true;
						layout3.IsEnabled = true;


						timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
							if (currentStep1 < steps1) {
								currentStep1++;
								timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
								return true;
							} else {
								timeLabel1.Text = endTime1.ToString("HH:mm");
								return false;
							}
						});

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(1000);
						await layout1.FadeTo(0, 1000);
						await layout3.FadeTo(0, 1000);

						await Task.Delay(1000);

						if (spravne >= 1 && spravne <= 4) {
							await jedenact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							sestt.IsVisible = true;
						} else {
							await jedenact1.FadeTo(1, 500);
							await dvanact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							dvanact1.IsEnabled = true;
							sestt.IsVisible = true;
						}

					})
				});


			})
		});

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		isAnimating = true;

		await Task.Delay(1500);
		isAnimating = false;
		charDialogy customFrame17 = new charDialogy(dialogy.s18);
		lejout.Children.Add(customFrame17);
		isAnimating = false;

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		await devet1.FadeTo(1, 500);
		await deset1.FadeTo(1, 500);

		devet1.IsEnabled = true;
		deset1.IsEnabled = true;
		pett.IsVisible = true;


	}





	private async void sedm1_Clicked(object sender, EventArgs e) {
		ctyrii.IsVisible = false;
		sedm1.IsEnabled = false;
		osm1.IsEnabled = false;
		sedm1.Opacity = 0;
		osm1.Opacity = 0;
		spravne++;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j8);
		lejout.Children.Add(customFrame);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2800);

		isAnimating = false;

		charDialogy customFrame1 = new charDialogy(dialogy.s11);
		lejout.Children.Add(customFrame1);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);
		uzivatelDialogy customFrame10 = new uzivatelDialogy(dialogy.j12);
		lejout.Children.Add(customFrame10);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2800);

		charDialogy customFrame11 = new charDialogy(dialogy.s14);
		lejout.Children.Add(customFrame11);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);
		charDialogy customFrame12 = new charDialogy(dialogy.s15);
		lejout.Children.Add(customFrame12);
		isAnimating = false;

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);

		uzivatelDialogy customFrame13 = new uzivatelDialogy(dialogy.j13);
		lejout.Children.Add(customFrame13);
		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(2800);

		charDialogy customFrame14 = new charDialogy(dialogy.s16);
		lejout.Children.Add(customFrame14);
		isAnimating= false;
		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct.mp3"));
		player1.Play();



		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await hvezda.FadeTo(1, 1000);
		await hvezda.FadeTo(0, 1000);

		await Task.Delay(10);

		await layout1.FadeTo(0.5, 1000);
		await layout2.FadeTo(1, 1000);
		layout1.IsEnabled = true;
		layout2.IsEnabled = true;


		await Task.Delay(1000);

		Vibration.Vibrate();

		timeLabel.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration.TotalMilliseconds / steps), () => {
			if (currentStep < steps) {
				currentStep++;
				timeLabel.Text = startTime.AddSeconds(currentStep).ToString("HH:mm");
				return true; 
			} else {
				timeLabel.Text = endTime.ToString("HH:mm");
				return false; 
			}
		});

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(1000);
		await layout1.FadeTo(0, 1000);
		await layout2.FadeTo(0, 1000);

		await Task.Delay(1000);
		uzivatelDialogy customFrame15 = new uzivatelDialogy(dialogy.j14);
		lejout.Children.Add(customFrame15);

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);
		isAnimating = true;

		await Task.Delay(2000);
		isAnimating = false;
		charDialogy customFrame16 = new charDialogy(dialogy.s17);
		lejout.Children.Add(customFrame16);
		isAnimating = false;

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		Image newImage2 = new Image {
			Source = ImageSource.FromFile("char3.png"), 
			Margin = new Thickness(25, 10, 25, 10),
			Aspect = Aspect.AspectFit,
			
		};

		Frame border2 = new Frame {
			BorderColor = Color.FromArgb("#f76da7"),
			CornerRadius = 45,
			Padding = new Thickness(10),
			Margin = new Thickness(10, 0, 100, 5),
			BackgroundColor = Color.FromArgb("#f76da7"),
		};

		border2.Content = newImage2;
		lejout.Children.Add(border2);

		newImage2.GestureRecognizers.Add(new TapGestureRecognizer {
			Command = new Command(async () => {
				devet1.IsEnabled = false;
				deset1.IsEnabled = false;
				pett.IsVisible = false;
				obleceni.IsVisible = true;
				hlava.IsVisible = true;
				kocka.IsVisible = true;

				player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
				player1.Play();

				oblecenii.GestureRecognizers.Add(new TapGestureRecognizer {
					Command = new Command(async () => {

						oblekP = true;
						spravne++;

						obleceni.IsVisible = false;
						hlava.IsVisible = false;
						kocka.IsVisible = false;

						uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j43);
						lejout.Children.Add(customFrame);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame1 = new uzivatelDialogy(dialogy.j44);
						lejout.Children.Add(customFrame1);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1500);

						charDialogy customFrame5 = new charDialogy(dialogy.s47);
						lejout.Children.Add(customFrame5);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1250);

						charDialogy customFrame6 = new charDialogy(dialogy.s48);
						lejout.Children.Add(customFrame6);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						charDialogy customFrame7 = new charDialogy(dialogy.s49);
						lejout.Children.Add(customFrame7);

						isAnimating = false;

						await Task.Delay(1100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame8 = new uzivatelDialogy(dialogy.j45);
						lejout.Children.Add(customFrame8);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await layout1.FadeTo(0.5, 1000);
						await layout3.FadeTo(1, 1000);
						layout1.IsEnabled = true;
						layout3.IsEnabled = true;


						timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
							if (currentStep1 < steps1) {
								currentStep1++;
								timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
								return true;
							} else {
								timeLabel1.Text = endTime1.ToString("HH:mm");
								return false;
							}
						});

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(1000);
						await layout1.FadeTo(0, 1000);
						await layout3.FadeTo(0, 1000);

						await Task.Delay(1000);

						if (spravne >= 1 && spravne <= 4) {
							await jedenact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							sestt.IsVisible = true;
						} else {
							await jedenact1.FadeTo(1, 500);
							await dvanact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							dvanact1.IsEnabled = true;
							sestt.IsVisible = true;
						}
					})
				});

				hlavaa.GestureRecognizers.Add(new TapGestureRecognizer {
					Command = new Command(async () => {

						hlavaP = true;
						spravne++;

						obleceni.IsVisible = false;
						hlava.IsVisible = false;
						kocka.IsVisible = false;

						uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j46);
						lejout.Children.Add(customFrame);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1000);

						charDialogy customFrame1 = new charDialogy(dialogy.s50);
						lejout.Children.Add(customFrame1);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1600);

						charDialogy customFrame2 = new charDialogy(dialogy.s51);
						lejout.Children.Add(customFrame2);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(2000);

						charDialogy customFrame3 = new charDialogy(dialogy.s52);
						lejout.Children.Add(customFrame3);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						isAnimating = false;

						await Task.Delay(1000);

						uzivatelDialogy customFrame4 = new uzivatelDialogy(dialogy.j47);
						lejout.Children.Add(customFrame4);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(100);

						await layout1.FadeTo(0.5, 1000);
						await layout3.FadeTo(1, 1000);
						layout1.IsEnabled = true;
						layout3.IsEnabled = true;


						timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
							if (currentStep1 < steps1) {
								currentStep1++;
								timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
								return true;
							} else {
								timeLabel1.Text = endTime1.ToString("HH:mm");
								return false;
							}
						});

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(1000);
						await layout1.FadeTo(0, 1000);
						await layout3.FadeTo(0, 1000);

						await Task.Delay(1000);

						if (spravne >= 1 && spravne <= 4) {
							await jedenact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							sestt.IsVisible = true;
						} else {
							await jedenact1.FadeTo(1, 500);
							await dvanact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							dvanact1.IsEnabled = true;
							sestt.IsVisible = true;
						}

					})
				});

				kockaa.GestureRecognizers.Add(new TapGestureRecognizer {
					Command = new Command(async () => {

						kockaP = true;
						spravne++;

						obleceni.IsVisible = false;
						hlava.IsVisible = false;
						kocka.IsVisible = false;

						uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j39);
						lejout.Children.Add(customFrame);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);


						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(2300);

						charDialogy customFrame1 = new charDialogy(dialogy.s43);
						lejout.Children.Add(customFrame1);

						isAnimating = false;

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j40);
						lejout.Children.Add(customFrame3);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame4 = new uzivatelDialogy(dialogy.j41);
						lejout.Children.Add(customFrame4);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						isAnimating = true;

						await Task.Delay(1800);

						charDialogy customFrame5 = new charDialogy(dialogy.s44);
						lejout.Children.Add(customFrame5);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1500);

						charDialogy customFrame6 = new charDialogy(dialogy.s45);
						lejout.Children.Add(customFrame6);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						charDialogy customFrame7 = new charDialogy(dialogy.s46);
						lejout.Children.Add(customFrame7);

						isAnimating = false;

						await Task.Delay(1100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(1000);

						uzivatelDialogy customFrame8 = new uzivatelDialogy(dialogy.j42);
						lejout.Children.Add(customFrame8);

						await Task.Delay(100);

						await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

						await Task.Delay(100);

						await layout1.FadeTo(0.5, 1000);
						await layout3.FadeTo(1, 1000);
						layout1.IsEnabled = true;
						layout3.IsEnabled = true;


						timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
							if (currentStep1 < steps1) {
								currentStep1++;
								timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
								return true;
							} else {
								timeLabel1.Text = endTime1.ToString("HH:mm");
								return false;
							}
						});

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(3000);
						Vibration.Vibrate();

						await Task.Delay(1000);
						await layout1.FadeTo(0, 1000);
						await layout3.FadeTo(0, 1000);

						await Task.Delay(1000);

						if (spravne >= 1 && spravne <= 4) {
							await jedenact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							sestt.IsVisible = true;
						} else {
							await jedenact1.FadeTo(1, 500);
							await dvanact1.FadeTo(1, 500);

							jedenact1.IsEnabled = true;
							dvanact1.IsEnabled = true;
							sestt.IsVisible = true;
						}

					})
				});


			})
		});

		await Task.Delay(100);
		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		isAnimating = true;

		await Task.Delay(1500);
		isAnimating = false;
		charDialogy customFrame17 = new charDialogy(dialogy.s18);
		lejout.Children.Add(customFrame17);
		isAnimating = false;

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(2000);

		await devet1.FadeTo(1, 500);
		await deset1.FadeTo(1, 500);

		devet1.IsEnabled = true;
		deset1.IsEnabled = true;
		pett.IsVisible = true;

	}






	private async void devet1_Clicked(object sender, EventArgs e) {
		pett.IsVisible = false;
		devet1.IsEnabled = false;
		deset1.IsEnabled = false;
		devet1.Opacity = 0;
		deset1.Opacity = 0;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j19);
		lejout.Children.Add(customFrame);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);
		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct.mp3"));
		player1.Play();
		await hvezda.FadeTo(1, 1000);
		await hvezda.FadeTo(0, 1000);
		isAnimating = true;

		await Task.Delay(100);

		isAnimating = false;

		charDialogy customFrame1 = new charDialogy(dialogy.s20);
		lejout.Children.Add(customFrame1);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(1000);

		await layout1.FadeTo(0.5, 1000);
		await layout3.FadeTo(1, 1000);
		layout1.IsEnabled = true;
		layout3.IsEnabled = true;


		timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
			if (currentStep1 < steps1) {
				currentStep1++;
				timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
				return true;
			} else {
				timeLabel1.Text = endTime1.ToString("HH:mm");
				return false;
			}
		});

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(1000);
		await layout1.FadeTo(0, 1000);
		await layout3.FadeTo(0, 1000);


		await Task.Delay(1000);

		if (spravne >= 1 && spravne <= 4) {
			await jedenact1.FadeTo(1, 500);

			jedenact1.IsEnabled = true;
			sestt.IsVisible = true;
		} else {
			await jedenact1.FadeTo(1, 500);
			await dvanact1.FadeTo(1, 500);

			jedenact1.IsEnabled = true;
			dvanact1.IsEnabled = true;
			sestt.IsVisible = true;
		}
	}








	private async void deset1_Clicked(object sender, EventArgs e) {
		pett.IsVisible = false;
		devet1.IsEnabled = false;
		deset1.IsEnabled = false;
		devet1.Opacity = 0;
		deset1.Opacity = 0;
		spravne++;

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j18);
		lejout.Children.Add(customFrame);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1000);
		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct.mp3"));
		player1.Play();
		await hvezda.FadeTo(1, 1000);
		await hvezda.FadeTo(0, 1000);
		isAnimating = true;

		await Task.Delay(100);

		isAnimating = false;

		charDialogy customFrame1 = new charDialogy(dialogy.s19);
		lejout.Children.Add(customFrame1);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(1000);

		await layout1.FadeTo(0.5, 1000);
		await layout3.FadeTo(1, 1000);
		layout1.IsEnabled = true;
		layout3.IsEnabled = true;


		timeLabel1.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(animationDuration1.TotalMilliseconds / steps1), () => {
			if (currentStep1 < steps1) {
				currentStep1++;
				timeLabel1.Text = startTime1.AddSeconds(currentStep1).ToString("HH:mm");
				return true;
			} else {
				timeLabel1.Text = endTime1.ToString("HH:mm");
				return false;
			}
		});

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(3000);
		Vibration.Vibrate();

		await Task.Delay(1000);
		await layout1.FadeTo(0, 1000);
		await layout3.FadeTo(0, 1000);

		await Task.Delay(1000);

		if (spravne >= 1 && spravne <= 4) {
			await jedenact1.FadeTo(1, 500);

			jedenact1.IsEnabled = true;
			sestt.IsVisible = true;
		} else{
			await jedenact1.FadeTo(1, 500);
			await dvanact1.FadeTo(1, 500);

			jedenact1.IsEnabled = true;
			dvanact1.IsEnabled = true;
			sestt.IsVisible = true;
		}

	}






	private async void jedenact1_Clicked(object sender, EventArgs e) {

		if (spravne <= 2) {
			//bad ending

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();

			sestt.IsVisible = false;
			jedenact1.IsEnabled = false;
			jedenact1.Opacity = 0;

			await Task.Delay(1000);

			isAnimating = true;

			await Task.Delay(2800);

			isAnimating = false;

			charDialogy customFrame1 = new charDialogy(dialogy.s35);
			lejout.Children.Add(customFrame1);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			isAnimating = true;

			await Task.Delay(1200);

			isAnimating = false;

			charDialogy customFrame2 = new charDialogy(dialogy.s36);
			lejout.Children.Add(customFrame2);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j34);
			lejout.Children.Add(customFrame3);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame4 = new uzivatelDialogy(dialogy.j35);
			lejout.Children.Add(customFrame4);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame5 = new charDialogy(dialogy.s37);
			lejout.Children.Add(customFrame5);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1500);

			charDialogy customFrame6 = new charDialogy(dialogy.s38);
			lejout.Children.Add(customFrame6);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			charDialogy customFrame7 = new charDialogy(dialogy.s39);
			lejout.Children.Add(customFrame7);

			await Task.Delay(1100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			isAnimating = false;

			charDialogy customFrame8 = new charDialogy(dialogy.s40);
			lejout.Children.Add(customFrame8);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame9 = new uzivatelDialogy(dialogy.j36);
			lejout.Children.Add(customFrame9);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame10 = new charDialogy(dialogy.s41);
			lejout.Children.Add(customFrame10);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1500);

			isAnimating = false;

			charDialogy customFrame11 = new charDialogy(dialogy.s42);
			lejout.Children.Add(customFrame11);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame12 = new uzivatelDialogy(dialogy.j37);
			lejout.Children.Add(customFrame12);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			Label newLabel1 = new Label {
				FontFamily = "comic",
				FontSize = 20,
				BackgroundColor = Color.FromRgba("#f76da7"),
				Margin = new Thickness(10, 0, -10, 0),
				Text = "You cannot reply to this conversation, sorry.",
				TextColor = Color.FromRgba("#ffffff")
			};
			Frame border1 = new Frame {
				BorderColor = Color.FromArgb("#f76da7"),
				CornerRadius = 45,
				Padding = new Thickness(10),
				Margin = new Thickness(10, 0, 10, 5),
				BackgroundColor = Color.FromArgb("#f76da7")
			};

			border1.Content = newLabel1;
			lejout.Children.Add(border1);

			await Task.Delay(100);

			uzivatelDialogy customFrame14 = new uzivatelDialogy(dialogy.j38);
			lejout.Children.Add(customFrame14);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			//bad ending

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2500);

			finale.IsEnabled = true;
			finaleVeci.IsEnabled = true;
			finaleVeci.IsVisible = true;

			finaleText.Text = "1/4 - Bad ending.";

			finaleVeci.FadeTo(1, 1000);
			finale.FadeTo(1, 1000);
		}

		else{
			sestt.IsVisible = false;
			jedenact1.IsEnabled = false;
			jedenact1.Opacity = 0;

			player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
			player1.Play();

			await Task.Delay(1000);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame = new charDialogy(dialogy.s21);
			lejout.Children.Add(customFrame);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2000);

			isAnimating = false;

			charDialogy customFrame1 = new charDialogy(dialogy.s22);
			lejout.Children.Add(customFrame1);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame2 = new uzivatelDialogy(dialogy.j20);
			lejout.Children.Add(customFrame2);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j21);
			lejout.Children.Add(customFrame3);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame4 = new charDialogy(dialogy.s23);
			lejout.Children.Add(customFrame4);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2300);

			isAnimating = false;
			charDialogy customFrame5 = new charDialogy(dialogy.s24);
			lejout.Children.Add(customFrame5);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame6 = new uzivatelDialogy(dialogy.j22);
			lejout.Children.Add(customFrame6);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			isAnimating = true;

			await Task.Delay(1850);

			charDialogy customFrame7 = new charDialogy(dialogy.s25);
			lejout.Children.Add(customFrame7);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(3500);

			isAnimating = false;
			charDialogy customFrame8 = new charDialogy(dialogy.s26);
			lejout.Children.Add(customFrame8);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame9 = new uzivatelDialogy(dialogy.j23);
			lejout.Children.Add(customFrame9);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(500);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame10 = new charDialogy(dialogy.s27);
			lejout.Children.Add(customFrame10);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2300);

			isAnimating = false;
			charDialogy customFrame11 = new charDialogy(dialogy.s28);
			lejout.Children.Add(customFrame11);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame12 = new uzivatelDialogy(dialogy.j24);
			lejout.Children.Add(customFrame12);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(500);

			isAnimating = true;

			await Task.Delay(1800);

			isAnimating = false;

			charDialogy customFrame13 = new charDialogy(dialogy.s29);
			lejout.Children.Add(customFrame13);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame14 = new uzivatelDialogy(dialogy.j25);
			lejout.Children.Add(customFrame14);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame15 = new uzivatelDialogy(dialogy.j26);
			lejout.Children.Add(customFrame15);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2500);

			uzivatelDialogy customFrame16 = new uzivatelDialogy(dialogy.j27);
			lejout.Children.Add(customFrame16);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame17 = new uzivatelDialogy(dialogy.j27);
			lejout.Children.Add(customFrame17);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame18 = new uzivatelDialogy(dialogy.j27);
			lejout.Children.Add(customFrame18);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1500);

			uzivatelDialogy customFrame19 = new uzivatelDialogy(dialogy.j28);
			lejout.Children.Add(customFrame19);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(1000);

			uzivatelDialogy customFrame20 = new uzivatelDialogy(dialogy.j29);
			lejout.Children.Add(customFrame20);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			//end screen neutral
			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2500);

			finale.IsEnabled = true;
			finaleVeci.IsEnabled = true;
			finaleVeci.IsVisible = true;

			finaleText.Text = "2/4 - Neutral ending.";

			finaleVeci.FadeTo(1, 1000);
			finale.FadeTo(1, 1000);
		} 

}


	private async void dvanact1_Clicked(object sender, EventArgs e) {
		//good ending

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();

		sestt.IsVisible = false;
		jedenact1.IsEnabled = false;
		dvanact1.IsEnabled = false;
		jedenact1.Opacity = 0;
		dvanact1.Opacity = 0;

		uzivatelDialogy customFrame = new uzivatelDialogy(dialogy.j30);
		lejout.Children.Add(customFrame);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1600);

		isAnimating = true;

		await Task.Delay(100);

		isAnimating = false;

		charDialogy customFrame1 = new charDialogy(dialogy.s30);
		lejout.Children.Add(customFrame1);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(1000);

		isAnimating = true;

		await Task.Delay(100);

		isAnimating = false;

		charDialogy customFrame2 = new charDialogy(dialogy.s31);
		lejout.Children.Add(customFrame2);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);
		await Task.Delay(800);

		uzivatelDialogy customFrame3 = new uzivatelDialogy(dialogy.j31);
		lejout.Children.Add(customFrame3);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(1800);

		isAnimating = true;

		await Task.Delay(100);

		isAnimating = false;

		charDialogy customFrame4 = new charDialogy(dialogy.s32);
		lejout.Children.Add(customFrame4);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		uzivatelDialogy customFrame5 = new uzivatelDialogy(dialogy.j32);
		lejout.Children.Add(customFrame5);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(500);


		uzivatelDialogy customFrame6 = new uzivatelDialogy(dialogy.j33); 
		lejout.Children.Add(customFrame6);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		await Task.Delay(500);

		isAnimating = true;

		await Task.Delay(100);

		isAnimating = false;

		charDialogy customFrame7 = new charDialogy(dialogy.s33 + mojeJmeno.jmeno + dialogy.s34);
		lejout.Children.Add(customFrame7);

		await Task.Delay(100);

		await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

		if (kockaP) {

			await Task.Delay(3000);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame10 = new charDialogy(dialogy.s53);
			lejout.Children.Add(customFrame10);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2300);

			isAnimating = false;

			charDialogy customFrame11 = new charDialogy(dialogy.s54);
			lejout.Children.Add(customFrame11);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			Frame borderK = new Frame{
				Margin = new Thickness(15, 0, 10, 5),
				CornerRadius = 10,
				Padding = new Thickness(10),
				BackgroundColor = Color.FromHex("#f76da7")
			};
			Entry entryK = new Entry {
				Keyboard = Keyboard.Chat,
				Placeholder = "???",
				FontFamily = "comic",
				FontSize = 20,
				BackgroundColor = Color.FromHex("#f76da7"),
				PlaceholderColor = Color.FromHex("#ffff"),
				TextColor = Color.FromHex("#ffff")
			};
			borderK.Content = entryK;
			lejout.Children.Add(borderK);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(15000);

			entryK.IsEnabled = false;

			if( entryK.Text == "Patches" ) {
				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(1000);

				uzivatelDialogy customFrame9 = new uzivatelDialogy(entryK.Text + " ?");
				lejout.Children.Add(customFrame9);

				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(2500);

				finale.IsEnabled = true;
				finaleVeci.IsEnabled = true;
				finaleVeci.IsVisible = true;

				finaleText.Text = "4/4 - Best ending.";

				finaleVeci.FadeTo(1, 1000);
				finale.FadeTo(1, 1000);
			} else {
				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(1000);

				uzivatelDialogy customFrame9 = new uzivatelDialogy(entryK.Text+ " ?");
				lejout.Children.Add(customFrame9);

				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(2500);

				finale.IsEnabled = true;
				finaleVeci.IsEnabled = true;
				finaleVeci.IsVisible= true;

				finaleText.Text = "3/4 - Good ending.";

				finaleVeci.FadeTo(1, 1000);
				finale.FadeTo(1,1000);


			}

		} else if(oblekP){

			await Task.Delay(3000);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame10 = new charDialogy(dialogy.s53);
			lejout.Children.Add(customFrame10);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2300);

			isAnimating = false;

			charDialogy customFrame11 = new charDialogy(dialogy.s55);
			lejout.Children.Add(customFrame11);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			Frame borderK = new Frame {
				Margin = new Thickness(15, 0, 10, 5),
				CornerRadius = 10,
				Padding = new Thickness(10),
				BackgroundColor = Color.FromHex("#f76da7")
			};
			Entry entryK = new Entry {
				Keyboard = Keyboard.Chat,
				Placeholder = "???",
				FontFamily = "comic",
				FontSize = 20,
				BackgroundColor = Color.FromHex("#f76da7"),
				PlaceholderColor = Color.FromHex("#ffff"),
				TextColor = Color.FromHex("#ffff")
			};
			borderK.Content = entryK;
			lejout.Children.Add(borderK);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(15000);

			entryK.IsEnabled = false;

			if (entryK.Text == "Evelyn") {
				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(1000);

				uzivatelDialogy customFrame9 = new uzivatelDialogy(entryK.Text + " ?");
				lejout.Children.Add(customFrame9);

				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(2500);

				finale.IsEnabled = true;
				finaleVeci.IsEnabled = true;
				finaleVeci.IsVisible = true;

				finaleText.Text = "4/4 - Best ending.";

				finaleVeci.FadeTo(1, 1000);
				finale.FadeTo(1, 1000);
			} else {
				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(1000);

				uzivatelDialogy customFrame9 = new uzivatelDialogy(entryK.Text + " ?");
				lejout.Children.Add(customFrame9);

				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(2500);

				finale.IsEnabled = true;
				finaleVeci.IsEnabled = true;
				finaleVeci.IsVisible = true;

				finaleText.Text = "3/4 - Good ending.";

				finaleVeci.FadeTo(1, 1000);
				finale.FadeTo(1, 1000);

			}

		} else if (hlavaP) {

			await Task.Delay(3000);

			isAnimating = true;

			await Task.Delay(1800);

			charDialogy customFrame10 = new charDialogy(dialogy.s53);
			lejout.Children.Add(customFrame10);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2300);

			isAnimating = false;

			charDialogy customFrame11 = new charDialogy(dialogy.s56);
			lejout.Children.Add(customFrame11);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			Frame borderK = new Frame {
				Margin = new Thickness(15, 0, 10, 5),
				CornerRadius = 10,
				Padding = new Thickness(10),
				BackgroundColor = Color.FromHex("#f76da7")
			};
			Entry entryK = new Entry {
				Keyboard = Keyboard.Chat,
				Placeholder = "???",
				FontFamily = "comic",
				FontSize = 20,
				BackgroundColor = Color.FromHex("#f76da7"),
				PlaceholderColor = Color.FromHex("#ffff"),
				TextColor = Color.FromHex("#ffff")
			};
			borderK.Content = entryK;
			lejout.Children.Add(borderK);

			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(15000);

			entryK.IsEnabled = false;

			if (entryK.Text =="Svolo") {
				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(1000);

				uzivatelDialogy customFrame9 = new uzivatelDialogy(entryK.Text + " ?");
				lejout.Children.Add(customFrame9);

				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(2500);

				finale.IsEnabled = true;
				finaleVeci.IsEnabled = true;
				finaleVeci.IsVisible = true;

				finaleText.Text = "4/4 - Best ending.";

				finaleVeci.FadeTo(1, 1000);
				finale.FadeTo(1, 1000);
			} else {
				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(1000);

				uzivatelDialogy customFrame9 = new uzivatelDialogy(entryK.Text + " ?");
				lejout.Children.Add(customFrame9);

				await Task.Delay(100);

				await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

				await Task.Delay(2500);

				finale.IsEnabled = true;
				finaleVeci.IsEnabled = true;
				finaleVeci.IsVisible = true;

				finaleText.Text = "3/4 - Good ending.";

				finaleVeci.FadeTo(1, 1000);
				finale.FadeTo(1, 1000);

			}

		} else {
			await Task.Delay(100);

			await scrollView.ScrollToAsync(lejout, ScrollToPosition.End, true);

			await Task.Delay(2500);

			finale.IsEnabled = true;
			finaleVeci.IsEnabled = true;
			finaleVeci.IsVisible = true;

			finaleText.Text = "3/4 - Good ending.";

			finaleVeci.FadeTo(1, 1000);
			finale.FadeTo(1, 1000);
		}

		//end screen good 
	}

	private async void Button_Clicked(object sender, EventArgs e) {

		System.Environment.Exit(0);

		player1 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("klik.mp3"));
		player1.Play();
	}
}

