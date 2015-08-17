namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = new List<ICard>(cards);
        }

        public IList<ICard> Cards
        {
            get
            {
                return new List<ICard>(this.cards);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of cards cannot be null");
                }

                foreach (var card in value)
                {
                    if (card == null)
                    {
                        throw new ArgumentNullException("Some of the cards are null");
                    }
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            return string.Join(" - ", this.Cards);
        }
    }
}
