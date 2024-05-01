using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Ground;
    public float rollSpeed = 10;
    //public float frequency = 1.0f;

    //public TextMeshProUGUI countText;
    //public GameObject winTextObject;
    // private int count;
    //private Rigidbody rb;
    //private Quaternion initialRotation; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //initialRotation = transform.rotation;
       // count = 0;
       // SetCountText();
        //winTextObject.SetActive(false);
    }

    void FixedUpdate()
    {   
        if(Ground != null)
        {
            Quaternion groundRotation = Ground.transform.rotation;
            Vector3 eulerRotation = groundRotation.eulerAngles;
            //print(eulerRotation);
            //Vector3 groundScale = Ground.transform.localScale;
            if(eulerRotation.x > 180)
            {
                eulerRotation.x = -(360 - eulerRotation.x);
            }
            if(eulerRotation.z > 180)
            {
                eulerRotation.z = -(360 - eulerRotation.z);
            }


            // Calculate the opposite side
            eulerRotation.x = Mathf.Sin(eulerRotation.x * Mathf.Deg2Rad);
            eulerRotation.z =  Mathf.Sin(eulerRotation.z * Mathf.Deg2Rad);

            Vector3 vector3 = new Vector3(-eulerRotation.z, 0f, eulerRotation.x);
            Vector3 forceDirection = vector3;
            Vector3 force = forceDirection * rollSpeed;
            //print(forceDirection); 
            rb.AddForce(force);
        }
        else
        {
            Debug.LogError("Object not assigned");
        }


    }

}
