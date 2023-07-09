using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float movementSpeed;
    public float startPosition;
    public float endPosition;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x <= endPosition)
        {
            if (gameObject.tag == "block")
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
            }

        }
    }
}
