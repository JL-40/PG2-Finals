using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform trans;

    [SerializeField] Transform followObj;

    [SerializeField] Vector3 positionDiff;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        positionDiff = trans.position - followObj.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (trans.position - followObj.position != positionDiff && followObj.position.y == 0.9f)
        {
            trans.position = followObj.position + positionDiff;
        }
    }
}
