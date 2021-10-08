using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class GameOverUI : MonoBehaviour {

        public void RetryGame() {
            SceneManager.UnloadSceneAsync("GameOver");
            SceneManager.LoadScene("Game");
        }

        public void QuitGame() {
            Application.Quit();
        }
    
    }
}
