using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
     [SerializeField]public GameObject PointA;
     [SerializeField]public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
     [SerializeField]public float speed;
     private int RotationZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("isRunning",true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, RotationZ);
       
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            rb.velocity = new Vector2(-speed,0);
            transform.localScale = new Vector3(1,1,1);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 1.5f && currentPoint == PointB.transform)
        {
            currentPoint = PointA.transform;
           
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 1.5f && currentPoint == PointA.transform)
        {
            currentPoint = PointB.transform;
        }
        
    }
}
