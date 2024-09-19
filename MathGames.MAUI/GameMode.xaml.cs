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
        firstNumber = gameMode != "Division" ?  random.Next(1,9): random.Next(1, 99);
        secondNumber = gameMode != "Division" ? random.Next(1, 9) : random.Next(1, 99);
    }
    private void OnAnswerSubmitted(object sender, EventArgs e)
    {

    }
}