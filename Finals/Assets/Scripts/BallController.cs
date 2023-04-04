using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] bool isMovingOnXAxis = true;
    [SerializeField] bool startMoving;
    bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        startMoving = false;
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !startMoving && !isFalling)
        {
            startMoving = true;
        }
        else if (Input.GetMouseButtonDown(0) && startMoving && !isFalling)
        {
            ChangeMoveAxis();
        }

        MoveBall();
    }

    void ChangeMoveAxis()
    {
        if (isMovingOnXAxis) 
        {
            isMovingOnXAxis = false;

        }
        else
        {
            isMovingOnXAxis = true;
        }
    }

    void MoveBall()
    {
        if (startMoving && !isFalling)
        {
            switch (isMovingOnXAxis)
            {
                case true:
                    {
                        transform.Translate(Time.deltaTime * speed * new Vector3(1, 0, 0));

                        break;
                    }
                case false:
                    {
                        transform.Translate(Time.deltaTime * speed * new Vector3(0, 0, 1));
                        break;
                    }
            }

        }
        else if (startMoving && isFalling)
        {
            //transform.Translate(Time.deltaTime * 9.5f * new Vector3(0, -1, 0));

            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            isFalling = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            isFalling = true;
        }
    }

    public bool CheckIsFalling()
    {
        return isFalling;
    }
}
