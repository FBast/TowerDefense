using UnityEngine;

namespace Entities {
    public class Spawner : MonoBehaviour {

        [Header("References")]
        public GameObject MobPrefab;

        [Header("Parameters")] 
        [Range(0, 100)] public float SpawnSpeed;

        private float _currentTime;
    
        private void Update() {
            if (_currentTime >= SpawnSpeed) {
                _currentTime = 0;
                Instantiate(MobPrefab, transform.position, Quaternion.identity);
            }
            else {
                _currentTime += Time.deltaTime;
            }
        }
    
    }
}