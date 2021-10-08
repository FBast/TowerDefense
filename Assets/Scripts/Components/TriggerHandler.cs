using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components {
    [Serializable]
    public class ColliderEvent : UnityEvent<Collider> {}

    public class TriggerHandler : MonoBehaviour {

        public ColliderEvent OnEnter;
        public ColliderEvent OnStay;
        public ColliderEvent OnExit;
    
        private void OnTriggerEnter(Collider other) {
            OnEnter.Invoke(other);
        }

        private void OnTriggerStay(Collider other) {
            OnStay.Invoke(other);
        }

        private void OnTriggerExit(Collider other) {
            OnExit.Invoke(other);
        }
    
    }
}