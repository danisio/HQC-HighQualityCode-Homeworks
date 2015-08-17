namespace PokerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class ClassHandTests
    {
        [TestMethod]
        public void TestToString_ShouldWorkProperly()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Hearts), 
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var hand = new Hand(cards);
            var expected = "Ace of Hearts - Ten of Hearts";

            Assert.AreEqual(expected, hand.ToString());
        }

        [TestMethod]
        public void CreateHand_ShouldAddCardsProperly_WhenCardsAreValid()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Hearts), 
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var hand = new Hand(cards);

            Assert.AreEqual(hand.Cards.First(), cards.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateHand_ShouldThrow_WhenListOfCardsIsNull()
        {
            var hand = new Hand(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateHand_ShouldThrow_WhenSomeOfTheCardsAreNull()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Hearts), 
                null
            };

            var hand = new Hand(cards);
        }
    }
}
