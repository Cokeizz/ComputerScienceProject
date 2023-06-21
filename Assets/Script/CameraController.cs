using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  
    
    private Vector3 velocity = Vector3.zero;

    //Follow Player
    [SerializeField]private Transform player;
    [SerializeField]private float aheadDistance;
    [SerializeField]private float cameraSpeed;
    [SerializeField]private float cameraVertical;
    private float lookAhead;
    


    private void Update() {

        //Follow Player
         lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(player.position.x + lookAhead,player.position.y+cameraVertical, transform.position.z);
       

    }


}
