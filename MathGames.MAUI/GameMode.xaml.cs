namespace MathGames.MAUI;

public partial class GameMode : ContentPage
{
	public string gameMode { get; set; }
    int firstNumber = 0;
    int secondNumber = 0;
    public GameMode(string mode)
	{
		InitializeComponent();
		gameMode = mode;
        BindingContext = this;
    }

    private void CreateNewQuestion()
    {
        var gameOperand = gameMode switch
        {
            "Addition" => "+",
            "Subtraction" => "-",
            "Multiplication" => "*",
            "Division" => "/",
            _ => ""
        };

        var random = new Random();
    }
    private void OnAnswerSubmitted(object sender, EventArgs e)
    {

    }
}