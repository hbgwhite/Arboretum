using System;
using System.Collections.Generic;
using System.Linq;

namespace Arboretum_Web.Models
{
    public class Deck
    {
        public Deck(int numberOfPlayers)
        {
            Cards = Enum.GetValues(typeof(Suit))
                .OfType<Suit>()
                .ToList()
                .Take(6 + (numberOfPlayers - 2) * 2)
                .SelectMany(suit =>
                    Enumerable.Range(1, 8)
                        .Select(number => new Card {Number = number, TreeType = suit}))
                .ToList();
            Shuffle();
        }

        public List<Card> Cards { get; set; }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public bool HasCards()
        {
            return Cards.Any();
        }

        public Card Draw()
        {
            var card = Cards.First();
            Cards.Remove(card);
            return card;
        }
    }
}