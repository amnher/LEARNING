
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
            
            if (int.TryParse(NumberOfCards.Text, out int numberOfCards))
            {
                PickedCards.Text = String.Empty;
                string[] cards = CardPicker.PickSomeCards(numberOfCards);
                foreach (string card in cards)
                {
                    PickedCards.Text += card + Environment.NewLine;
                }
            }
            else
            {
                PickedCards.Text = "Please enter a valid number";
            }
            PickedCards.Text += Environment.NewLine + "You picked " + numberOfCards + " cards.";
            

        }
    }

}
