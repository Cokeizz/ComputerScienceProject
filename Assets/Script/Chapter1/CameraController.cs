using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{


    //private Vector3 velocity = Vector3.zero;

    //Follow Player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float cameraVertical;
    [SerializeField] private float aboveDistance;
    private float lookAhead;
    private float lookDown;
    private string sceneName;



    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void Update()
    {


        //Follow Player
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        lookDown = Mathf.Lerp(lookDown, (aboveDistance * player.localScale.y), Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(player.position.x + lookAhead, cameraVertical + lookDown, transform.position.z);

        if (sceneName == "SampleScene")
        {
            if (player.position.x <= 100.0f)
                aboveDistance = 0.0f;

            if (player.position.x >= 100.0f && player.position.y >= -4.3f)
                aboveDistance = -1.0f;

            if (player.position.x >= 100.0f && player.position.y <= -4.3f)
                aboveDistance = -4.5f;

            if (player.position.x >= 221.0f && player.position.y >= -4.3f)
                aboveDistance = 0.0f;

            if (player.position.x >= 375.0f && player.position.x <= 402.0f)
                aboveDistance = -1.0f;
        }
        if (sceneName == "Chapter2")
        {
            if (player.position.y <= 4.0f)
                aboveDistance = 0.0f;

            if (player.position.y >= 4.00f)
                aboveDistance = 4.0f;
        }

        if (sceneName == "Chapter3")
        {
            transform.position = new Vector3(player.position.x + lookAhead, player.position.y + cameraVertical + lookDown, transform.position.z);

        }


    }


}
