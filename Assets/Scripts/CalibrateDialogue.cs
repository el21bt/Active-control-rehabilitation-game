using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CalibrateDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Button NextButton;
    public Button BackButton;

    private int index;
    private CalibrationController calibrationController; // Reference to your calibration controller script

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;

        // Find the CalibrationController GameObject in the scene and get its CalibrationController script
        GameObject calibrationControllerObject = GameObject.Find("CalibrationController");
        if (calibrationControllerObject != null)
        {
            calibrationController = calibrationControllerObject.GetComponent<CalibrationController>();
        }
        else
        {
            Debug.LogError("CalibrationController GameObject not found!");
        }

        ShowLine();

        NextButton.onClick.AddListener(NextLine);
        BackButton.onClick.AddListener(PreviousLine);
        //yourButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    /* void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    } */

    void ShowLine()
    {
        textComponent.text = lines[index];
        if (index >= 2) // Start calibration after the 2nd index
        {
            StartCalibration();
        }
    }

    void NextLine()
    {
        Invoke(nameof(DeselectButton), 0.5f);
        if (index < lines.Length - 1)
        {
            index++;
            ShowLine();
        }
        else
        {
            SceneManager.LoadScene("StartMenu");
            gameObject.SetActive(false);
        }
    }

    void PreviousLine()
    {
        Invoke(nameof(DeselectButton), 0.5f);
        EventSystem.current.SetSelectedGameObject(null);
        if (index == 0)
        {
            SceneManager.LoadScene("StartMenu");
        }
        else
        {
            switch (index)
            {
                case 2:

                    calibrationController.isCalibratingPlantarflexion = false;
                    break;
                case 3:
                    calibrationController.isCalibratingDorsiflexion = false;
                    break;
                case 4:
                    calibrationController.isCalibratingAbduction = false;
                    break;
                case 5:
                    calibrationController.isCalibratingAdduction = false;
                    break;
            }
            index--;
            ShowLine();
        }
    }

    void StartCalibration()
    {
        // Start calibration based on the current index of the dialogue
        switch (index)
        {
            case 2:
                
                calibrationController.StartCalibrationPlantarflexion();
                break;
            case 3:
                calibrationController.isCalibratingPlantarflexion = false;
                calibrationController.StartCalibrationDorsiflexion();
                break;
            case 4:
                calibrationController.isCalibratingDorsiflexion = false;
                calibrationController.StartCalibrationAbduction();
                break;
            case 5:
                calibrationController.isCalibratingAbduction = false;
                calibrationController.StartCalibrationAdduction();
                break;
            case 6:
                calibrationController.isCalibratingAdduction = false;
                break;
        }
    }

    void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null); // Deselect the current selected game object
    }
}