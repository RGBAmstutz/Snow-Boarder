using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float sceneTransitionEase = 1f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            Debug.Log(SceneManager.GetActiveScene().name + " Complete!");
            Invoke("ReloadScene", sceneTransitionEase);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
