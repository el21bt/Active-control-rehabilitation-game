using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationController : MonoBehaviour
{
    // These variables will hold the calibration values for each direction
    public float restPlantarflexion;
    public float restDorsiflexion;
    public float restAbduction;
    public float restAdduction;

    public float maxPlantarflexion;
    public float maxDorsiflexion;
    public float maxAbduction;
    public float maxAdduction;

    // Flags to track if calibration is complete for each direction
    public bool isCalibratingPlantarflexion;
    public bool isCalibratingDorsiflexion;
    public bool isCalibratingAbduction;
    public bool isCalibratingAdduction;

    /*void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }*/
    void Update()
    {
        // Check if all directions are calibrated
        if (isCalibratingPlantarflexion && isCalibratingDorsiflexion &&
            isCalibratingAbduction && isCalibratingAdduction)
        {
            // Normalization code can go here if needed
            // Example: NormalizeRotationValues();
        }
    }

    public void UpdateRotationValues(float plantarflexion, float dorsiflexion, float abduction, float adduction)
    {
        if (isCalibratingPlantarflexion)
        {
            maxPlantarflexion = plantarflexion;
        }
        else if (isCalibratingDorsiflexion)
        {
            maxDorsiflexion = dorsiflexion;
        }
        else if (isCalibratingAbduction)
        {
            maxAbduction = abduction;
        }
        else if (isCalibratingAdduction)
        {
            maxAdduction = adduction;
        }
    }

    public void StartCalibrationPlantarflexion()
    {
        isCalibratingPlantarflexion = true;
        // Additional instructions for user can go here if needed
    }

    public void StartCalibrationDorsiflexion()
    {
        isCalibratingDorsiflexion = true;
        // Additional instructions for user can go here if needed
    }

    public void StartCalibrationAbduction()
    {
        isCalibratingAbduction = true;
        // Additional instructions for user can go here if needed
    }

    public void StartCalibrationAdduction()
    {
        isCalibratingAdduction = true;
        // Additional instructions for user can go here if needed
    }


}
