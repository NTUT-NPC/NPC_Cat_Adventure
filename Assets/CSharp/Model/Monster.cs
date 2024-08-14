using System.Collections.Generic;

namespace CSharp.Model {
    public class Monster {
        public List<Card> NeutralizedCards;
        public List<Card> CounterBackCards;
        public bool CanAttack = true;

        public Monster(List<Card> neutralizedCards, List<Card> counterBackCards) {
            NeutralizedCards = neutralizedCards;
            CounterBackCards = counterBackCards;
        }
    }
}