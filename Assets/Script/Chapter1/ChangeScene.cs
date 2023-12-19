using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
[SerializeField] private GameObject infoCard;

    public void MoveToScene(int sceneID)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
    }

    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
    public void infoClick()
    {
        Debug.Log("OnClick");
        infoCard.SetActive(true);
    }
    public void infoClose()
    {
        infoCard.SetActive(false);
    }
}
