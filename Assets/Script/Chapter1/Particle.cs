using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private float dustVertical;
    [SerializeField]private float dustHorizontal;
    private SpriteRenderer rd;
    private Animator anim;
    private void Awake() {
        
       
      

       
    }
    // Update is called once per frame
    void Update()
    {
         float horizontalInput = Input.GetAxis("Horizontal");
        //Flip 
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(3,3,3);
        if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-3,3,3);
        if(horizontalInput != 0)
            transform.position = new Vector3(player.position.x+dustHorizontal,player.position.y+dustVertical, transform.position.z);
    }
}
