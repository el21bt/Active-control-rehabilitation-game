using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void CalibrateGame()
    {
        SceneManager.LoadScene("Calibration");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

}
