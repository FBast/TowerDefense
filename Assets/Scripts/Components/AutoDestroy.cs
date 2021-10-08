using UnityEngine;

namespace Components {
    public class AutoDestroy : MonoBehaviour {

        public float LifeTime;
    
        private void Awake() {
            Invoke(nameof(DestroyMe), LifeTime);
        }

        private void DestroyMe() {
            Destroy(gameObject);
        }
    
    }
}
