using System;
using System.Collections.Generic;

namespace CSharp.Model {
    [Serializable]
    public class RootObject
    {
        public List<Chapter> chapter;
    }

    [Serializable]
    public class Chapter
    {
        public string name;
        public List<Story> story;
        public List<Story> attackStory;
    }
}
