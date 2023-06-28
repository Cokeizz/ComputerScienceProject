using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorateObject : MonoBehaviour
{
     private Animator anim;
     private Rigidbody2D body;
     
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
          body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damaged()
    {
            anim.SetTrigger("damaged");  
            body.velocity = new Vector2(8,15);
    }
    private void ObjectReact()
    {
        body.velocity = new Vector2(8,15);
    }
}
