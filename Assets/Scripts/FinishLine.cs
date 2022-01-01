using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {
    [SerializeField] float sceneTransitionEase = 1f;
    [SerializeField] ParticleSystem finishEffect;
    bool hasFinished = false;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !hasFinished) {
            hasFinished = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Debug.Log(SceneManager.GetActiveScene().name + " Complete!");
            Invoke("nextLevel", sceneTransitionEase);
        }
    }

    void nextLevel() {
        int nextSceneNum = SceneManager.GetActiveScene().buildIndex + 1;
        // if you're on the last scene, go to the beginning again
        if (nextSceneNum > SceneManager.sceneCountInBuildSettings - 1) {
            SceneManager.LoadScene(0);
        }
        else {
            SceneManager.LoadScene(nextSceneNum);
        }
    }
}
