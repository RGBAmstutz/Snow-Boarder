using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour {
    [SerializeField] float sceneTransitionEase = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Debug.Log("Oof you hit your head!");
            Invoke("ReloadScene", sceneTransitionEase);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
