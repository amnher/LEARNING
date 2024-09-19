namespace MathGames.MAUI
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnMode(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Navigation.PushAsync(new GameMode(btn.Text));
            
        }

        private void OnPreviousMode(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Navigation.PushAsync(new OnPreviousChosenGame());

        }
    }

}
