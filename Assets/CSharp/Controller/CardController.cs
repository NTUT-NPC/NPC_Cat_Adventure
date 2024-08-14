using System.Collections.Generic;
using CSharp.Model;

namespace CSharp.Controller {
    public class CardController {
        private List<Card> cards;
        private static CardController _instance;

        public static CardController Instance {
            get { return _instance ??= new CardController(); }
        }

        public void AddCard(Card card) {
            cards.Add(card);
        }

        public void RemoveCard(Card card) {
            if (cards.Exists(c => c == card))
                cards.Remove(card);
        }

        public List<Card> GetCard() {
            return cards;
        }
    }
}