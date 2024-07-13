using UnityEngine;

namespace CSharp {
    // https://www.everyday3d.com/c-events-and-unity3d/

    public class ItemStateBroadcaster : MonoBehaviour {
        public delegate void ItemStateChangedHandler(string[] arr);
        public event ItemStateChangedHandler OnItemStateChanged;

        public void ChangeItemState(string[] arr) {
            OnItemStateChanged?.Invoke(arr);
        }
    }
}