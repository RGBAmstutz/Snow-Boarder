using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] float torqueSpeed = 2f;
    [SerializeField] float forwardSpeed = 2f;
    [SerializeField] float baseSpeed = 1f;
    Rigidbody2D rigidBody2D;
    Transform boarderTop;
    SurfaceEffector2D surfaceEffector2D;
    bool controlsDisabled = false;
    // Start is called before the first frame update
    void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boarderTop = GetComponentInChildren<Transform>().GetChild(1);
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!controlsDisabled) {
            RotatePlayer();
            BendPlayer();
        }
    }

    public void DisableControls() { controlsDisabled = true; }

    // when the player hits the w or up key, they bend and increase speed
    void BendPlayer() {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            Vector2 forward = new Vector2(forwardSpeed, -0.5f * forwardSpeed);
            // change sprite to look like the player is bending
            boarderTop.localPosition = new Vector3(-0.171450615f, 0.09f, 0f);
            surfaceEffector2D.speed = forwardSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) {
            // reset position of sprite
            boarderTop.localPosition = new Vector3(-0.171450615f, 0.156774521f, 0f);
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    // rotates the player with A (left arrow) and D (right arrow)
    void RotatePlayer() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            rigidBody2D.AddTorque(torqueSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            rigidBody2D.AddTorque(-torqueSpeed);
        }
    }
}
