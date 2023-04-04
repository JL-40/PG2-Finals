using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] float fallTimer = 0.5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(DropPlatform());

            Destroy(gameObject, 2f + fallTimer);
        }
    }

    IEnumerator DropPlatform()
    {
        rb.useGravity = true;

        yield return new WaitForSeconds(fallTimer);
    }
}
