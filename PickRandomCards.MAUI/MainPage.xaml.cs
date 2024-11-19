using PickRandomCards;
namespace PickRandomCards.MAUI
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

      
        private void PickCardsButton_Clicked(object sender, EventArgs e)
        {
            PickedCards.Text = String.Empty;
            string? line = NumberOfCards.Text;
            if (int.TryParse(line, out int numberOfCards))
            {
                string[] ret = CardPicker.PickSomeCards(numberOfCards);
                /*if(!string.IsNullOrEmpty(PickedCards.Text))
                {
                    PickedCards.Text += Environment.NewLine;
                }*/
                foreach (string card in ret)
                {
                    PickedCards.Text += card + Environment.NewLine;
                }
                PickedCards.Text += Environment.NewLine + $"You picked {NumberOfCards.Text} cards.";
            }
            else
            {
                PickedCards.Text ="Please enter a valid number";
            }
            
            
        }
    }

}
