
namespace CSharp.Model {
    public class Health {
        public int MonsterHp { get; private set; } = 1000;

        public int PlayerHp { get; private set; } = 1000;

        public void ApplyCardEffect(Monster m, Card c) {
            if (m.NeutralizedCards.Exists(mc => mc == c))
                m.CanAttack = false;

            if (m.CounterBackCards.Exists(mc => mc == c)) {
                if (m.CanAttack) PlayerHp += c.Affect;
                return;
            }

            MonsterHp += c.Affect;
        }
    }
}