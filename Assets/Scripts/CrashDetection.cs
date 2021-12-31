using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] float sceneTransitionEase = 1f;
    [SerializeField] ParticleSystem crashEffect;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            crashEffect.Play();
            Debug.Log("Oof you hit your head!");
            Invoke("ReloadScene", sceneTransitionEase);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
