using System.Collections.Generic;
using CSharp.Model;

namespace CSharp.Enu {
    public class MonsterType {
        public static readonly Monster Voldemort = new(
            new List<Card> { CardType.RotatingFish },
            new List<Card> { CardType.StormEye }
        );

        public static readonly Monster Jay = new(
            new List<Card> { },
            new List<Card> { }
        );

        public static readonly Monster EvilDuo = new(
            new List<Card> { },
            new List<Card> { }
        );
    }
}