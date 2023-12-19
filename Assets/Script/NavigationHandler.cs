using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationHandler : MonoBehaviour
{

    [SerializeField] private GameObject ResumeUI;

   public void PauseGame ()
    {
        ResumeUI.SetActive(true);
        Time.timeScale = 0;
    }
   public void ResumeGame ()
    {
        Time.timeScale = 1;
        ResumeUI.SetActive(false);
    }



   
}
