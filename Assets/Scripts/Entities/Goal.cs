using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities {
    public class Goal : MonoBehaviour {

        public static List<Goal> Goals = new List<Goal>();
        public static int LifeNumber = 10;
    
        private void Awake() {
            Goals.Add(this);
        }

        public void AddCollision(Collider other) {
            Mob mob = other.gameObject.GetComponent<Mob>();
            if (mob == null) return;
            Destroy(other.gameObject);
            LifeNumber--;
            if (LifeNumber <= 0) SceneManager.LoadScene("GameOver");
        }

        private void OnDestroy() {
            Goals.Remove(this);
        }
    }
}