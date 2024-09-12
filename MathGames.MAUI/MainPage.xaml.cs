namespace MathGames.MAUI
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnGameMode(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Navigation.PushAsync(new GamePage(btn.Text));
            DisplayAlert($"{btn.Text} Mode", "Welcome to this mode", "Continue");
        }

        private void OnPreviousGame(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OnPreviousChosenGame());
        }
    }

}
