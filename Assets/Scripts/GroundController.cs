using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public Slidey slidey1;
    public Slidey slidey2;
    public float tiltSpeed = 10f;
    public float maxTiltAngle = 20f;
    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate tilt angles based on input
        float x_tilt = -horizontalInput * tiltSpeed * Time.deltaTime;
        float z_tilt = verticalInput * tiltSpeed * Time.deltaTime;

        // Get current rotation angles
        Vector3 currentAngles = transform.rotation.eulerAngles;

        //make angles in form -180 to 180 rather then 0 to 360
        if (currentAngles.x > 180)
        {
            currentAngles.x -= 360f;
        }
        if (currentAngles.z > 180)
        {
            currentAngles.z -= 360f;
        }
        // Calculate new rotation angles
        float newXAngle = Mathf.Clamp(currentAngles.x + z_tilt, -maxTiltAngle, maxTiltAngle);
        float newZAngle = Mathf.Clamp(currentAngles.z + x_tilt, -maxTiltAngle, maxTiltAngle);

        
        // Apply the new rotation angles
        transform.rotation = Quaternion.Euler(newXAngle, currentAngles.y, newZAngle);

        slidey1.pos = -newZAngle / maxTiltAngle;
        slidey1.moveOnXAxis = true;
        slidey2.pos = newXAngle / maxTiltAngle;
        slidey2.moveOnXAxis = false;

    }
    }
