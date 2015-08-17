namespace PokerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class ClassCardTests
    {
        [TestMethod]
        public void TestToString_ShouldWorkProperly()
        {
            var card = new Card(CardFace.Ten, CardSuit.Clubs);
            var expectedCard = "Ten of Clubs";
            var actual = card.ToString();

            Assert.AreEqual(expectedCard, actual);
        }

        [TestMethod]
        public void TestToString_ShouldWorkProperly_WhenCardsAreSame()
        {
            var card = new Card(CardFace.Ten, CardSuit.Clubs);
            var card2 = new Card(CardFace.Ten, CardSuit.Clubs);

            Assert.AreEqual(card2.ToString(), card.ToString());
        }

        [TestMethod]
        public void TestCards_ShouldWorkProperly_WhenCardsAreDifferent()
        {
            var card = new Card(CardFace.Ten, CardSuit.Clubs);
            var card2 = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.AreNotEqual(card2, card);
        }
    }
}
