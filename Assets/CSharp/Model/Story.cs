using System;
using System.Collections.Generic;

namespace CSharp.Model {
    [Serializable]
    public class Story
    {
        public int no;
        public string background;
        public List<Dialogue> dialogue;
        public int? questionId;
        public string optionName;
        public int? achievement;
    }
}
