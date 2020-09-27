using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ExplodeStar : MonoBehaviour
{
    public ParticleSystem explodePartical;
    public CameraShake cameraShake;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Log")
        {
            StartCoroutine(cameraShake.Shake(0.60f, 0.4f));
        }
    }
}