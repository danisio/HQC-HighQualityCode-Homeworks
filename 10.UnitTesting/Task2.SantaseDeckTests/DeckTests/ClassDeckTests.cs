namespace DeckTests
{
    using NUnit.Framework;
    using Santase.Logic.Cards;

    [TestFixture]
    public class ClassDeckTests
    {
        [Test]
        public void CardsLeft_ShouldReturnCorrectCount()
        {
            var deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [TestCase(25)]
        [TestCase(100)]
        [ExpectedException]
        public void DrawNextCard_ShouldThrow_WhenDeckIsEmpty(int counter)
        {
            var deck = new Deck();

            for (int card = 0; card <= counter; card++)
            {
                deck.GetNextCard();
            }
        }

        [Test]
        public void ChangeTrumpCard_ShouldWorkProperly()
        {
            var deck = new Deck();
            var firstCard = deck.GetTrumpCard;
            var secondCard = deck.GetNextCard();

            deck.ChangeTrumpCard(secondCard);

            Assert.AreNotSame(firstCard, deck.GetTrumpCard);
        }
    }
}
