using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject arrowLinePrefab;
    public Transform playerTransform;
    public Rigidbody playerRigidbody;
    const float length = 0.2f;

    Transform[] objectsArray = new Transform[10];

    public Transform lookat;
    Vector3 forceDirection = Vector3.zero;

    Vector3 standardScale;


    private void Start()
    {
        // Create an array of GameObjects
        standardScale = transform.localScale;
        // Instantiate 10 objects using the prefab
        for (int i = 0; i < 10; i++)
        {
            objectsArray[i] = Instantiate(arrowLinePrefab, new Vector3(-9f, 0.7f, i - 9), Quaternion.identity,lookat).transform;
            // Adjust the position as needed (here, they are placed 2 units apart along the x-axis)
        }
    }
    void Update()
    {

        // Adjust the position to be in front of the player

        // Get the applied force direction
        forceDirection = playerRigidbody.velocity.normalized;
        // Set the rotation of the arrow to be aligned with the applied force direction
        forceDirection.y = 0;
        transform.forward = forceDirection;

        transform.position = playerTransform.position + forceDirection * Mathf.Clamp(playerRigidbody.velocity.magnitude, 1, 10);

        if (playerRigidbody.velocity.magnitude < 1f)
        {
            transform.localScale = standardScale * playerRigidbody.velocity.magnitude;
        }
        else
        {
            transform.localScale = standardScale;
        }

        AdjustArrowLine();
    
    }

    private void AdjustArrowLine()
    {
        float distance = (playerTransform.position - transform.position).magnitude;
        float maxDist =  10f;
        float position = 10 * distance / maxDist;
        int index = Mathf.FloorToInt(position);
        float leftOver = position - index;

        for(int i = 0; i < 10; i++)
        {
            if(i < index)
            {
                objectsArray[i].localScale = Vector3.one * length;
            }
            else if(i == index)
            {
                objectsArray[i].localScale = new Vector3(1, 1, leftOver) * length;
            }
            else
            {
                objectsArray[i].localScale = Vector3.zero;
            }
        }
    }
}

