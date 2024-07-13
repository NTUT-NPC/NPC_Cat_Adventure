using CSharp.Model;
using UnityEngine;

namespace CSharp.Util {
    public class JsonDeserializer {
        public static RootObject LoadJsonFromFile(string path) {
            TextAsset jsonTextFile = Resources.Load<TextAsset>(path);
            if (jsonTextFile != null) {
                return JsonUtility.FromJson<RootObject>(jsonTextFile.text);
            }

            Debug.LogError("Cannot find JSON file at specified path.");
            return null;
        }
    }
}
