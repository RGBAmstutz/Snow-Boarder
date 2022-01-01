using UnityEngine;

public class DontDestroyBGM : MonoBehaviour {
    private void Awake() {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
        // prevent overlapping bgm
        if (musicObjects.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
