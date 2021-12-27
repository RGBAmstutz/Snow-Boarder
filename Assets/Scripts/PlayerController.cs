using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueSpeed = 2f;
    [SerializeField] float forwardSpeed = 2f;
    Rigidbody2D rigidBody2D;
    Transform boarderTop;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boarderTop = GetComponentInChildren<Transform>().GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidBody2D.AddTorque(torqueSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidBody2D.AddTorque(-torqueSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector2 forward = new Vector2(forwardSpeed, -0.5f*forwardSpeed); 
            // change sprite to look like the player is bending
            boarderTop.localPosition = new Vector3(-0.171450615f,0.09f,0f);
            rigidBody2D.AddForce(forward);
            
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            // reset position of sprite
            boarderTop.localPosition = new Vector3(-0.171450615f,0.156774521f,0f);
        }
    }
}
