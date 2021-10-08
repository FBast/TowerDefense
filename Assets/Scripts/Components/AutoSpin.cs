using UnityEngine;

namespace Components {
    public class AutoSpin : MonoBehaviour {

        public Vector3 RotationSpeed;

        private void Update() {
            transform.Rotate(RotationSpeed * Time.deltaTime);
        }
    
    }
}
