using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrail;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground")
        {
            snowTrail.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ground")
        {
            snowTrail.Stop();
        }
    }
}
